using System;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager _Instance;
    public int score;
    public int randomValue;
    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;
        else
            Destroy(gameObject);
    }
    [ContextMenu("抽元素")]
    public void Choose()
    {
        CardPool._Instance.ChosenCard(randomValue);
    }
    [ContextMenu("触发")]
    public void Award()
    {
        CardPool._Instance.AwardCards();
    }
    [ContextMenu("结算")]
    public void Settle()
    {
        CardPool._Instance.Settle();
    }
}