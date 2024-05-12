using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public Card card;
    // Update is called once per frame
    void Update()
    {
        if(card!=null)
        {
        card.gameObject.transform.position = this.transform.position;
        }
    }
}
