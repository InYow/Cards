using System;
using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public static CardPool cardPool;
    public delegate void EventHandler(object sender, EventArgs e);
    // 卡牌池中的
    public List<Card> Cards = new();
    // 回合开始
    public event EventHandler OnRoundStart;
    // 确定下注
    public event EventHandler OnBet;
    // 抽完了东西
    public event EventHandler OnChosen;
    // 被选择的卡牌们
    public List<Card> ChosenCards = new();
    // 获得队列中卡牌的效果
    public event EventHandler OnAward;
    // 结算这次获得的分数
    public event EventHandler OnSettle;
    // 回合结束
    public event EventHandler OnRoundEnd;
    // 添加元素到卡牌池
    public event EventHandler OnAdd;
    // 删除元素从卡牌池
    public event EventHandler OnRemove;

    private void Awake()
    {
        if (cardPool == null)
            cardPool = this;
        else
            Destroy(gameObject);
    }
    //删除元素
    public void RemoveCard(Card card)
    {
        Cards.Remove(card);
        OnAdd(this, EventArgs.Empty);
    }
    //添加元素
    public void AddCard(Card card)
    {
        Cards.Add(card);
        OnRemove(this, EventArgs.Empty);
    }
    //抽牌
    public void ChosenCard(int number)
    {
        List<Card> cards = cardPool.Cards;
        int a = UnityEngine.Random.Range(0, cards.Count);
        for (int i = 0; i < number; i++)
        {

        }
        Debug.Log(a);
        cardPool.OnChosen(this, EventArgs.Empty);
    }
}
