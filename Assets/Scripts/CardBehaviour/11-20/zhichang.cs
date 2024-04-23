using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhichang : CardBehaviour
{
    int timer = 0;
    int oldRound = 0;
    int oldLevel = 0;
    public override void OnAward(Card card)
    {
        if (timer == 0)
        {
            timer = 1;
        }
        if (timer == 1)
        {
            oldRound = RoundManager._Instance.Round;
            oldLevel = RoundManager._Instance.Level;
            timer = 2;
        }
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis);

    }
    public override void OnTimeStart(Card card)
    {
        int newRound = RoundManager._Instance.Round;
        if (newRound - oldRound == 1)
        {
            RoundManager._Instance.gold += 10;
            timer = 0;
        }
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}
