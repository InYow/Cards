using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qiandai : CardBehaviour
{
    public override void OnAward(Card card)
    {
        int chipGold = RoundManager._Instance.gold;
        card.SetChip(card.GetChip_Beton + chipGold);
        card.SetMult(card.GetMult_Basis);
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}