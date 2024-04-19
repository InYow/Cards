using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : CardBehaviour
{ // Start is called before the first frame update
    public override void OnAward(Card card)
    {
        List<Card> cards = CardPool._Instance._ChosenCards;
        float a = 0;
        foreach (var item in cards)
        {
            if (item.cardData.id == 2)
            {
                a += 2;
            }
        }
        foreach (var item in cards)
        {
            if (item.cardData.id == 2)
            {
                item.SetMult(a);
            }
        }
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetScore;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {card.GetScore} .");
        return score;
    }
}
