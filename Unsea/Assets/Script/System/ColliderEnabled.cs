using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnabled : MonoBehaviour
{
    Collider F_Collider;
    public Collector collector;
    public GameObject VfxWin;
    public GameObject Compass;
    private GameManager GM;
    //private Game game;
    SoundFx soundFX;

    void Start()
    {//Fetch the GameObject's Collider 
        F_Collider = GetComponent<Collider>();
        VfxWin.SetActive(false);
        Compass.SetActive(false);
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //game = GameObject.Find("Game").GetComponent<Game>();
        soundFX = GameObject.Find("SoundCtrl").GetComponent<SoundFx>();
    }

    void Update()
    {
        if (collector.mainPoint == 3)
        {//enable collider when player get 3 point
            
            F_Collider.enabled = true;
            //Debug.Log("Collider.enabled = true");
            VfxWin.SetActive(true);
            Compass.SetActive(true);
            soundFX.CollectedAllpointSound();
        }
    }
    /*public void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Player")
        {
            GM.resetCheckPoint();
            game.ResetCheckpoint();

        }
    }*/
}
