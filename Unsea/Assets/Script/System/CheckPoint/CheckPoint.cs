using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager GM;
    public Transform Checkpoint;
    Timer timer;
    //float TimeWhenHitCheckpoint;
    public bool CheckPointReatch;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timer = GameObject.Find("TimeManager").GetComponent<Timer>();
        CheckPointReatch = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {//if player walk pass checkpoint save checkpoint
            CheckPointReatch = true;
            GM.lastCheckPointPos = Checkpoint.transform.position;
            print("SpawnPointSet =" + Checkpoint.transform.position);
            
            //save time
            timer.TimerCheckpoint();
            //save mainpoint
            //save sub point
        }
    }
    /*void TimerCheckpoint()
    {
        //TimeWhenHitCheckpoint = timer.TheTime;
        PlayerPrefs.SetFloat("TimeWhenHitCheckpoint", timer.TheTime);
        Debug.Log("TimeWhenHitCheckpoint=" + TimeWhenHitCheckpoint);
    }*/
}
