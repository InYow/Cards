using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item05 : Item
{
    public bool abandon = false;
    public int increaseGold = 1;
    public int increasedincreaseGold = 1;
    void Start()
    {
        image = GetComponent<Image>();
        rectTrs = GetComponent<RectTransform>();
        //≥ı ºªØ
        image.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
