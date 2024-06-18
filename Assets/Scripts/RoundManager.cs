using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager _Instance;
    [Header("刷新服务")]
    public List<Sprite> spriteList;
    public int remainRefreshTimes;
    [Header("回合、轮注")]
    public int Round;//当前回合数
    public int Level;//当前轮注数
    [Header("剩余筹码、次数和单次的抽取数量")]
    public int remainTimes;//剩余的次数
    public int chooseNumber;//抽取的数量
    [Header("分数")]
    public int score_Must;//应得分数
    public int score;//当前得分
    [Header("金币")]
    private int gold;//金币字段
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
    public delegate void boss();
    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;
        else
            Destroy(gameObject);

        isUsing = false;
        remainRefreshTimes = spriteList.Count - 1;
    }
    [ContextMenu("该次开始")]
    public void TimeStart()
    {
        if (isUsing)
            return;
        isUsing = true;
        CardPool._Instance.TimeStart();
        Invoke("Choose", 0.2f);
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
        CardPool._Instance.ChosenCard(chooseNumber);
        //FIXME
        Invoke("Award", 0.5f);
    }
    [ContextMenu("触发")]
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
            //轮注加一,补充剩余次数
            Instantiate(shop);  //打开商店
            Level++;
            remainTimes = 3;
            if (ItemManager.Instance.FindItemWithID(5) != null)
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
            }
        }
        CardPool._Instance.TimeEnd();
        isUsing = false;
        Debug.Log("该次结束");
    }
    public void DetectWorF()
    {
        if (score >= score_Must)
        {
            Win();
            //拥有轮次结束金币+1的遗物
            if (ItemManager.Instance.FindItemWithID(3) != null)
            {
                Gold++;
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
        Debug.Log($"总得分{score}达到了要求得分{score_Must},你赢了!!!");
    }
    public void Failure()
    {
        Debug.Log($"总得分{score}没达到要求得分{score_Must},你输了...");
    }

    //boss boss1 = new boss(Settle());
}