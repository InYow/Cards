using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public GameObject startUI;
    public GameObject gif;
    public float skipDuration = 2.0f; // ��������ʱ��
    private bool skipButtonDown = false; // �Ƿ����ڳ���
    private float skipTimer = 0.0f; // ������ʱ��
    bool end;//��Ƭ�Ƿ����

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
        if (Input.GetKeyDown(KeyCode.Space)) // �����Ұ��¿ո��
        {
            skipButtonDown = true;
        }

        if (skipButtonDown)
        {
            skipTimer += Time.deltaTime;

            if (skipTimer >= skipDuration)
            {
                // �ڴ�ִ����������������������ǰ��Ƶ�����
                end = true;

                // ���ó���״̬�ͼ�ʱ��
                skipButtonDown = false;
                skipTimer = 0.0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) // �������ɿ��ո��
        {
            // ���ó���״̬�ͼ�ʱ��
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
        Animator animator = GameObject.Find("��ʼUI").GetComponent<Animator>();
        animator.Play("����");
        StartCoroutine(SetDelayed(0.5f));
    }

    IEnumerator SetDelayed( float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
