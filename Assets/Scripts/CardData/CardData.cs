using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Card Data", fileName = "New Card Data")]
public class CardData : ScriptableObject
{
    public int id;
    public string cardName;
    [TextArea(3, 10)]
    public string description;
}
