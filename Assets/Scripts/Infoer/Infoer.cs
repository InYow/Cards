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
        nameGUI.text = card.cardData.cardName;//����
        CardScore cardScore = card.cardScore;
        if (cardScore == null)
        {
            chipGUI.text = $"(<#64c0c0>{card.cardData.Chip_Basis}</color>)���� \n(<#64c0c0>{card.cardData.Mult_Basis}</color>)����";
        }
        else
        {
            chipGUI.text = $"(<#64c0c0>{cardScore.GetChip_Basis}</color>+<#ff6600>{cardScore.GetChip_Beton}</color>)���� \n(<#64c0c0>{cardScore.GetMult_Basis}</color>)����";//���뱶��
        }
        descripGUI.text = card.cardData.effect;//Ч��
        jokeGUI.text = card.cardData.description;//����
        image.sprite = card.cardData.sprite_color;//ͼƬ
    }
}
