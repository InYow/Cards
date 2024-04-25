using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class Box : MonoBehaviour
{
    public GameObject card;
    void SetPosition()
    {
        if (card != null)
        {
            card.transform.position = this.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //游戏运行时
        if (Application.isPlaying)
        {

        }
        //编辑状态下
        else
        {
            SetPosition();
        }
    }
}
