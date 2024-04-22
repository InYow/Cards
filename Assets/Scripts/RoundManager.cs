using System;
using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    //public delegate void Function();
    public static RoundManager _Instance;
    [Header("回合、轮注")]
    public int Round;//当前回合数
    public int Level;//当前轮注数
    [Header("剩余筹码、次数和单次的抽取数量")]
    public int remainChips;//剩余的筹码
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
            DetectWorF();
        CardPool._Instance.TimeEnd();
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
    // public void InvokeWaitTime(Function function, float time)
    // {
    //     IEnumerator ie = IEInvokeWaitTime(function, time);
    //     StartCoroutine(ie);
    // }
    // public IEnumerator IEInvokeWaitTime(Function function, float time)
    // {
    //     yield return new WaitForSecondsRealtime(time);
    //     function();
    // }
}