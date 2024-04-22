using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CardScore : MonoBehaviour
{
    [Header("仅供调试用")]
    [Header("加注筹码")]
    //加注筹码
    [Tooltip("不要依赖于手动修改此处的数值,可能会引起意想不到的错误")]
    public int chip_Beton;
    public int GetChip_Beton { get => chip_Beton; }
    public void SetChip_BetOn(int value) { chip_Beton = value; }
    public void SetMult(float value) { mult = value; }
    //筹码
    [Header("最终用于计算得分的筹码")]
    [Tooltip("不要依赖于手动修改此处的数值,可能会引起意想不到的错误")]
    public int chip;
    public int GetChip { get => chip; }
    public void SetChip(int value) { chip = value; }
    //倍率
    [Header("最终用于计算得分的倍率")]
    [Tooltip("不要依赖于手动修改此处的数值,可能会引起意想不到的错误")]
    public float mult;
    public float GetMult { get => mult; }
}
