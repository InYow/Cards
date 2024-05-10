using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    public string item_name;
    public string effect;
    public string descrip;
    public ItemInfo(CardData cardData)
    {
        this.item_name = cardData.cardName;
        this.effect = cardData.effect;
        this.descrip = cardData.description;
    }
}
