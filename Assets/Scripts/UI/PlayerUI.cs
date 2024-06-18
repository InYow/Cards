using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI _Instance;
    public TextMeshProUGUI roundGUI;
    public TextMeshProUGUI levelGUI;
    public TextMeshProUGUI remainTimesGUI;
    public TextMeshProUGUI remainChipsGUI;
    public TextMeshProUGUI scoreMustGUI;
    public TextMeshProUGUI scoreGUI;
    public TextMeshProUGUI goldGUI;
    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        SetRound(RoundManager._Instance.Round);
        SetLevel(RoundManager._Instance.Level);
        SetremainTimes(RoundManager._Instance.remainTimes);
        SetremainChips(RoundManager._Instance.gold);
        SetscoreMust(RoundManager._Instance.score_Must);
        SetScore(RoundManager._Instance.score);
        SetGold(RoundManager._Instance.gold);
    }
    private void Update()
    {
        SetRound(RoundManager._Instance.Round);
        SetLevel(RoundManager._Instance.Level);
        SetremainTimes(RoundManager._Instance.remainTimes);
        SetremainChips(RoundManager._Instance.gold);
        SetscoreMust(RoundManager._Instance.score_Must);
        SetScore(RoundManager._Instance.score);
        SetGold(RoundManager._Instance.gold);
    }
    public void SetRound(int number)
    {
        roundGUI.text = $"回合 {number}";
    }
    public void SetLevel(int number)
    {
        levelGUI.text = $"轮注 {number}";
    }
    public void SetremainTimes(int number)
    {
        remainTimesGUI.text = $"剩余次数 {number}";
    }
    public void SetremainChips(int number)
    {
        remainChipsGUI.text = $"金币 {number}";
    }
    public void SetscoreMust(int number)
    {
        scoreMustGUI.text = $"要求分数 {number}";
    }
    public void SetScore(int number)
    {
        scoreGUI.text = $"得分 {number}";
    }
    public void SetGold(int number)
    {
        goldGUI.text = $"金币 {number}";
    }
}
