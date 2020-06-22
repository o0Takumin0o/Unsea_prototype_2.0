using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameManager GM;

    private void Start()
    {//sent player position to GameManager
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        transform.position = GM.lastCheckPointPos;
    }
}
