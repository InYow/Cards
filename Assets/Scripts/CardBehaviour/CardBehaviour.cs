using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CardBehaviour : MonoBehaviour
{
    public abstract void OnChosen(Card card);
    public virtual void OnAdd(Card card)
    {

    }
}
