using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CardBehaviour : MonoBehaviour
{
    public virtual void OnRoundStart(Card card)
    {

    }
    public virtual void OnBet(Card card)
    {

    }
    public abstract void OnAward(Card card);
    public abstract float OnSettle(Card card);
    public virtual void OnRoundEnd(Card card)
    {

    }
    public virtual void OnAdd(Card card)
    {

    }
    public virtual void OnRemove(Card card)
    {

    }
    public virtual void OnChosen(Card card)
    {

    }
}
