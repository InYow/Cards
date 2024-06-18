using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite sprite;
    public string desStr;
    public int itemID;
    [Header("GO上的组件")]
    public Image image;
    [Header("和点击相关")]
    public bool ed = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!ed)
        {
            transform.parent = ItemManager.Instance.transform;
            ItemManager.Instance.itemList.Add(this);
            ItemChoose._Instance.Close();
            ed = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemInfoer.infoer.gameObject.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //信息面板
        ItemInfoer.infoer.SetText(this);
        ItemInfoer.infoer.transform.position = transform.position;
        ItemInfoer.infoer.gameObject.SetActive(true);
    }

    void Start()
    {
        image = GetComponent<Image>();

        //初始化
        image.sprite = sprite;
    }
}
