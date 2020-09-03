using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseSpawner : MonoBehaviour
{
    public GameObject NoiseMakerPrefab;
    // Start is called before the first frame update
    public Transform spawnPoint;
    GameObject NoiseMaker;
    public float DestroyAfter;


    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnNoiseMaker();
        }
    }*/
    public void spawnNoiseMaker()
    { 
        Vector3 spawnPosition = spawnPoint.position;

        NoiseMaker = (GameObject)Instantiate(NoiseMakerPrefab, spawnPosition, Quaternion.identity);
        Destroy(NoiseMaker, DestroyAfter);
    }
}
