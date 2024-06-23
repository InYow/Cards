using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoer : MonoBehaviour
{
    public static ItemInfoer infoer;
    public Image image;
    public TextMeshProUGUI nameGUI;
    public TextMeshProUGUI desGUI;
    public TextMeshProUGUI saohuaGUI;
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetText(Item item)
    {
        image.sprite = item.sprite;

        nameGUI.text = item.nameStr;
        desGUI.text = item.desStr;
        saohuaGUI.text = item.saohua;
    }
}
