using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager GM;
    public Transform Checkpoint;
    Timer timer;
    SubCollector subCollector;
    Game game;
    Collector collector;
    //float TimeWhenHitCheckpoint;
    public bool CheckPointReatch;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timer = GameObject.Find("TimeManager").GetComponent<Timer>();
        subCollector = GameObject.Find("CollectorManager").GetComponent<SubCollector>();
        collector = GameObject.Find("CollectorManager").GetComponent<Collector>();
        game = GameObject.Find("Game").GetComponent<Game>();
        CheckPointReatch = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {//if player walk pass checkpoint save checkpoint
            CheckPointReatch = true;
            Debug.Log("CheckPointReatch = "+ CheckPointReatch);
            GM.lastCheckPointPos = Checkpoint.transform.position;
            print("SpawnPointSet =" + Checkpoint.transform.position);
            subCollector.saveHightScore();
            subCollector.SaveCheckpointScore();
            collector.SaveMainPointScore();
            //save time
            timer.TimerCheckpoint();

            //save mainpoint
            game.Save();
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
