using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jiezhi : CardBehaviour
{
    public override void OnAward(Card card)
    {
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis);
        RoundManager._Instance.Gold += 3;
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}�ĵ÷�Ϊ{card.GetChip}�����룩 * {card.GetMult}�����ʣ� = {score} .");
        return score;
    }
}
