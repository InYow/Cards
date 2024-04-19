using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScore : MonoBehaviour
{
    //筹码
    public int chip;
    //倍率
    public float mult;
    public int GetChip { get => chip; }
    public float GetMult { get => mult; }
    public float GetScore { get => chip * mult; }
    public void SetChip(int value) { chip = value; }
    public void SetMult(float value) { mult = value; }
}
