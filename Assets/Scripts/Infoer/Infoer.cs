using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Infoer : MonoBehaviour
{
    public static Infoer infoer;
    public Image image;
    public TextMeshProUGUI nameGUI;
    public TextMeshProUGUI chipGUI;
    public TextMeshProUGUI descripGUI;
    public TextMeshProUGUI jokeGUI;
    public float xL;
    public float xR;
    private void Awake()
    {
        if (infoer == null)
        {
            infoer = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetText(Card card)
    {
        nameGUI.text = card.cardData.cardName;//Ãû×Ö
        CardScore cardScore = card.cardScore;
        if (cardScore == null)
        {
            chipGUI.text = $"(<#000000>{card.cardData.Chip_Basis}</color>)³ïÂë \n(<#000000>{card.cardData.Mult_Basis}</color>)±¶ÂÊ";
        }
        else
        {
            chipGUI.text = $"(<#000000>{cardScore.GetChip_Basis}</color>+<#ff6600>{cardScore.GetChip_Beton}</color>)³ïÂë \n(<#000000>{cardScore.GetMult_Basis}</color>)±¶ÂÊ";//³ïÂë±¶ÂÊ
        }
        descripGUI.text = card.cardData.effect;//Ð§¹û
        jokeGUI.text = card.cardData.description;//ÃèÊö
        image.sprite = card.cardData.sprite_color;//Í¼Æ¬
    }
    private void Update()
    {
        if(transform.localPosition.x>0)
        {
            //ÆÁÄ»ÓÒ±ß
            Vector2 vector2 = GetComponent<RectTransform>().pivot;
            vector2.x = xR;
            GetComponent<RectTransform>().pivot = vector2;
        }
        else
        {
            //ÆÁÄ»×ó±ß
            Vector2 vector2 = GetComponent<RectTransform>().pivot;
            vector2.x = xL;
            GetComponent<RectTransform>().pivot = vector2;
        }
        //Debug.Log(transform.localPosition.x);
    }
}
