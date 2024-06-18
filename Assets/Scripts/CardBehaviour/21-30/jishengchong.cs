using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jishengchong : CardBehaviour
{
    float other = 0;
    public override void OnAward(Card card)
    {
        other = 0;
        List<Card> cards = CardPool._Instance._ChosenCards;
        foreach (var item in cards)
        {
            if (item.cardData.sort == "����")
            {
                other += item.cardData.Mult_Basis;
            }

        }
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis+other);
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}�ĵ÷�Ϊ{card.GetChip}�����룩 * {card.GetMult}�����ʣ� = {score} .");
        return score;
    }
}