using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public Image imageBoss;
    public Sprite bossSprite1;
    public Sprite bossSprite2;
    public Sprite bossSprite3;
    public Sprite bossSprite4;
    public Sprite bossSprite5;
    public Sprite bossSprite6;
    public Sprite bossSprite7;
    public Sprite bossSprite8;

    int currentIndex = 0;
    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public int number = 0;
    public int boss4a;
    public int boss4b;
    void Start()
    {
        //��������
        System.Random rng = new System.Random();
        int n = numbers.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int temp = numbers[k];
            numbers[k] = numbers[n];
            numbers[n] = temp;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))        //֮�����Ϊ�غϽ����󴥷�
        {
            if (currentIndex < numbers.Length)
            {
                CancelEffect(number);
                List<Card> cards = CardPool._Instance._Cards;
                foreach (var c in cards)
                {
                    c.Abandon(false);
                }
                number = numbers[currentIndex];
                Debug.Log("��ǰ���֣�" + numbers[currentIndex]);
                currentIndex++;
                ApplyEffect(number);
            }
            else
            {
                Debug.Log("���������Ѿ�������");
            }
        }

    }
    void ApplyEffect(int number)
    {
        // ��������ִ�в�ͬ��Ч��
        switch (number)
        {
            case 1:
                boss1();        //��ɽ��֮Ů
                break;
            case 2:
                boss2();        //��˹��
                break;
            case 3:
                boss3();        //�޸�˹
                break;
            case 4:
                boss4();        //���ħ��
                break;
            case 5:
                boss5();        //�̸�����˹
                break;
            case 6:
                boss6();        //������
                break;
            case 7:
                boss7();        //͢����˹��Ȯ
                break;
            case 8:
                boss8();        //��֮��
                break;
            default:
                break;
        }
    }
    void CancelEffect(int number)
    {
        // ��������ִ�в�ͬ��Ч��
        switch (number)
        {
            case 1:
                boss1End();
                break;
            case 2:
                boss2End();
                break;
            case 3:
                boss3End();
                break;
            case 4:
                boss4End();
                break;
            case 5:
                boss5End();
                break;
            case 6:
                boss6End();
                break;
            case 7:
                boss7End();
                break;
            case 8:
                boss8End();
                break;
            default:
                break;
        }
    }

    void boss1()    
    {
        imageBoss.sprite = bossSprite1;
    }
    void boss1End()
    {

    }
    void boss2()
    {
        imageBoss.sprite = bossSprite2;
    }
    void boss2End()
    {

    }
    void boss3()
    {
        imageBoss.sprite = bossSprite3;
    }
    void boss3End()
    {

    }
    void boss4()
    {
        imageBoss.sprite = bossSprite4;
        List<Card> cards = CardPool._Instance._Cards;
        int a = UnityEngine.Random.Range(0, cards.Count);
        int b = UnityEngine.Random.Range(0, cards.Count);
        while (b == a)
        {
            b = UnityEngine.Random.Range(0, cards.Count); ;
        }
        cards[a].Abandon(true);
        cards[b].Abandon(true);
        boss4a = a;
        boss4b = b;
    }
    void boss4End()
    {
        List<Card> cards = CardPool._Instance._Cards;
        cards[boss4a].Abandon(false);
        cards[boss4b].Abandon(false);
    }
    void boss5()
    {
        imageBoss.sprite = bossSprite5;
    }
    void boss5End()
    {
        List<Card> cards = CardPool._Instance._Cards;
        foreach (var c in cards)
        {
            c.Abandon(false);
        }
    }
    void boss6()
    {
        
    }
    void boss6End()
    {

    }
    void boss7()
    {
        imageBoss.sprite = bossSprite7;
    }
    void boss7End()
    {

    }
    void boss8()
    {
        imageBoss.sprite = bossSprite8;
    }
    void boss8End()
    {

    }
}
