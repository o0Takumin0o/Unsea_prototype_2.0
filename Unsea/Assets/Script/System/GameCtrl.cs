using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{
    [SerializeField] public int Point;
    public Text Score;
    public float isTime = 0.25f;
    public bool Endlevel = false;

    void Update()
    {
        slowtime();
    }

    void slowtime()//slow down scale of time to 0.05
    {
        if (Endlevel == false)
        {
            Time.timeScale -= 0.05f;
        }
        if (Time.timeScale == isTime)
        {
            Endlevel = true;
        }
    }
}
