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

    int CurrentLevel;
    //Game game;
    //CheckPoint CheckPoint;

    private void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        collectorPoint = PlayerPrefs.GetInt("SavedScore" + CurrentLevel.ToString());
        Debug.Log("SavedScore = " + SavedScore);
        Debug.Log("collectorPoint = " + collectorPoint);
    }
    private void Update()
    {
        //saveHightScore();
        //SaveCheckpointHightScore();
        if(collectorPoint <= SavedScore)
        {
            CurrenScoretxt.text = SavedScore.ToString();
        }
        else
        {
            CurrenScoretxt.text = collectorPoint.ToString();
        }
        //CurrenScoretxt.text = collectorPoint.ToString();

        SavedScore = PlayerPrefs.GetInt("SavedScore" + CurrentLevel.ToString());
        SavedScoretxt.text = PlayerPrefs.GetInt("SavedScore" + CurrentLevel.ToString()).ToString();

        HightScore = PlayerPrefs.GetInt("HightScore" + CurrentLevel.ToString());
        HightScoretxt.text = PlayerPrefs.GetInt("HightScore" + CurrentLevel.ToString()).ToString();
        //Debug.Log("HightScore = "+ HightScore);
    }
    
    public void UpdatecollectorPoint()
    {
        collectorPoint += 1;
    }

    public void SaveCheckpointScore()
    {
        PlayerPrefs.SetInt("SavedScore" + CurrentLevel.ToString(), collectorPoint);
        PlayerPrefs.Save();
        SavedScoretxt.text = PlayerPrefs.GetInt("SavedScore" + CurrentLevel.ToString()).ToString();
    }
   

    public void saveHightScore()
    {//get HightScore
        if (PlayerPrefs.GetInt("HightScore" + CurrentLevel.ToString()) < collectorPoint )
        {
            PlayerPrefs.SetInt("HightScore" + CurrentLevel.ToString(), collectorPoint);
            HightScoretxt.text = PlayerPrefs.GetInt("HightScore" + CurrentLevel.ToString()).ToString();
        }
    }
}

