using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhijia : CardBehaviour
{
    public override void OnChosen(Card card)
    {
        base.OnChosen(card);
        Card.NearCards nearCards = card.GetNearCards();
        if (nearCards.left.cardData.id == 31 && nearCards.left != null)
        {
            card.SetChip_Basis(nearCards.left.GetChip_Basis + card.GetChip_Basis);
            card.SetMult_Basis(nearCards.left.GetMult_Basis + card.GetMult_Basis);
            nearCards.left.CardDestroy();
        }
        if (nearCards.right.cardData.id == 31 && nearCards.right!= null)
        {
            card.SetChip_Basis(nearCards.right.GetChip_Basis + card.GetChip_Basis);
            card.SetMult_Basis(nearCards.right.GetMult_Basis + card.GetMult_Basis);
            nearCards.right.CardDestroy();
        }
    }
    public override void OnAward(Card card)
    {
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis);
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}