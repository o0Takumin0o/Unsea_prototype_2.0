using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{//use for key item collector
    [SerializeField] public int mainPoint;
    public Text Score;

    public void UpdatePoint()
    {
        mainPoint += 1;
        Score.text = mainPoint.ToString();
    }
}
