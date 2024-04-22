using System;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager _Instance;
    [Header("回合、轮注")]
    public int Round;//当前回合数
    public int Level;//当前轮注数
    [Header("剩余次数和抽取数量")]
    public int remainTimes;//剩余的次数
    public int chooseNumber;//抽取的数量
    [Header("分数")]
    public int score_Must;//应得分数
    public int score;//当前得分
    [Header("金币")]
    public int gold;//金币
    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;
        else
            Destroy(gameObject);
    }
    [ContextMenu("该次开始")]
    public void TimeStart()
    {
        CardPool._Instance.TimeStart();
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
    }
    [ContextMenu("触发")]
    public void Award()
    {
        CardPool._Instance.AwardCards();
    }
    [ContextMenu("结算")]
    public void Settle()
    {
        score += (int)CardPool._Instance.Settle();
        PlayerUI._Instance.SetScore(score);
    }
    [ContextMenu("该次结束")]
    public void TimeEnd()
    {
        if (remainTimes == 0)
            DetectWorF();

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
}