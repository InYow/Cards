using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public static RoundManager _Instance;
    public bool isRemoving=false;//移除服务中
    [Header("刷新服务")]
    public List<Sprite> spriteList;
    public int remainRefreshTimes;
    [Header("回合、轮注")]
    public int Round;//当前回合数
    public int Level;//当前轮注数
    [Header("剩余筹码、次数和单次的抽取数量")]
    public int remainTimes;//剩余的次数
    public int chooseNumber;//抽取的数量
    public List<int> chooseNumberWLevel;//抽取的数量
    [Header("分数")]
    public int score_Must;//应得分数
    public int score;//当前得分
    [Header("金币")]
    public int gold;//金币字段
    public int Gold//金币属性
    {
        get
        {
            return gold;
        }
        set
        {
            if (value < Gold)
            {
                //金币减少了
                Item item = ItemManager.Instance.FindItemWithID(5);
                if (item != null)
                {
                    Item05 item05 = item as Item05;
                    item05.abandon = true;
                }
            }
            else if (value > Gold)
            {
                //金币增多了
                GameObject.Find("金币增加").GetComponent<AudioSource>().Play();
            }
            gold = value;
        }
    }
    public int removeGold = 6;//移除花费的金币数
    public int removeIncreaseGold = 3;//移除费用随次数上涨的费用
    [Header("商店")]
    public GameObject shop;//商店
    [Header("抽取中")]
    public bool isUsing;
    public Button chooseBtn;
    public GameObject DeadPrb;
    public delegate void boss();
    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;
        else
            Destroy(gameObject);

        isUsing = false;
        //chooseBtn.interactable=true;
        remainRefreshTimes = spriteList.Count - 1;
    }
    private void Start()
    {
        score_Must = BOSS._Instance.bossScore[0];
        //设置下一个boss目标
        GameObject.Find("boss").GetComponent<BOSS>().ChangeBoss();
        PlayerUI._Instance.SetscoreMust(score_Must);
    }
    [ContextMenu("该次开始")]
    public void TimeStart()
    {
        if (isUsing)
            return;
        isUsing = true;
        //chooseBtn.interactable = false;
        CardPool._Instance.TimeStart();
        Invoke("Choose", 0.5f);
    }
    [ContextMenu("抽元素")]
    public void Choose()
    {
        if (remainTimes <= 0)
        {
            return;
        }
        remainTimes--;
        PlayerUI._Instance.SetremainTimes(remainTimes);
        int number = chooseNumberWLevel[Round-1];
        CardPool._Instance.ChosenCard(number);
        //FIXME
        Invoke("Award", 0.5f);
    }
    [ContextMenu("触发")]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(2);
        }
    }
    public void Award()
    {
        CardPool._Instance.AwardCards();
        Invoke("Settle", 0.5f);
    }
    [ContextMenu("结算")]
    public void Settle()
    {
        int getscore = (int)CardPool._Instance.Settle();
        if (remainTimes == 0 && ItemManager.Instance.FindItemWithID(1) != null)
        {
            getscore *= 2;
        }
        if (getscore > 0)
        {
            GameObject.Find("获取精神力").GetComponent<AudioSource>().Play();
        }
        score += getscore;
        PlayerUI._Instance.SetScore(score);
        Invoke("TimeEnd", 0.5f);
    }
    [ContextMenu("该次结束")]
    public void TimeEnd()
    {
        if (remainTimes == 0)
        {
            //本次轮注的结束
            DetectWorF();
            //拥有遗物7-扣除得分
            if (BOSS._Instance.number == 7)
            {
                score -= (int)score_Must/3;
                if (score < 0)
                {
                    //死亡失败
                    Dead();
                    Debug.Log("死亡");
                    GameObject.Find("死亡").GetComponent<AudioSource>().Play();
                }
            }
            //轮注加一,补充剩余次数
            Level++;
            if (Level != 4)
            {
                Instantiate(shop);  //打开商店
            }
            remainTimes = 3;
            if (ItemManager.Instance.FindItemWithID(4) != null)
            {
                remainTimes++;
            }
            if (Level == 3)
            {
                //当前是Boss轮注
                //护身符11
                if (ItemManager.Instance.FindItemWithID(11) != null)
                {
                    remainTimes++;
                }
            }
            if (Level == 4)
            {
                //本次回合的结束
                //回合进一，轮注回归一
                if (score >= score_Must)
                {
                    //通过BOSS
                    GameObject.Find("击败BOSS").GetComponent<AudioSource>().Play();
                    //扣除得分
                    if (BOSS._Instance.number != 7)
                    {
                        score -= score_Must;
                    }
                    //选择护身符
                    GameObject choose = GameObject.Find("护身符选择UI");
                    Debug.Log(choose.name);
                    choose.transform.GetChild(0).transform.gameObject.SetActive(true);
                    choose.transform.GetChild(0).transform.gameObject.GetComponent<ItemChoose>().InitItem();
                }
                else
                {
                    //死亡失败
                    Dead();
                    Debug.Log("死亡");
                    GameObject.Find("死亡").GetComponent<AudioSource>().Play();
                }
                Level = 1;
                //拥有遗物05
                Item item = ItemManager.Instance.FindItemWithID(5);
                if (item != null)
                {
                    Item05 item05 = item as Item05;
                    if (item05.abandon == false)
                        item05.increaseGold += item05.increasedincreaseGold;
                }
                //
                Round++;
                if (Round == 6)
                {
                    if (score >= score_Must)
                    {
                        //通关
                        Debug.Log("通关！");
                    }
                }
                else
                {
                    //设置下一个boss目标
                    PlayerUI._Instance.SetscoreMust(score_Must);
                    GameObject.Find("boss").GetComponent<BOSS>().ChangeBoss();
                    //BOSS变换声音
                    GameObject.Find("BOSS变换").GetComponent<AudioSource>().Play();
                    score_Must = BOSS._Instance.bossScore[Round - 1];
                }
            }
        }
        CardPool._Instance.TimeEnd();
        isUsing = false;
        //chooseBtn.interactable = true;
        //Debug.Log("该次结束");
    }
    public void DetectWorF()
    {
        if (score >= score_Must)
        {
            Win();
            //拥有轮次结束金币+1的遗物
            if (ItemManager.Instance.FindItemWithID(3) != null)
            {
                Gold+=3;
            }
            //拥有遗物05
            Item item = ItemManager.Instance.FindItemWithID(5);
            if (item != null)
            {
                Item05 item05 = item as Item05;
                if (item05.abandon == false)
                    Gold += item05.increaseGold;
            }
            //拥有遗物10
            Item itema = ItemManager.Instance.FindItemWithID(10);
            if (itema != null)
            {
                Item10 item10 = itema as Item10;
                if (RoundManager._Instance.Gold > item10.costGold)
                {
                    RoundManager._Instance.Gold -= item10.costGold;
                    int state = item10.RandomState();
                    if (state == 1)
                    {
                        RoundManager._Instance.Gold += item10.winGold;
                    }
                    else if (state == 2)
                    {
                    }
                    ItemManager.Instance.itemList.Remove(item10);
                    Destroy(item10.gameObject);
                }
            }
        }
        else
        {
            Failure();
        }
    }
    public void Win()
    {
        //Debug.Log($"总得分{score}达到了要求得分{score_Must},你赢了!!!");
    }
    public void Failure()
    {
        //Debug.Log($"总得分{score}没达到要求得分{score_Must},你输了...");
    }
    public void Dead()
    {
        Instantiate(DeadPrb);
    }
}