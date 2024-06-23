using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    public float waittime;
    private void Awake()
    {
        waittime = 2f;
    }
    private void Update()
    {
        waittime -= Time.deltaTime;
        if(waittime<0f&&Input.anyKeyDown)
        {
            SceneManager.LoadScene(2);
        }
    }
}
