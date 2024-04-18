using System;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager roundManager;
    public int randomValue;
    private void Awake()
    {
        if (roundManager == null)
            roundManager = this;
        else
            Destroy(gameObject);
    }
    [ContextMenu("抽元素")]
    public void Choose()
    {
        CardPool.cardPool.ChosenCard(randomValue);
    }
}
