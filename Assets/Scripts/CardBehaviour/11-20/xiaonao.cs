using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaonao : CardBehaviour
{
    int chip = 0;
    float mult = 0;
    bool swap = false;//true为已经更换
    public override void OnAward(Card card)
    {
        if (!swap)
        {
            swap = true;
            chip = Mathf.RoundToInt(card.GetMult_Basis);
            mult = card.GetChip_Basis + card.GetChip_Beton;
            card.SetChip(chip);
            card.SetMult(mult);
        }
        else
        {
            swap = false;
            chip = card.GetChip_Basis + card.GetChip_Beton;
            mult = card.GetMult_Basis;
            card.SetChip(chip);
            card.SetMult(mult);
        }
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}
