using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text WinTimer;
    public Text bestTimer;
    public Text TimeLimit;

    PlayerCtrl playerCtrl;
    Achievement achievement;
    CheckPoint checkPoint;
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
    public float TheTime;
    private float stopTime;
    [HideInInspector] // hide this from inspecter
    public float BestTime;

    //float TimeWhenHitCheckpoint;

    float bestTime;
    float checkpointTime;
    public float TimeMarker;//time limite
    private bool isRunning = false;
    public bool ReachEndLevel = false;
    //Game game;
    int CurrentLevel;

    /*private void Awake()
    {
        WinBeforeTimeOut = false;
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        checkPoint = GameObject.Find("CheckPoint").GetComponent<CheckPoint>();
    }*/
    void Start()
    {
        TimerStart();
        WinBeforeTimeOut = false;
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        checkPoint = GameObject.Find("CheckPoint").GetComponent<CheckPoint>();
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        //game = GameObject.Find("Game").GetComponent<Game>();
        //achievement = GameObject.Find("Canvas").GetComponent<Achievement>();
        /*WinBeforeTimeOut = false;
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        checkPoint = GameObject.Find("CheckPoint").GetComponent<CheckPoint>();*/
    }

    void Update()
    {
        //if (timestop) return;
        bestTime = PlayerPrefs.GetFloat("BestTime" + CurrentLevel.ToString());
        //checkpointTime = PlayerPrefs.GetFloat("TimeWhenHitCheckpoint");
        time60Sec();
        //BestTime60Sec();
        if (ReachEndLevel == true)
        {
            WinIntime();
        }

        timerText.text = TimerMinutes + " : " + TimerSeconds; 
            //+":" + TimerSeconds100;
        
        WinTimer.text = timerText.text;
        //bestTimer.text = PlayerPrefs.GetFloat("BestTime").ToString();//real time display this work
        bestTimer.text = BestMinutes + ":" + BestSeconds;//for now need to en level toupdate timer
        //WinTimer.text = TimeMarker.ToString();
        //TimerCheckpoint();
    }
    public void OnEndLevel()
    {
        ReachEndLevel = true;
        if (PlayerPrefs.GetFloat("BestTime" + CurrentLevel.ToString()) <= 0)
        {
            PlayerPrefs.SetFloat("BestTime" + CurrentLevel.ToString(), TheTime);
        }

        if (PlayerPrefs.GetFloat("BestTime" + CurrentLevel.ToString()) > TheTime)
        {
            PlayerPrefs.SetFloat("BestTime" + CurrentLevel.ToString(), TheTime);
        }
        else
        {
            BestTime = PlayerPrefs.GetFloat("BestTime" + CurrentLevel.ToString());
        }
        PlayerPrefs.Save();       
    }

    public void ResetBestTimer()
    {
        PlayerPrefs.DeleteKey("BestTime" + CurrentLevel.ToString());
        
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
    /*public void TimerCheckpoint()
    {
        PlayerPrefs.SetFloat("TimeWhenHitCheckpoint", TheTime);
        PlayerPrefs.Save();
        Debug.Log("TimeWhenHitCheckpoint=" + TimeWhenHitCheckpoint);
    }*/
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
        BestMinutes = (BestMinutesInt < 10) ? "0" + BestMinutesInt
                : BestMinutesInt.ToString();
        BestSeconds = (BestSecondsInt < 10) ? "0" + BestSecondsInt
            : BestSecondsInt.ToString("00");
      

    }
    public void WinIntime()
    {
        if (PlayerPrefs.GetFloat("BestTime" + CurrentLevel.ToString()) <= TimeMarker) //if (TimeMarker >= BestTime)
        {
            WinBeforeTimeOut = true;
            //achievement.FinishInTime = 1;
            Debug.Log("BestTime = "+ BestTime);
            Debug.Log("TimeMarker = " + TimeMarker);
        }
    }
}
