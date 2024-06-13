using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite sprite;
    public int itemID;
    [Header("GO上的组件")]
    public Image image;
    void Start()
    {
        image = GetComponent<Image>();

        //初始化
        image.sprite = sprite;
    }
}
