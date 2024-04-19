using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;
    public CardBehaviour cardBehaviour;
    public CardScore cardScore;
    public int GetChip { get => cardScore.GetChip; }
    public float GetMult { get => cardScore.GetMult; }
    public float GetScore { get => cardScore.GetScore; }
    public void SetChip(int value) { cardScore.SetChip(value); }
    public void SetMult(float value) { cardScore.SetMult(value); }
    private void OnValidate()
    {
        // 如果当前 GameObject 上还没有指定的脚本
        if (GetComponent<CardScore>() == null)
        {
            // 给当前 GameObject 添加指定的脚本
            cardScore = gameObject.AddComponent<CardScore>();
        }
    }
    private void Start()
    {
        if (cardData == null)
            Debug.Log($"{gameObject.name}没有绑定 CardData");
        if (cardBehaviour == null)
            Debug.Log($"{gameObject.name}没有绑定 CardBehaviour");
        if (cardScore == null)
        {
            if (GetComponent<CardScore>() == null)
            {
                // 给当前 GameObject 添加指定的脚本
                cardScore = gameObject.AddComponent<CardScore>();
            }
            else
            {
                cardScore = GetComponent<CardScore>();
            }
        }
    }
    [ContextMenu("加入牌池")]
    public void AddToPool()
    {
        CardPool._Instance.AddCard(this);
        OnAdd();
    }
    //---------
    // 回合开始
    public void OnRoundStart()
    {

    }
    // 确定下注
    public void OnBet()
    {

    }
    // 抽完了东西
    public void OnChosen()
    {
        cardBehaviour.OnChosen(this);
    }
    // 获得队列中卡牌的效果
    public void OnAward()
    {
        cardBehaviour.OnAward(this);
    }
    // 结算这次获得的分数
    public float OnSettle()
    {
        return cardBehaviour.OnSettle(this);
    }
    // 回合结束
    public void OnRoundEnd()
    {

    }
    // 添加元素到卡牌池
    public void OnAdd()
    {
        cardBehaviour.OnAdd(this);
    }
    // 删除元素从卡牌池
    public void OnRemove()
    {

    }
}
