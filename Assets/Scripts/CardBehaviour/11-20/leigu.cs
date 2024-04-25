using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leigu : CardBehaviour
{
    public override void OnAward(Card card)
    {
        List<Card> cards = CardPool._Instance._Cards;
        List<Card> onCards = CardPool._Instance._ChosenCards;
        foreach (var item in cards)
        {
            if (item.cardData.id == 11)
            {

            }
        }

    }


    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}
