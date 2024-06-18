using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leigu : CardBehaviour
{
    public override void OnAward(Card card)
    {
        Card.NearCards nearCards = card.GetNearCards();
        if(nearCards.left != null && nearCards.left.cardData.id == 20 || nearCards.right != null && nearCards.right.cardData.id == 20)
        {
            card.SetChip((card.GetChip_Basis + card.GetChip_Beton)*2);
            card.SetMult(card.GetMult_Basis);
        }
        else
        {
            card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
            card.SetMult(card.GetMult_Basis);
        }
    }


    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}
