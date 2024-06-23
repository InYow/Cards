using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BOSS : MonoBehaviour
{
    public static BOSS _Instance;
    public Image imageBoss;
    public TextMeshProUGUI textGUIL;
    public TextMeshProUGUI textGUIR;
    public GameObject BossRender;

    public Sprite bossSprite1;
    public string boss1StrL;
    public string boss1StrR;

    public Sprite bossSprite2;
    public string boss2StrL;
    public string boss2StrR;

    public Sprite bossSprite3; 
    public string boss3StrL;
    public string boss3StrR;

    public Sprite bossSprite4;
    public string boss4StrL;
    public string boss4StrR;

    public Sprite bossSprite5; 
    public string boss5StrL;
    public string boss5StrR;

    public Sprite bossSprite6; 
    public string boss6StrL;
    public string boss6StrR;

    public Sprite bossSprite7;
    public string boss7StrL;
    public string boss7StrR;

    public Sprite bossSprite8; 
    public string boss8StrL;
    public string boss8StrR;


    int currentIndex = 0;
    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public int number = 0;
    public int boss4a;
    public int boss4b;
    public List<int> bossScore;
    private void Awake()
    {
        _Instance = this;
    }
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
            ChangeBoss();
        }
    }
    public void ChangeBoss()
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
            //BOSS离场动画
            GameObject BossRender_N = Instantiate(BossRender, BossRender.transform.parent);
            Animator animator_N = BossRender_N.GetComponent<Animator>();
            animator_N.Play("out_dic");
            //BOSS的效果生效
            ApplyEffect(number);
            
        }
        else
        {
            Debug.Log("所有数字已经输出完毕");
        }
    }
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
                boss8();
                break;
            default:
                break;
        }
    }

    void boss1()
    {
        imageBoss.sprite = bossSprite1; // 更换图片
        textGUIL.text = boss1StrL;
        textGUIR.text = boss1StrR;
        //RoundManager._Instance.score -= 10;
    }
    void boss1End()
    {

    }
    void boss2()
    {
        imageBoss.sprite = bossSprite2;
        textGUIL.text = boss2StrL;
        textGUIR.text = boss2StrR;
    }
    void boss2End()
    {

    }
    void boss3()
    {
        imageBoss.sprite = bossSprite3;
        textGUIL.text = boss3StrL;
        textGUIR.text = boss3StrR;
    }
    void boss3End()
    {

    }
    void boss4()
    {
        imageBoss.sprite = bossSprite4;
        textGUIL.text = boss4StrL;
        textGUIR.text = boss4StrR;
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
        textGUIL.text = boss5StrL;
        textGUIR.text = boss5StrR;
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
        imageBoss.sprite = bossSprite6;
        textGUIL.text = boss6StrL;
        textGUIR.text = boss6StrR;
    }
    void boss6End()
    {

    }
    void boss7()
    {
        imageBoss.sprite = bossSprite7;
        textGUIL.text = boss7StrL;
        textGUIR.text = boss7StrR;
    }
    void boss7End()
    {

    }
    void boss8()
    {
        imageBoss.sprite = bossSprite8;
        textGUIL.text = boss8StrL;
        textGUIR.text = boss8StrR;
    }
    void boss8End()
    {

    }
}
