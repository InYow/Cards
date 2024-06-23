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
//1 �ִ����һ�ε÷ַ���
//2 shop +1
//3 �ִν������+1
//4 ��ȡ����+1�������Ƴ�
//5 �ڻ�Ǯ֮ǰ��Ǯ
//6 �̵������
//10 ��Ʊ
//11 - BOSS +1