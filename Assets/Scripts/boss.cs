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
        //数组排序
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
        if (Input.GetKeyDown(KeyCode.E))        //之后更换为回合结束后触发
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
                Debug.Log("当前数字：" + numbers[currentIndex]);
                currentIndex++;
                ApplyEffect(number);
            }
            else
            {
                Debug.Log("所有数字已经输出完毕");
            }
        }

    }
    void ApplyEffect(int number)
    {
        // 根据数字执行不同的效果
        switch (number)
        {
            case 1:
                boss1();        //黑山羊之女
                break;
            case 2:
                boss2();        //伊斯人
                break;
            case 3:
                boss3();        //修格斯
                break;
            case 4:
                boss4();        //钻地魔虫
                break;
            case 5:
                boss5();        //犹格索托斯
                break;
            case 6:
                boss6();        //古老者
                break;
            case 7:
                boss7();        //廷达洛斯猎犬
                break;
            case 8:
                boss8();        //星之彩
                break;
            default:
                break;
        }
    }
    void CancelEffect(int number)
    {
        // 根据数字执行不同的效果
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
