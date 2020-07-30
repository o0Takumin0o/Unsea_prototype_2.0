using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text WinTimer;
    public Text bestTimer;
    
    public PlayerCtrl playerCtrl;
    Achievement achievement;
    [HideInInspector]
    public bool WinBeforeTimeOut;

    string TimerMinutes;
    string TimerSeconds;
    //string TimerSeconds100;
    string BestMinutes;
    string BestSeconds;

    int minutesInt;
    int secondsInt;
    //int seconds100Int;
    int BestMinutesInt;
    int BestSecondsInt;

    //private bool timestop = false;
    private float startTime;
    private float TheTime;
    private float stopTime;
    [HideInInspector] // hide this from inspecter
    public float BestTime;
    float bestTime;
    public float TimeMarker;
    private bool isRunning = false;
    public bool ReachEndLevel = false;

    void Start()
    {
        TimerStart();
        //achievement = GameObject.Find("Canvas").GetComponent<Achievement>();
        WinBeforeTimeOut = false;
    }

    void Update()
    {
        //if (timestop) return;
        bestTime = PlayerPrefs.GetFloat("BestTime");
        time60Sec();
        BestTime60Sec();
        if (ReachEndLevel == true)
        {
            WinIntime();
        }

        timerText.text = TimerMinutes + ":" + TimerSeconds; 
            //+":" + TimerSeconds100;
        
        WinTimer.text = timerText.text;
        bestTimer.text = PlayerPrefs.GetFloat("BestTime").ToString();//real time display this work
        //bestTimer.text = BestMinutes + ":" + BestSeconds;//for now need to en level toupdate timer
        //Debug.Log(BestMinutes + ":" + BestSeconds);
    }
    public void OnEndLevel()
    {
        ReachEndLevel = true;
        
        if (PlayerPrefs.GetFloat("BestTime") > TheTime)
        {
            PlayerPrefs.SetFloat("BestTime", TheTime);
        }
        
        if (PlayerPrefs.GetFloat("BestTime") <= 0)
        {
            PlayerPrefs.SetFloat("BestTime", TheTime); 
        }
        else
        {
            BestTime = PlayerPrefs.GetFloat("BestTime");
        }
        PlayerPrefs.Save();
        
    }

    public void ResetBestTimer()
    {
        PlayerPrefs.DeleteKey("BestTime");
        
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
       

        if (isRunning)
        {
            TimerMinutes = (minutesInt < 10) ? "0"+ minutesInt 
                : minutesInt.ToString();
            TimerSeconds = (secondsInt < 10) ? "0" + secondsInt 
                : secondsInt.ToString("00");
        }
       
    }
    public void BestTime60Sec()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime");

        BestMinutesInt = (int)bestTime / 60;
        BestSecondsInt = (int)bestTime % 60;
        
        if (isRunning)
        {
            BestMinutes = (BestMinutesInt < 10) ? "0" + BestMinutesInt
                : BestMinutesInt.ToString();
            BestSeconds = (BestSecondsInt < 10) ? "0" + BestSecondsInt
                : BestSecondsInt.ToString("00");  
        }

    }
    public void WinIntime()
    {
        if (PlayerPrefs.GetFloat("BestTime") <= TimeMarker) //if (TimeMarker >= BestTime)
        {
            WinBeforeTimeOut = true;
            //achievement.FinishInTime = 1;
            Debug.Log("BestTime = "+ BestTime);
            Debug.Log("TimeMarker = " + TimeMarker);
        }
    }
}
