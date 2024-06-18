using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caoxie : CardBehaviour
{
    public override void OnAward(Card card)
    {
        int a = Random.Range(0, 2);
        if (a == 0)
        {
            if (card.GetMult_Basis > 1)
            {
                card.SetMult_Basis(card.GetMult_Basis - 1);
            }
        }
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