using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public List<Item> itemList;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public Item FindItemWithID(int id)
    {
        foreach (var item in itemList)
        {
            if (item.itemID == id)
                return item;
        }
        return null;
    }
}
//1 轮次最后一次得分翻倍
//2 shop +1
//3 轮次结束金币+1
//4 抽取次数+1但不能移除
//5 在花钱之前得钱
//6 商店打五折
//10 彩票
//11 - BOSS +1