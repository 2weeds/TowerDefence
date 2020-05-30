using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUp : MonoBehaviour
{
    bool isEnabled = false;
    public float scale = 2f;
    float startScale = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            Time.timeScale = scale;
        }
        else
        {
            Time.timeScale = startScale;
        }
    }
    public void speedUp()
    {
        isEnabled = true;
    }
    public void slowDown()
    {
        isEnabled = false;
    }

}
