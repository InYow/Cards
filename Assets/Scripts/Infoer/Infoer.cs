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
    public void SetText(CardData card)
    {
        nameGUI.text = card.cardName;
        descripGUI.text = card.effect;
        jokeGUI.text = card.description;
        image.sprite = card.sprite_color;
    }
}
