using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qiandai : CardBehaviour
{
    public override void OnAward(Card card)
    {
        int chipGold = RoundManager._Instance.Gold;
        card.SetChip(card.GetChip_Beton + chipGold);
        card.SetMult(card.GetMult_Basis);
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}�ĵ÷�Ϊ{card.GetChip}�����룩 * {card.GetMult}�����ʣ� = {score} .");
        return score;
    }
}