using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wei : CardBehaviour
{
    int chip = 0;
    float mult = 0;
    public override void OnChosen(Card card)
    {
        base.OnChosen(card);
        Card.NearCards nearCards = card.GetNearCards();
        if(nearCards.left != null)
        {
            chip = nearCards.left.GetChip_Basis;
        }
        else
        {
            chip = 0;
        }
        if (nearCards.right != null)
        {
            mult = nearCards.right.GetMult_Basis;
        }
        else
        {
            mult = 0;
        }
    }
    public override void OnAward(Card card)
    {
        if(chip != 0)
        {
            card.SetChip(chip + card.GetChip_Beton);
        }
        else
        {
            card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        }

        if(mult != 0)
        {
            card.SetMult(mult);
        }
        else
        {
            card.SetMult(card.GetMult_Basis);
        }

    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}的得分为{card.GetChip}（筹码） * {card.GetMult}（倍率） = {score} .");
        return score;
    }
}
