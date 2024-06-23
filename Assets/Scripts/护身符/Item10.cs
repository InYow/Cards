using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item10 : Item
{
    public int State1 = 50;//获得300币，销毁此护身符
    public int winGold = 100;
    public int State2 = 50;//销毁此护身符
    public int costGold = 2;
    void Start()
    {
        image = GetComponent<Image>();
        rectTrs = GetComponent<RectTransform>();
        //初始化
        image.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int RandomState()
    {
        int a = Random.Range(0, 100);
        if (a < State1)
        {
            return 1;
        }
        else if (a < State1 + State2)
        {
            return 2;
        }
        else
        {
            return 2;
        }
    }
}
