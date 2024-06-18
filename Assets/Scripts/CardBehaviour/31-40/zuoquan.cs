using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearCards = Card.NearCards;

public class zuoquan : CardBehaviour
{
    public override void OnChosen(Card card)
    {
        base.OnChosen(card);
        Card.NearCards nearCards = card.GetNearCards();
        nearCards.left.CardDestroy();
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
