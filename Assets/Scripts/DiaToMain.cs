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

        //Animator animator = GameObject.Find("��ʼUI").GetComponent<Animator>();
        //animator.Play("����");

    IEnumerator SetDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
