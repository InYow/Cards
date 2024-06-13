using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector]
    public TextMeshProUGUI textGUI;
    [HideInInspector]
    public Image image;
    public GameObject infoObj;//信息面板
    //-------以上百分百仅用于测试开发
    public CardData cardData;
    public CardBehaviour cardBehaviour;
    [HideInInspector]
    public CardScore cardScore;
    private boss boss;


    public Hole GetHole { get => GetComponentsInParent<Hole>()[0]; }
    //
    public int GetHoleIndex()
    {
        Hole hole = GetHole;
        return CardPool._Instance._Holes.IndexOf(hole);
    }
    public class NearCards
    {
        public Card left;
        public Card right;
        public NearCards(Card left, Card right)
        {
            this.left = left;
            this.right = right;
        }
    }
    public NearCards GetNearCards()
    {
        int index = GetHoleIndex();
        List<Hole> aholes = CardPool._Instance._Holes;
        //left
        Card left;
        int leftIndex = index;
        /*        do
                {
                    leftIndex--;
                    if (index < 0)
                    {
                        index += aholes.Count;
                    }
                } while (aholes[leftIndex].card == null);
        */
        leftIndex--;
        if (index < 0)
        {
            index += aholes.Count;
        }
        left = aholes[leftIndex].card;
        //right
        Card right;
        int rightIndex = index;
        /*        do
                {
                    rightIndex++;
                    if (index >= aholes.Count)
                    {
                        rightIndex -= aholes.Count;
                    }
                } while (aholes[rightIndex].card == null);
        */
        rightIndex++;
        if (index >= aholes.Count)
        {
            rightIndex -= aholes.Count;
        }
        right = aholes[rightIndex].card;
        NearCards near = new(left, right);
        return near;
    }

    internal void OnUnChosen()
    {
        cardBehaviour.OnUnChosen(this);
    }

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
        GameObject BOSSGO = GameObject.Find("boss");
        boss = BOSSGO.GetComponent<boss>();
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
        textGUI = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponent<Image>();
        Init();
        AddToPool();
        //ShowChipText();
        //加载信息面板
        infoObj = Resources.Load<GameObject>("得分信息");
    }
    private void Init()
    {
        cardScore.chip_Basis = cardData.Chip_Basis;
        cardScore.mult_Basis = cardData.Mult_Basis;
        GetComponent<Image>().sprite = cardData.sprite;
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
        if (boss.number == 1 && cardData.sort == "物品")
        {

        }
        else if (boss.number == 2 && cardData.sort == "器官")
        {

        }
        else if (boss.number == 3 && cardData.sort == "骨头")
        {

        }
        else if (cardScore.abandon == true)
        {

        }
        else
        {
            cardBehaviour.OnChosen(this);
        }
    }
    // 获得队列中卡牌的效果
    public void OnAward()
    {
        if (boss.number == 1 && cardData.sort == "物品")
        {

        }
        else if (boss.number == 2 && cardData.sort == "器官")
        {

        }
        else if (boss.number == 3 && cardData.sort == "骨头")
        {

        }
        else if (cardScore.abandon == true)
        {

        }
        else
        {
            cardBehaviour.OnAward(this);
        }
    }
    // 结算这次获得的分数
    public float OnSettle()
    {
        if (boss.number == 1 && cardData.sort == "物品")
        {
            return 0f;
        }
        else if (boss.number == 2 && cardData.sort == "器官")
        {
            return 0f;
        }
        else if (cardScore.abandon == true)
        {
            return 0f;
        }
        else if (boss.number == 3 && cardData.sort == "骨头")
        {
            return 0f;
        }
        else
        {
            float score = cardBehaviour.OnSettle(this);
            GameObject infogameObject = Instantiate(infoObj, transform);
            TextMeshProUGUI textMeshProUGUI = infogameObject.GetComponent<TextMeshProUGUI>();
            textMeshProUGUI.text = $"得分{score}";
            return score;
        }
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
        if (RoundManager._Instance.Gold == 0)
        {
            return;
        }
        else if (RoundManager._Instance.Gold >= chip)
        {
            cardScore.SetChip_BetOn(cardScore.GetChip_Beton + chip);
            RoundManager._Instance.Gold -= chip;
        }
        else
        {
            cardScore.SetChip_BetOn(cardScore.GetChip_Beton + RoundManager._Instance.Gold);
            RoundManager._Instance.Gold = 0;
        }
        PlayerUI._Instance.SetremainChips(RoundManager._Instance.Gold);
        Infoer.infoer.SetText(this);
        //ShowChipText();
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
            RoundManager._Instance.Gold += chip;
            cardScore.SetChip_BetOn(cardScore.GetChip_Beton - chip);
        }
        else
        {
            RoundManager._Instance.Gold += cardScore.GetChip_Beton;
            cardScore.SetChip_BetOn(0);
        }
        PlayerUI._Instance.SetremainChips(RoundManager._Instance.Gold);
        Infoer.infoer.SetText(this);
        //ShowChipText();
    }
    //展示该牌筹码和倍率
    public void ShowChipText()
    {
        Infoer.infoer.chipGUI.text = $"(<#64c0c0>{cardScore.GetChip_Basis}</color>+<#ff6600>{cardScore.GetChip_Beton}</color>)筹码 \n(<#64c0c0>{cardScore.GetMult_Basis}</color>)倍率";
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddChip(1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            DetectChip(1);
        }
        //        Debug.Log(gameObject.name);
        //InfoChecker.infoChecker.CreateInfoIpt(new ItemInfo(cardData));
    }
    public void CardDestroy()
    {
        CardPool._Instance._Cards.Remove(this);
        CardPool._Instance._ChosenCards.Remove(this);
        Destroy(this.gameObject);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Infoer.infoer.SetText(this);
        Infoer.infoer.transform.position = transform.position;
        Infoer.infoer.gameObject.SetActive(true);
        //ShowChipText();
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Infoer.infoer.gameObject.SetActive(false);
    }
    public void Abandon(bool b)
    {
        cardScore.abandon = b;
        if (b == true)
        {
            Color color = new(0.5f, 0.5f, 0.5f, 0.6f);
            image.color = color;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
