using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yachi : CardBehaviour
{
    public override void OnAward(Card card)
    {
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton); 
        float GetChip = card.GetChip;
        card.SetMult(GetChip + card.GetChip_Beton);

    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}