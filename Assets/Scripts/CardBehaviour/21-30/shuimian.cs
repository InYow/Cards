using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuimian : CardBehaviour
{
    public override void OnAward(Card card)
    {
        List<Card> cards = CardPool._Instance._Cards;
        List<Card> chosenCards = CardPool._Instance._ChosenCards;
        foreach (var chosenItem in chosenCards)
        {
            if (chosenItem.cardData.id == 28)
            {
                foreach (var item in cards)
                {
                    if (item.cardData.sort == "器官")
                    {
                        item.SetMult_Basis(item.GetMult_Basis + 2);
                    }
                }
            }
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
}