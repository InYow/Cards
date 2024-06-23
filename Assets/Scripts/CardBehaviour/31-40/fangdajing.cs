using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fangdajing : CardBehaviour
{
    int oldRound = 0;
    int oldLevel = 0;
    int oldTimes = 0;
    float gap = 0;
    int old = 0;
    int now = 0;
    public override void OnAdd(Card card)
    {
        oldRound = RoundManager._Instance.Round;
        oldLevel = RoundManager._Instance.Level;
        oldTimes = RoundManager._Instance.remainTimes;
    }
    public override void OnAward(Card card)
    {
        old = oldRound * 9 + oldLevel * 3 + oldTimes;
        now = RoundManager._Instance.Round * 9 + RoundManager._Instance.Level * 3 + RoundManager._Instance.remainTimes;
        gap = now - old;
        card.SetMult_Basis(card.GetMult_Basis + ((float)0.5 * gap));
        
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis);
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
    public override void OnTimeEnd(Card card)
    {
        base.OnTimeEnd(card);
        card.CardDestroy();
    }
}
