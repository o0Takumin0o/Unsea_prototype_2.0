using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubCollector : MonoBehaviour
{
    [SerializeField] public int collectorPoint;
    public int HightScore;
    //float CurrenScore;
    //float TotalHightScore;
    public Text HightScoretxt;
    public Text CurrenScoretxt;
    int CurrentLevel;

    private void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        saveHightScore();
        CurrenScoretxt.text = collectorPoint.ToString();
        HightScore = PlayerPrefs.GetInt("HightScore" + CurrentLevel.ToString());
        HightScoretxt.text = PlayerPrefs.GetInt("HightScore" + CurrentLevel.ToString()).ToString();
        Debug.Log("HightScore = "+ HightScore + CurrentLevel.ToString());
    }
    
    public void UpdatecollectorPoint()
    {
        collectorPoint += 1;
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

