using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    [SerializeField] public int mainPoint;
    public Text Score;

 
    public void UpdatePoint()
    {
        mainPoint += 1;
        Score.text = mainPoint.ToString();
    }
}
