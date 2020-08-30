using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubCollector : MonoBehaviour
{
    [SerializeField] public int collectorPoint;
    public int SavedScore;
    public int HightScore;
    //float CurrenScore;
    //float TotalHightScore;
    public Text HightScoretxt;
    public Text CurrenScoretxt;
    public Text SavedScoretxt;


    Game game;
    CheckPoint CheckPoint;
    ItemDatabase itemDatabase;
    private void Start()
    {        
        game = GameObject.Find("Game").GetComponent<Game>();
        CheckPoint = GameObject.Find("CheckPoint").GetComponent<CheckPoint>();
        
    }
    private void Update()
    {
        //saveHightScore();
        SaveCheckpointHightScore();
        CurrenScoretxt.text = collectorPoint.ToString();

        SavedScore = PlayerPrefs.GetInt("SavedScore" + game.CurrentLevel.ToString());
        SavedScoretxt.text = PlayerPrefs.GetInt("SavedScore" + game.CurrentLevel.ToString()).ToString();

        HightScore = PlayerPrefs.GetInt("HightScore" + game.CurrentLevel.ToString());
        HightScoretxt.text = PlayerPrefs.GetInt("HightScore" + game.CurrentLevel.ToString()).ToString();
        Debug.Log("HightScore = "+ HightScore);
    }
    
    public void UpdatecollectorPoint()
    {
        collectorPoint += 1;

    }
    public void SaveCheckpointHightScore()
    {
        PlayerPrefs.SetInt("SavedScore" + game.CurrentLevel.ToString(), collectorPoint);
        PlayerPrefs.Save();
        SavedScoretxt.text = PlayerPrefs.GetInt("SavedScore" + game.CurrentLevel.ToString()).ToString();
        Debug.Log("SavedScore = " + SavedScore);

    }
    /*void ShowScore()
    {
        if(CheckPoint.CheckPointReatch == false)
        {
            CurrenScoretxt.text = collectorPoint.ToString();
        }
        else
        {
            CurrenScoretxt.text = PlayerPrefs.GetInt("SavedScore").ToString();
        }
    }*/

    public void saveHightScore()
    {//get HightScore
        if (PlayerPrefs.GetInt("HightScore" + game.CurrentLevel.ToString()) < collectorPoint )
        {
            PlayerPrefs.SetInt("HightScore" + game.CurrentLevel.ToString(), collectorPoint);
            HightScoretxt.text = PlayerPrefs.GetInt("HightScore" + game.CurrentLevel.ToString()).ToString();
        }
    }
}

