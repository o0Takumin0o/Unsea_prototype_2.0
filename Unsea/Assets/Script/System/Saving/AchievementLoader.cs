using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementLoader : MonoBehaviour
{
    SubCollector subCollector;
    PlayerCtrl playerCtrl;

    public int LevelAt;

    int collectAllPoint;
    [HideInInspector] // hide this from inspecter
    public int FinishInTime;
    [HideInInspector]
    public int WinLevel;

    public GameObject Completedlevel_Icon;
    public GameObject WinInTime_Icon;
    //public GameObject GetAllPoint_Icon;

    public int ThisLevleHightScore;
    public Text HightScoretxt;


    // Start is called before the first frame update
    void Start()
    {
        FinishInTime = PlayerPrefs.GetInt("FinishInTime" + LevelAt.ToString());
        WinLevel = PlayerPrefs.GetInt("WinLevel" + LevelAt.ToString());
        //GetAllPoint_Icon.SetActive(false);
        WinInTime_Icon.SetActive(false);
        Completedlevel_Icon.SetActive(false);
        ThisLevleHightScore = PlayerPrefs.GetInt("HightScore" + LevelAt.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //FinishInTime = PlayerPrefs.GetInt("FinishInTime" + LevelAt.ToString()); 
        //WinLevel = PlayerPrefs.GetInt("WinLevel" + LevelAt.ToString());
        Achievement();

    }
    void Achievement()
    {
        if (FinishInTime == 1)
        {
            WinInTime_Icon.SetActive(true);
        }
        if (WinLevel == 1)
        {
            Completedlevel_Icon.SetActive(true);
        }
        
        HightScoretxt.text = PlayerPrefs.GetInt("HightScore" + LevelAt.ToString()).ToString();
    }
}
