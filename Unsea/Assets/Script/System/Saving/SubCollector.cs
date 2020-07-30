using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubCollector : MonoBehaviour
{
    [SerializeField] public int collectorPoint;
    public int HightScore;
    //float CurrenScore;
    //float TotalHightScore;
    public Text HightScoretxt;
    public Text CurrenScoretxt;

    private void Update()
    {
        saveHightScore();
        CurrenScoretxt.text = collectorPoint.ToString();
        HightScore = PlayerPrefs.GetInt("HightScore");
        HightScoretxt.text = PlayerPrefs.GetInt("HightScore").ToString();
        Debug.Log("HightScore = "+ HightScore);
    }
    
    public void UpdatecollectorPoint()
    {
        collectorPoint += 1;
    }
    public void saveHightScore()
    {//get HightScore
        if (PlayerPrefs.GetInt("HightScore") < collectorPoint )
        {
            PlayerPrefs.SetInt("HightScore", collectorPoint);
            HightScoretxt.text = PlayerPrefs.GetInt("HightScore").ToString();
        }
    }
}

