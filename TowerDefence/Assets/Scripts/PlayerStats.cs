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
    public static double Score;
    public Text waveText;
    public Text goldText;
    public Text scoreUI;
    public Text highestScore;
    private void Start()
    {
        Money = startMoney;
        Score = startScore;
    }
    
    void Update()
    {
        
        waveText.text = "Wave: " + WaveSpawner.waveIndex.ToString();
        goldText.text = "$ " + Money.ToString();
        scoreUI.text = "Score: " + Score.ToString(); 
    }
    
}
