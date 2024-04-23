using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suogu : CardBehaviour
{
    public override void OnAward(Card card)
    {
        card.SetMult(card.GetMult_Basis);
        int GetMult = Mathf.RoundToInt(card.GetMult);
        card.SetChip(GetMult + card.GetChip_Beton);

    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}�ĵ÷�Ϊ{card.GetChip}�����룩 * {card.GetMult}�����ʣ� = {score} .");
        return score;
    }
}