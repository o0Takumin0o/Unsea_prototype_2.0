using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnabled : MonoBehaviour
{
    Collider F_Collider;
    public Collector collector;
    public GameObject VfxWin;
    void Start()
    {
        //Fetch the GameObject's Collider 
        F_Collider = GetComponent<Collider>();
        VfxWin.SetActive(false);
    }

    void Update()
    {
        if (collector.mainPoint == 3)
        {
            //enable collider when player get 3 point
            F_Collider.enabled = true;
            Debug.Log("Collider.enabled = true");
            VfxWin.SetActive(true);
        }
    }
}
