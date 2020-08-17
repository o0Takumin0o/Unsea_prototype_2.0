using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNoiseSpawner : MonoBehaviour
{
    public GameObject NoiseMakerPrefab;
    // Start is called before the first frame update
    public Transform spawnPoint;
    GameObject NoiseMaker;
    public int DestroyAfter;


    void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Player")
        {
            spawnNoiseMaker();
        }
    }
 
    // Update is called once per frame
    
    public void spawnNoiseMaker()
    {
        Vector3 spawnPosition = spawnPoint.position;

        NoiseMaker = (GameObject)Instantiate(NoiseMakerPrefab, spawnPosition, Quaternion.identity);
        Destroy(NoiseMaker, DestroyAfter);
    }
}
