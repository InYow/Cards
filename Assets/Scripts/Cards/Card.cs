using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;
    public CardBehaviour cardBehaviour;
    public CardScore cardScore;

    //获取基础筹码
    public int GetChip_Basis { get => cardData.GetChip_Basis; }
    //设置基础筹码
    public void SetChip_Basis(int value) => cardData.SetChip_Basis(value);

    //获取基础倍率
    public float GetMult_Basis { get => cardData.GetMult_Basis; }
    //设置基础倍率
    public void SetMult_Basis(float value) => cardData.SetMult_Basis(value);

    //获取加注筹码
    public int GetChip_Beton { get => cardScore.GetChip_Beton; }
    //设置加注筹码
    public void SetChip_Beton(int value) => cardScore.SetChip_BetOn(value);

    //获取筹码
    public int GetChip { get => cardScore.GetChip; }
    //设置筹码
    public void SetChip(int value) { cardScore.SetChip(value); }

    //获取倍率
    public float GetMult { get => cardScore.GetMult; }
    //设置倍率
    public void SetMult(float value) => cardScore.SetMult(value);

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
        AddToPool();
    }
    [ContextMenu("加入牌池")]
    public void AddToPool()
    {
        if (CardPool._Instance._Cards.Contains(this))
        {
            return;
        }
        else
        {
            CardPool._Instance.AddCard(this);
            OnAdd();
        }
    }
    //---------
    // 回合开始
    public void OnTimeStart()
    {

    }
    // 确定下注
    public void OnBet()
    {

    }
    // 抽完时调用
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
    public void OnTimeEnd()
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
