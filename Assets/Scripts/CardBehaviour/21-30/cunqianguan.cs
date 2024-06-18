using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class cunqianguan : CardBehaviour
=======
public class cunqianguan :CardBehaviour
>>>>>>> parent of 182cada (6.18)
{
    int oldRound = 0;
    int oldLevel = 0;
    public override void OnAdd(Card card)
    {
        oldRound = RoundManager._Instance.Round;
        oldLevel = RoundManager._Instance.Level;
    }
    public override void OnAward(Card card)
    {
        int newRound = RoundManager._Instance.Round;
        int newLevel = RoundManager._Instance.Level;
        int gapRound = newRound - oldRound;
        int gapLevel = newLevel - oldLevel;
        int gap = gapRound * 3 - gapLevel;
<<<<<<< HEAD
        RoundManager._Instance.Gold += gap;
=======
        RoundManager._Instance.gold += gap;
>>>>>>> parent of 182cada (6.18)
        card.SetChip(card.GetChip_Basis + card.GetChip_Beton);
        card.SetMult(card.GetMult_Basis);

    }
    public override float OnSettle(Card card)
    {
        float score = card.GetMult * card.GetChip;
<<<<<<< HEAD
        Debug.Log($"{name}ï¿½ÄµÃ·ï¿½Îª{card.GetChip}ï¿½ï¿½ï¿½ï¿½ï¿½ë£© * {card.GetMult}ï¿½ï¿½ï¿½ï¿½ï¿½Ê£ï¿½ = {score} .");
=======
        Debug.Log($"{name}µÄµÃ·ÖÎª{card.GetChip}£¨³ïÂë£© * {card.GetMult}£¨±¶ÂÊ£© = {score} .");
>>>>>>> parent of 182cada (6.18)
        return score;
    }
}
