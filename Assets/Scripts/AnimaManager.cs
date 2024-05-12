using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaManager : MonoBehaviour
{
    public static AnimaManager _Instance;
    public bool IsUsing;
    private void Awake()
    {
        if(_Instance==null)
        {
            _Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        IsUsing = false;
    }
}
