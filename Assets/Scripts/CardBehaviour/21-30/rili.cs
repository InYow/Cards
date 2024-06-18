using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rili : CardBehaviour
{
    public override void OnAward(Card card)
    {
        if (RoundManager._Instance.Round % 2 == 0)
        {
            card.SetMult(card.GetMult_Basis);
            RoundManager._Instance.Gold += (int)card.GetMult;
        }
        else
        {
            card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
            card.SetMult(card.GetMult_Basis);
        }
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}�ĵ÷�Ϊ{card.GetChip}�����룩 * {card.GetMult}�����ʣ� = {score} .");
        return score;
    }
}