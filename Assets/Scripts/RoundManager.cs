using System;
using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager _Instance;
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
    public int gold;//金币
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
        score += (int)CardPool._Instance.Settle();
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
            if (Level == 4)
            {
                //本次回合的结束
                //回合进一，轮注回归一
                Level = 1;
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