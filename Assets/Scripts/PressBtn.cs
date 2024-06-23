using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBtn : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Press()
    {
        if(!RoundManager._Instance.isUsing)
        {
        animator.Play("press");
        }
    }
}
