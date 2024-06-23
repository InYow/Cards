using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public GameObject startUI;
    public GameObject gif;
    public float skipDuration = 2.0f; // 长按持续时间
    private bool skipButtonDown = false; // 是否正在长按
    private float skipTimer = 0.0f; // 长按计时器
    bool end;//播片是否结束

    private void Start()
    {
        if (gif != null)
        {
            gif.SetActive(true);
            StartCoroutine(DisableImageAfterDelay(31.5f));
        }  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 检测玩家按下空格键
        {
            skipButtonDown = true;
        }

        if (skipButtonDown)
        {
            skipTimer += Time.deltaTime;

            if (skipTimer >= skipDuration)
            {
                // 在此执行跳过操作，比如跳过当前音频或剧情
                end = true;

                // 重置长按状态和计时器
                skipButtonDown = false;
                skipTimer = 0.0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) // 检测玩家松开空格键
        {
            // 重置长按状态和计时器
            skipButtonDown = false;
            skipTimer = 0.0f;
        }

        if (end)
        {
            gif.SetActive(false);
            startUI.SetActive(true);
        }
    }

    private IEnumerator DisableImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        end = true;
    }
    public void LoadScene00()
    {
        Animator animator = GameObject.Find("开始UI").GetComponent<Animator>();
        animator.Play("过渡");
        StartCoroutine(SetDelayed(0.5f));
    }

    IEnumerator SetDelayed( float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
