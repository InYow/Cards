using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite sprite;
    [Tooltip("护身符的名称")] public string nameStr;
    [Tooltip("护身符的描述")]public string desStr;
    [Tooltip("骚话")] public string saohua;
    public int itemID;
    [Header("GO上的组件")]
    public Image image;
    [Header("和点击相关")]
    public bool ed = false;
    public RectTransform rectTrs;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!ed)
        {
            Vector2 vector2 = new(100, 100);
            rectTrs.sizeDelta = vector2;
            transform.parent = ItemManager.Instance.transform;
            ItemManager.Instance.itemList.Add(this);
            ItemChoose._Instance.Close();
            ed = true;
            GameObject.Find("护身符选择").GetComponent<AudioSource>().Play();
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
        rectTrs = GetComponent<RectTransform>();
        //初始化
        image.sprite = sprite;
    }
}
