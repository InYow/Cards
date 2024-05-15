using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quangu : CardBehaviour
{
    int a = 0;
    float mult11 =0;
    public override void OnAward(Card card)
    {
        if (mult11 == 0 && a == 0)
        {
            mult11 = card.GetMult_Basis;
        }

        if (a<5)
        {
            card.SetMult_Basis(mult11);
            card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
            card.SetMult(card.GetMult_Basis);
            a += 1;
            mult11 -= 1;
        }
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}