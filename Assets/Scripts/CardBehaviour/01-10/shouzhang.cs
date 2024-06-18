using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shouzhang : CardBehaviour
{
    int addNum = 5;

    public override void OnAward(Card card)
    {
        if (addNum != 0)
        {
            RoundManager._Instance.Gold += addNum;
            addNum -= 1;
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
