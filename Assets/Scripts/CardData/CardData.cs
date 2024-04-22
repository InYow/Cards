using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Card Data", fileName = "New Card Data")]
public class CardData : ScriptableObject
{
    public int id;
    public string cardName;
    //基础筹码
    public int chip_Basis;
    public int GetChip_Basis { get => chip_Basis; }
    public void SetChip_Basis(int value) { chip_Basis = value; }
    //基础倍率
    public float mult_Basis;
    public float GetMult_Basis { get => mult_Basis; }
    public void SetMult_Basis(float value) { mult_Basis = value; }
    [TextArea(3, 10)]
    public string description;
}
