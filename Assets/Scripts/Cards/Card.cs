using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI textGUI;
    public Image image;
    public int cardID;//卡牌的编号
    //-------以上百分百仅用于测试开发
    public CardData cardData;
    public CardBehaviour cardBehaviour;
    public CardScore cardScore;
    //获取基础筹码
    public int GetChip_Basis { get => cardScore.GetChip_Basis; }
    //设置基础筹码
    public void SetChip_Basis(int value) => cardScore.SetChip_Basis(value);

    //获取基础倍率
    public float GetMult_Basis { get => cardScore.GetMult_Basis; }
    //设置基础倍率
    public void SetMult_Basis(float value) => cardScore.SetMult_Basis(value);

    //获取加注筹码
    public int GetChip_Beton { get => cardScore.GetChip_Beton; }
    //设置加注筹码
    public void SetChip_Beton(int value) => cardScore.SetChip_BetOn(value);

    //获取筹码
    public int GetChip { get => cardScore.GetChip; }
    //设置筹码
    public void SetChip(int value) { cardScore.SetChip(value); }

    //获取倍率
    public float GetMult { get => cardScore.GetMult; }
    //设置倍率
    public void SetMult(float value) => cardScore.SetMult(value);

    private void OnValidate()
    {
        // 如果当前 GameObject 上还没有指定的脚本
        if (GetComponent<CardScore>() == null)
        {
            // 给当前 GameObject 添加指定的脚本
            cardScore = gameObject.AddComponent<CardScore>();
        }
    }
    private void Start()
    {
        if (cardData == null)
            Debug.Log($"{gameObject.name}没有绑定 CardData");
        if (cardBehaviour == null)
            Debug.Log($"{gameObject.name}没有绑定 CardBehaviour");
        if (cardScore == null)
        {
            if (GetComponent<CardScore>() == null)
            {
                // 给当前 GameObject 添加指定的脚本
                cardScore = gameObject.AddComponent<CardScore>();
            }
            else
            {
                cardScore = GetComponent<CardScore>();
            }
        }
        AddToPool();
        ShowChipText();
    }
    [ContextMenu("加入牌池")]
    public void AddToPool()
    {
        if (CardPool._Instance._Cards.Contains(this))
        {
            return;
        }
        else
        {
            CardPool._Instance.AddCard(this);
            OnAdd();
        }
    }
    //---------
    // 回合开始
    public void OnTimeStart()
    {

    }
    // 确定下注
    public void OnBet()
    {

    }
    // 抽完时调用
    public void OnChosen()
    {
        this.YesChoose();
        cardBehaviour.OnChosen(this);
    }
    // 获得队列中卡牌的效果
    public void OnAward()
    {
        cardBehaviour.OnAward(this);
    }
    // 结算这次获得的分数
    public float OnSettle()
    {
        return cardBehaviour.OnSettle(this);
    }
    // 回合结束
    public void OnTimeEnd()
    {
        NoChoose();
    }
    // 添加元素到卡牌池
    public void OnAdd()
    {
        cardBehaviour.OnAdd(this);
    }
    // 删除元素从卡牌池
    public void OnRemove()
    {

    }
    [ContextMenu("选中了")]
    public void YesChoose()
    {
        image.color = Color.red;
    }
    [ContextMenu("取消选中")]
    public void NoChoose()
    {
        image.color = Color.white;
    }
    [ContextMenu("加注")]
    public void AddChip(int chip)
    {
        if (RoundManager._Instance.remainChips == 0)
        {
            return;
        }
        else if (RoundManager._Instance.remainChips >= chip)
        {
            cardScore.SetChip_BetOn(cardScore.GetChip_Beton + chip);
            RoundManager._Instance.remainChips -= chip;
        }
        else
        {
            cardScore.SetChip_BetOn(cardScore.GetChip_Beton + RoundManager._Instance.remainChips);
            RoundManager._Instance.remainChips = 0;
        }
        PlayerUI._Instance.SetremainChips(RoundManager._Instance.remainChips);
        ShowChipText();
    }
    [ContextMenu("减注")]
    public void DetectChip(int chip)
    {
        if (this.cardScore.GetChip_Beton == 0)
        {
            return;
        }
        else if (this.cardScore.GetChip_Beton >= chip)
        {
            RoundManager._Instance.remainChips += chip;
            cardScore.SetChip_BetOn(cardScore.GetChip_Beton - chip);
        }
        else
        {
            RoundManager._Instance.remainChips += cardScore.GetChip_Beton;
            cardScore.SetChip_BetOn(0);
        }
        PlayerUI._Instance.SetremainChips(RoundManager._Instance.remainChips);
        ShowChipText();
    }
    //展示该牌筹码
    public void ShowChipText()
    {
        textGUI.text = $"基础筹码：{cardScore.GetChip_Basis}\n追加筹码：{cardScore.GetChip_Beton}";
    }
}
