using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject startUI;
    public GameObject gif;
    public void GameStart()
    {
        if (gif != null)
        {
            gif.SetActive(true);
            StartCoroutine(DisableImageAfterDelay(14.5f));
        }
       startUI.SetActive(false);
    }

    private IEnumerator DisableImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        gif.SetActive(false);
    }
}
