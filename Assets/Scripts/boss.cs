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
    int number = 0;
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
                number = numbers[currentIndex];
                Debug.Log("当前数字：" + numbers[currentIndex]);
                currentIndex++;
            }
            else
            {
                Debug.Log("所有数字已经输出完毕");
            }
        }
        ApplyEffect(number);
    }

    //RoundManager.round;
    void ApplyEffect(int number)
    {
        // 根据数字执行不同的效果
        switch (number)
        {
            case 1:
                boss1();
                break;
            case 2:
                boss2();
                break;
            case 3:
                boss3();
                break;
            case 4:
                boss4();
                break;
            case 5:
                boss5();
                break;
            case 6:
                boss6();
                break;
            case 7:
                boss7();
                break;
            case 8:
                boss8();
                break;
            default:
                break;
        }
    }

    void boss1()
    {
        imageBoss.sprite = bossSprite1; // 更换图片
        RoundManager._Instance.score -= 10;
    }
    void boss2()
    {
        imageBoss.sprite = bossSprite2;
    }
    void boss3()
    {
        imageBoss.sprite = bossSprite3;
    }
    void boss4()
    {
        imageBoss.sprite = bossSprite4;
    }
    void boss5()
    {
        imageBoss.sprite = bossSprite5;
    }
    void boss6()
    {
        imageBoss.sprite = bossSprite6;
    }
    void boss7()
    {
        imageBoss.sprite = bossSprite7;
    }
    void boss8()
    {
        imageBoss.sprite = bossSprite8;
    }
}
