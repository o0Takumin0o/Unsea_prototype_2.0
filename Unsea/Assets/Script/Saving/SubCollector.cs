using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubCollector : MonoBehaviour
{
    [SerializeField] public int collectorPoint;
    
    float CurrenScore;
    float TotalHightScore;
    public Text HightScoretxt;
    public Text CurrenScoretxt;

    private void Update()
    {
        HightScore();
        CurrenScoretxt.text = collectorPoint.ToString();
        HightScoretxt.text = PlayerPrefs.GetInt("HightScore").ToString();
    }
    
    public void UpdatecollectorPoint()
    {
        collectorPoint += 1;
    }
    public void HightScore()
    {
        if(PlayerPrefs.GetInt("HightScore") < collectorPoint )
        {
            PlayerPrefs.SetInt("HightScore", collectorPoint);
            HightScoretxt.text = PlayerPrefs.GetInt("HightScore").ToString();
        }       
    }
    public void ResetHightScore()
    {
        PlayerPrefs.DeleteKey("HightScore");
    }
}

