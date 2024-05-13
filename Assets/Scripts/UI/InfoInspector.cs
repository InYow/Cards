using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
//using Mono.Cecil;
using TMPro;
using UnityEngine;

public class InfoInspector : MonoBehaviour
{
    [Tooltip("名称")] public TextMeshProUGUI item_nameGUI;
    [Tooltip("效果")] public TextMeshProUGUI effectGUI;
    [Tooltip("描述")] public TextMeshProUGUI descripGUI;
    public void SetInfo(ItemInfo info)
    {
        item_nameGUI.text = info.item_name;
        effectGUI.text = info.effect;
        descripGUI.text = info.descrip;
    }
}
