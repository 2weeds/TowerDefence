using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 800;
    public Text waveText;
    public Text goldText;
    private void Start()
    {
        Money = startMoney;
    }
    
    void Update()
    {
        
        waveText.text = "Wave: " + WaveSpawner.waveIndex.ToString();
        goldText.text = "$ " + Money.ToString();
    }
}
