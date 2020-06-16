using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public float isTime = 0.25f;
    public bool Endlevel = false;
    private void Awake()
    {
        Endlevel = false;
        Time.timeScale = 1f; 
    }

    void Update()
    { 
        slowMotion();
    }

    public void slowMotion()//slow down scale of time to 0.05
    {
        
        if (Endlevel == true)
        {
            Time.timeScale -= 0.05f;       
        }
        if (Time.timeScale == isTime)
        {
            Endlevel = false;
        }
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    public void TimeSpeedReset()
    {
        Endlevel = false;
        Time.timeScale = 1f;
    }
    
}
