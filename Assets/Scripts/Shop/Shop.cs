using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop _Instance;
    private void Awake()
    {
        if(_Instance==null)
        {
            _Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
