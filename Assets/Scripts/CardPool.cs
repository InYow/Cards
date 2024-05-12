using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public static CardPool _Instance;
    public List<Hole> _Holes = new();
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
    //删除元素
    public void RemoveCard(Card card)
    {
        _Cards.Remove(card);
    }
    //添加元素
    public void AddCard(Card card)
    {
        foreach (var item in _Holes)
        {
            if(item.card==null)
            {
                item.card = card;
                break;
            }
        }
        _Cards.Add(card);

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
        for (int i = 0; i < _ChosenCards.Count; i++)
        {
            //被选中的调用
            _ChosenCards[i].OnChosen();
        }
        List<Card> UnChoseCards = _Cards.Except(_ChosenCards).ToList();
        for (int i = 0; i < UnChoseCards.Count; i++)
        {
            //未被选中的调用
            UnChoseCards[i].OnUnChosen();
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

    public Hole GetEmptyHole()
    {
        foreach (var item in _Holes)
        {
            if(item.card==null)
            {
                return item;
            }
        }
        return null;
    }
}
