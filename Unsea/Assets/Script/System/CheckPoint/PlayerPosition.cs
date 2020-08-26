using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameManager GM;
    //public Vector3 lastCheckPointPos;

    private void Start()
    {//sent player position to GameManager
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        transform.position = GM.lastCheckPointPos;
    }
    
}
