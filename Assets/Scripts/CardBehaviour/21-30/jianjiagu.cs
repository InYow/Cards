using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jianjiagu : CardBehaviour
{
    public override void OnTimeStart(Card card)     //��һ�λغϿ�ʼ���ó���
    {
        card.SetChip(2);
        card.SetChip_Basis(1);
    }
    public override void OnAward(Card card)
    {
        card.SetMult_Basis(card.GetMult_Basis + 1); 
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
