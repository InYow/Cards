using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empty : CardBehaviour
{
    public override void OnAward(Card card)
    {

    }
    public override float OnSettle(Card card)
    {
        return 0f;
    }
}
