using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shouzhang : CardBehaviour
{
    int addNum = 5;
    public override void OnTimeStart(Card card)     //第一次回合开始重置筹码
    {
        
    }
    public override void OnAward(Card card)
    {
        if (addNum != 0)
        {
            RoundManager._Instance.gold += addNum;
            addNum -= 1;
            card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
            card.SetMult(card.GetMult_Basis);
        }
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}
