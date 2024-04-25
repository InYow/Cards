using System;
using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public static CardPool _Instance;
    // 卡牌池中的
    public List<Card> _Cards = new();
    // 被选择的卡牌们
    public List<Card> _ChosenCards = new();

    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;
        else
            Destroy(gameObject);
    }
    [ContextMenu("按卡牌的cardID排序")]
    //按卡牌的cardID排序
    public void SortCards()
    {
        _Cards.Sort((x, y) => x.cardID.CompareTo(y.cardID));
    }
    //删除元素
    public void RemoveCard(Card card)
    {
        _Cards.Remove(card);
    }
    //按cardID有序插入元素
    public void AddCard(Card card)
    {
        int index = -1;
        foreach (var item in _Cards)
        {
            if (item.cardID > card.cardID)
            {
                index = _Cards.IndexOf(item);
                break;
            }
        }
        Debug.Log(index);
        if (index < 0)
        {
            _Cards.Add(card);
        }
        else
        {
            _Cards.Insert(index, card);
        }
    }
    //抽牌
    public void ChosenCard(int number)
    {
        _ChosenCards.Clear();
        List<Card> cards = new();
        if (_Cards.Count == 0)
            return;
        int a = UnityEngine.Random.Range(0, _Cards.Count);
        for (int i = 0; i < number; i++)
        {
            int index = (a + i) % _Cards.Count;
            //生成选中的队列
            cards.Add(_Cards[index]);
        }
        _ChosenCards = cards;
        foreach (var C in _ChosenCards)
        {
            //被选中的调用
            C.OnChosen();
        }
    }
    //单次下注开始
    public void TimeStart()
    {
        foreach (var card in _Cards)
        {
            card.OnTimeStart();
        }
    }
    //单次结束
    public void TimeEnd()
    {
        foreach (var card in _Cards)
        {
            card.OnTimeEnd();
        }
    }
    public void AwardCards()
    {
        foreach (var card in _ChosenCards)
        {
            card.OnAward();
        }
    }
    public float Settle()
    {
        float score = 0f;
        foreach (var item in _ChosenCards)
        {
            score += item.OnSettle();
        }
        return score;
    }
}
