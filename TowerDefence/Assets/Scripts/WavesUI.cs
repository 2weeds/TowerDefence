using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity;

public class WavesUI : MonoBehaviour
{
    public Text waveText;
    void Update()
    {
        waveText.text = "Wave: "+WaveSpawner.waveIndex.ToString();
    }
}
