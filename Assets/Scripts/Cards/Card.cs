using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;
    public CardBehaviour cardBehaviour;
    private void Start()
    {
        if (cardData == null)
            Debug.Log($"{gameObject.name}没有绑定 CardData");
        if (cardBehaviour == null)
            Debug.Log($"{gameObject.name}没有绑定 CardBehaviour");
    }
    [ContextMenu("加入牌池")]
    public void AddToPool()
    {
        CardPool.cardPool.AddCard(this);
    }
}
