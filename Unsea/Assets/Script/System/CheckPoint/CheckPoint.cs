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
    public GameObject Particle;
    PlayerNoiseSpawner playerNoiseSpawner;

    public bool CheckPointReatch;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timer = GameObject.Find("TimeManager").GetComponent<Timer>();
        subCollector = GameObject.Find("CollectorManager").GetComponent<SubCollector>();
        collector = GameObject.Find("CollectorManager").GetComponent<Collector>();
        game = GameObject.Find("Game").GetComponent<Game>();
        playerNoiseSpawner = GameObject.Find("Player").GetComponent<PlayerNoiseSpawner>();
        CheckPointReatch = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {//if player walk pass checkpoint save checkpoint
            CheckPointReatch = true;
            //Debug.Log("CheckPointReatch = "+ CheckPointReatch);
            GM.lastCheckPointPos = Checkpoint.transform.position;
            
            //save sub point
            subCollector.SaveCheckpointScore();
            //save mainpoint
            collector.SaveMainPointScore();
            //save time
            timer.TimerCheckpoint();
            CheckpointPaticle();
            playerNoiseSpawner.SaveArmor();
            
            game.Save();
            
        }
    }
    void CheckpointPaticle()
    {
        GameObject CheckpointEffect = (GameObject)Instantiate(Particle, transform.position, Quaternion.identity);
        Destroy(CheckpointEffect, 2f);
    }
    /*void TimerCheckpoint()
    {
        //TimeWhenHitCheckpoint = timer.TheTime;
        PlayerPrefs.SetFloat("TimeWhenHitCheckpoint", timer.TheTime);
        Debug.Log("TimeWhenHitCheckpoint=" + TimeWhenHitCheckpoint);
    }*/
}
