using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : CardBehaviour
{
    public override void OnChosen(Card card)
    {
        RoundManager._Instance.score++;
    }
}
