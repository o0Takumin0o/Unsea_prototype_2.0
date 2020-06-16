﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text WinTimer;
    public Text bestTimer;
    
    public PlayerCtrl playerCtrl;

    string TimerMinutes;
    string TimerSeconds;
    string TimerSeconds100;
    int minutesInt;
    int secondsInt;
    int seconds100Int;
    //private bool timestop = false;
    private float startTime;
    private float TheTime;
    private float stopTime;
    private bool isRunning = false;
    public bool ReachEndLevel = false;

    void Start()
    {
        TimerStart();
    }

    void Update()
    {
        //if (timestop) return;

        time60Sec();

        timerText.text = TimerMinutes + ":" + TimerSeconds +
            ":" + TimerSeconds100;
        
        WinTimer.text = timerText.text;
        bestTimer.text = timerText.text;
        


    }
    public void OnEndLevel()
    {    // stii no working
        ReachEndLevel = true;
        if(PlayerPrefs.GetFloat("BestTimer") > TheTime)
        {
            PlayerPrefs.SetFloat("BestTimer", float.Parse
                (TimerMinutes + ":" + TimerSeconds + ":" + TimerSeconds100));
        }
        
        if (PlayerPrefs.GetFloat("BestTimer") <= 0)
        {
            //PlayerPrefs.SetFloat("BestTimer", TheTime);
            PlayerPrefs.SetFloat("BestTimer", float.Parse(TimerMinutes + 
                ":" + TimerSeconds + ":" + TimerSeconds100));
        }
        PlayerPrefs.Save();

    }
    public void ResetBestTimer()
    {
        PlayerPrefs.DeleteKey("BestTimer");
        
    }
    public void TimerStart()
    {
        if(!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
        }
    }
    public void TimerStop()
    {
        if (isRunning)
        {
            isRunning = false;
            stopTime = Time.time;
        }
    }
    public void levelEnd()
    {
        //timestop = true;
        timerText.color = Color.yellow;
        TimerStop();
        OnEndLevel();
    }
    public void time60Sec()
    {
        TheTime = stopTime + (Time.time - startTime);
        minutesInt = (int)TheTime / 60;
        secondsInt = (int)TheTime % 60;
        seconds100Int = (int)(Mathf.Floor((TheTime - (secondsInt + minutesInt * 60)) * 100));

        if (isRunning)
        {
            TimerMinutes = (minutesInt < 10) ? "0"+ minutesInt 
                : minutesInt.ToString();
            TimerSeconds = (secondsInt < 10) ? "0" + secondsInt 
                : secondsInt.ToString("00");
            TimerSeconds100 = (seconds100Int < 10) ? "0" + seconds100Int
                : seconds100Int.ToString("00");
        }

        /*time = Time.time - startTime;
        minutes = ((int)time / 60).ToString();
        seconds = (time % 60).ToString("f1");*/

        /*TheTime = stopTime + (Time.time - startTime);
        minutes = ((int)TheTime / 60).ToString("00");
        seconds = (TheTime % 60).ToString("00");
        seconds100Int = (int)(Mathf.Floor((TheTime - seconds + minutes * 60)) * 100);*/
    }
}
