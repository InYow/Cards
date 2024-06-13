using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cunqianguan : CardBehaviour
{
    int oldRound = 0;
    int oldLevel = 0;
    public override void OnAdd(Card card)
    {
        oldRound = RoundManager._Instance.Round;
        oldLevel = RoundManager._Instance.Level;
    }
    public override void OnAward(Card card)
    {
        int newRound = RoundManager._Instance.Round;
        int newLevel = RoundManager._Instance.Level;
        int gapRound = newRound - oldRound;
        int gapLevel = newLevel - oldLevel;
        int gap = gapRound * 3 - gapLevel;
        RoundManager._Instance.Gold += gap;
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis);

    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}�ĵ÷�Ϊ{card.GetChip}�����룩 * {card.GetMult}�����ʣ� = {score} .");
        return score;
    }
}
