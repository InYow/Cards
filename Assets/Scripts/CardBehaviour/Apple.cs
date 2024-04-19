using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : CardBehaviour
{
    public override void OnAward(Card card)
    {
        card.SetMult(1);
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetScore;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {card.GetScore} .");
        return score;
    }
}
