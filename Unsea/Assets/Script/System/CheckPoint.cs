using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager GM;
    public Transform Checkpoint;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {//if player walk pass checkpoint save checkpoint
            GM.lastCheckPointPos = Checkpoint.transform.position;
            print("Hit");
        }
    }
}
