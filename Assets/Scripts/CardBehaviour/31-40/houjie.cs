using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houjie : CardBehaviour
{
    public override void OnAward(Card card)
    {
        List<Card> cards = CardPool._Instance._ChosenCards;
        foreach (var item in cards)
        {
            item.SetChip_Basis(item.GetChip_Basis + 5);
        }
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis);
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
    public override void OnTimeEnd(Card card)
    {
        base.OnTimeEnd(card);
        card.CardDestroy();
    }
}

