using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yachi : CardBehaviour
{
    public override void OnAward(Card card)
    {
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton); 
        float GetChip = card.GetChip;
        card.SetMult(GetChip + card.GetChip_Beton);

    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}�ĵ÷�Ϊ{card.GetChip}�����룩 * {card.GetMult}�����ʣ� = {score} .");
        return score;
    }
}