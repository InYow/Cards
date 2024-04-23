using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suogu : CardBehaviour
{
    public override void OnAward(Card card)
    {
        card.SetMult(card.GetMult_Basis);
        int GetMult = Mathf.RoundToInt(card.GetMult);
        card.SetChip(GetMult + card.GetChip_Beton);

    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}