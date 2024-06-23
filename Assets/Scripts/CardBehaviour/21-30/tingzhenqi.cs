using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tingzhenqi : CardBehaviour
{
    public override void OnAward(Card card)
    {
        List<Card> cards = CardPool._Instance._ChosenCards;
        foreach (var item in cards)
        {
            if (item.cardData.sort == "����")
            {
                item.SetMult_Basis(item.GetMult + 1);
                card.SetMult_Basis(card.GetMult_Basis + 1);
            }

        }
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