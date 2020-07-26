﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public float isTime = 0.25f;
    public bool Endlevel = false;
    float slowMotionSpeed;
    private void Awake()
    {//reset time to nomal speed
        Endlevel = false;
        //Time.timeScale = 1f;
        slowMotionSpeed = 1f;
        Time.fixedDeltaTime = slowMotionSpeed * 0.02f;
    }

    void Update()
    {
        Time.timeScale = slowMotionSpeed;
        slowMotion();
    }

    public void slowMotion()
    {//slow down scale of time to 0.05
        
        if (Endlevel == true)
        {
            slowMotionSpeed -= 0.05f;

            //Time.timeScale -= 0.05f;       
        }
        if (slowMotionSpeed == isTime)//(Time.timeScale == isTime)
        {
            Endlevel = false;
        }
    }
    private void OnDisable()
    {//reset time to nomal speed
        //Time.timeScale = 1f;
        slowMotionSpeed = 1f;
    }
    public void TimeSpeedReset()
    {//reset time to nomal speed
        Endlevel = false;
        //Time.timeScale = 1f;
        slowMotionSpeed = 1f;
    }
    
}
