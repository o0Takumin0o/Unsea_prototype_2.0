using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{//use for key item collector
    [SerializeField] public int mainPoint;
    int saveMainPoint;
    public Text MainScore;
    //Game game;
    PlayerCtrl playerCtrl;
    public Text SavedMainScoretxt;
    int CurrentLevel;

    /*private void Awake()
    {
        mainPoint = mainPoint + PlayerPrefs.GetInt("saveMainPoint" + game.CurrentLevel.ToString());
    }*/
    private void Start()
    {
        
        //game = GameObject.Find("Game").GetComponent<Game>();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        //mainPoint = saveMainPoint;
        //mainPoint = mainPoint + PlayerPrefs.GetInt("saveMainPoint" + game.CurrentLevel.ToString());

        /*saveMainPoint = PlayerPrefs.GetInt("saveMainPoint" + game.CurrentLevel.ToString());
        mainPoint = mainPoint + saveMainPoint;*/
    }
    private void Update()
    {
        if(playerCtrl.LevelEnd == true)
        {
            PlayerPrefs.DeleteKey("saveMainPoint");
        }
        saveMainPoint = PlayerPrefs.GetInt("saveMainPoint" +CurrentLevel.ToString());
        MainScore.text = PlayerPrefs.GetInt("saveMainPoint" + CurrentLevel.ToString()).ToString();
        SavedMainScoretxt.text = PlayerPrefs.GetInt("saveMainPoint" + CurrentLevel.ToString()).ToString();
        //MainScore.text = saveMainPoint.ToString();
        if (mainPoint <= saveMainPoint)
        {
            MainScore.text = saveMainPoint.ToString();
        }
        else
        {
            MainScore.text = mainPoint.ToString();
        }
        //Debug.Log("saveMainPoint = " + saveMainPoint);
    }
    public void UpdatePoint()
    {
        mainPoint += 1;
        //MainScore.text = mainPoint.ToString();
        
    }
    public void SaveMainPointScore()
    {
        /*if (mainPoint != 0)
        {
            PlayerPrefs.SetInt("saveMainPoint" + game.CurrentLevel.ToString(), mainPoint);

            MainScore.text = PlayerPrefs.GetInt("saveMainPoint" + game.CurrentLevel.ToString()).ToString();
            Debug.Log("saveMainPoint = " + saveMainPoint);
        }*/
        PlayerPrefs.SetInt("saveMainPoint" + CurrentLevel.ToString(), mainPoint);

        MainScore.text = PlayerPrefs.GetInt("saveMainPoint" +CurrentLevel.ToString()).ToString();
        //Debug.Log("saveMainPoint = " + saveMainPoint);
    }

}
