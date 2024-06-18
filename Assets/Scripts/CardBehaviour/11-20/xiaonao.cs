using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaonao : CardBehaviour
{
    int chip = 0;
    float mult = 0;
    bool swap = false;//trueΪ�Ѿ�����
    public override void OnAward(Card card)
    {
        if (!swap)
        {
            swap = true;
            chip = Mathf.RoundToInt(card.GetMult_Basis);
            mult = card.GetChip_Basis + card.GetChip_Beton;
            card.SetChip(chip);
            card.SetMult(mult);
        }
        else
        {
            swap = false;
            chip = card.GetChip_Basis + card.GetChip_Beton;
            mult = card.GetMult_Basis;
            card.SetChip(chip);
            card.SetMult(mult);
        }
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}�ĵ÷�Ϊ{card.GetChip}�����룩 * {card.GetMult}�����ʣ� = {score} .");
        return score;
    }
}
