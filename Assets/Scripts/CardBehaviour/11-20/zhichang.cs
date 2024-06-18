using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhichang : CardBehaviour
{
    int oldRound = 0;
    int oldLevel = 0;
    int oldTimes = 0;
    bool isCan = false;
    bool isChosen = false;
    public override void OnAward(Card card)
    {
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis);

        if (isChosen == false)
        {
            oldLevel = RoundManager._Instance.Level;
            oldRound = RoundManager._Instance.Round;
            oldTimes = RoundManager._Instance.remainTimes;
            isChosen = true;
        }
        
        if (isChosen == true)
        {
            if (RoundManager._Instance.Round*9+RoundManager._Instance.Level*3+RoundManager._Instance.remainTimes > oldRound*9 + oldLevel*3 + oldTimes)
            {
                isCan = true;
            }
        }

        if (isCan == true)
        {
            isCan = false;
            isChosen = false;
            RoundManager._Instance.gold += 10;
        }
    }

    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}
