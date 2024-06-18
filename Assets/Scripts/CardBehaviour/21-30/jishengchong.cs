using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jishengchong : CardBehaviour
{
    float other = 0;
    public override void OnAward(Card card)
    {
        other = 0;
        List<Card> cards = CardPool._Instance._ChosenCards;
        foreach (var item in cards)
        {
            if (item.cardData.sort == "器官")
            {
                other += item.cardData.Mult_Basis;
            }

        }
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis+other);
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}