using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public double highScore;

    public PlayerData (Player player)
    {
        highScore = player.score;
    }
}
