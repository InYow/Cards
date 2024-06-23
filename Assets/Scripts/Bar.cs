using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private float targetScore;
    private float currentScore;
    private float barPercent;
    public Image image;
    public float delayTime;

    private void Update()
    {
        targetScore = RoundManager._Instance.score_Must;
        currentScore = RoundManager._Instance.score;
        barPercent = currentScore/targetScore ;
        float bar = (float)0.25 + (float )(barPercent * 0.75);
        StartCoroutine(SetFillAmountDelayed(image, bar, delayTime));
    }

    IEnumerator SetFillAmountDelayed(Image img, float amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        img.fillAmount = amount;
    }
}
