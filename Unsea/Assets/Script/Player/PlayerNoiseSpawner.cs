using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoiseSpawner : MonoBehaviour
{
    public GameObject NoiseMakerPrefab;
    // Start is called before the first frame update
    public Transform spawnPoint;
    public GameObject CrabArmor;
    GameObject NoiseMaker;
    public int DestroyAfter;
    int hasCrabArmor;

    private void Start()
    {
        hasCrabArmor =0;
        CrabArmor.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnNoiseMaker();
        }*/
        Powerunlock();
    }
    void Powerunlock()
    {
        if (hasCrabArmor == 1)
        {
            CrabArmor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spawnNoiseMaker();
            }
        }
    }
    public void spawnNoiseMaker()
    {
        Vector3 spawnPosition = spawnPoint.position;

        NoiseMaker = (GameObject)Instantiate(NoiseMakerPrefab, spawnPosition, Quaternion.identity);
        Destroy(NoiseMaker, DestroyAfter);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CrabArmor")
        {
            hasCrabArmor += 1;
            Destroy(other.gameObject);
        }
    }

}
