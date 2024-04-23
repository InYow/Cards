using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chigu : CardBehaviour
{
    //public GameObject empty;
    public override void OnAward(Card card)
    {
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis);
    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
        Debug.Log($"{name}�ĵ÷�Ϊ{card.GetChip}�����룩 * {card.GetMult}�����ʣ� = {score} .");
        //card.cardData = empty.GetComponent<CardData>();
        //card.cardBehaviour = empty.GetComponent<CardBehaviour>();
        //card.cardScore = empty.GetComponent<CardScore>();
        return score;


    }
}
