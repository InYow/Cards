using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiaToMain : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(SetDelayed(0.5f));
    }

        //Animator animator = GameObject.Find("¿ªÊ¼UI").GetComponent<Animator>();
        //animator.Play("¹ý¶É");

    IEnumerator SetDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
