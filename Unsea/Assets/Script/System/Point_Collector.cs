using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_Collector : MonoBehaviour
{
    [SerializeField] public int Point;
    public Text Score;

    public void UpdatePoint()
    {
        Point += 1;
        Score.text = Point.ToString();
    }
}
