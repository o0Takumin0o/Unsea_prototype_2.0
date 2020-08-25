using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameManager GM;

    private void Start()
    {//sent player position to GameManager
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        transform.position = GM.lastCheckPointPos;
    }
}
