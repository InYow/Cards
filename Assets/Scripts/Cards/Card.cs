using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;
    public CardBehaviour cardBehaviour;
    // 回合开始
    public EventHandler OnRoundStart;
    // 确定下注
    public EventHandler OnBet;
    // 抽完了东西
    public void OnChosen()
    {
        cardBehaviour.OnChosen(this);
    }
    // 获得队列中卡牌的效果
    public EventHandler OnAward;
    // 结算这次获得的分数
    public EventHandler OnSettle;
    // 回合结束
    public EventHandler OnRoundEnd;
    // 添加元素到卡牌池
    public void OnAdd()
    {
        cardBehaviour.OnAdd(this);
    }
    // 删除元素从卡牌池
    public EventHandler OnRemove;
    private void Start()
    {
        if (cardData == null)
            Debug.Log($"{gameObject.name}没有绑定 CardData");
        if (cardBehaviour == null)
            Debug.Log($"{gameObject.name}没有绑定 CardBehaviour");
    }
    [ContextMenu("加入牌池")]
    public void AddToPool()
    {
        CardPool._Instance.AddCard(this);
        OnAdd();
    }
}
