using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 800;
    public double startScore = 20.0;
    public int startToken = 0;
    public static double Score;
    public static int Token;
    public Text waveText;
    public Text goldText;
    public Text scoreUI;
    public Text highestScore;
    public Text TokenUI;
    private void Start()
    {
        Money = startMoney;
        Score = startScore;
        Token = startToken;
    }
    
    void Update()
    {
        
        waveText.text = "Wave: " + WaveSpawner.waveIndex.ToString();
        goldText.text = "$ " + Money.ToString();
        scoreUI.text = "Score: " + Score.ToString();
        TokenUI.text = "Tokens:" + Token.ToString();

    }
    
}
