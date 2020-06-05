using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text highestScore = null;
    // Start is called before the first frame update
    public double score = 0.0;
    private void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        highestScore.text = "Highest score: " + data.highScore.ToString();

    }
    private void Update()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        score = PlayerStats.Score;
        if (score > data.highScore)
        {
            SaveSystem.SaveScore(this);
            data = SaveSystem.LoadPlayer();
            highestScore.text = "Highest score: " + data.highScore.ToString();
        }
    }
    public void SavePlayer()
    {
        SaveSystem.SaveScore(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        score = data.highScore;
        highestScore.text = "Highest score: " + score.ToString();
    }
}
