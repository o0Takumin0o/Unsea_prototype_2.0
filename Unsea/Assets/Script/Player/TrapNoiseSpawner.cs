using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNoiseSpawner : MonoBehaviour
{
    public GameObject NoiseMakerPrefab;
    public Transform spawnPoint;
    GameObject NoiseMaker;
    public int DestroyAfter;
    Animator anim;
    public AudioSource Trash_Trap;
    private float coolDown = 1.5f;
    public AudioClip TrapSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Stage", 0);

    }
    void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Player")
        {
            spawnNoiseMaker();
            anim.SetInteger("Stage", 1);
            Trash_Trap.PlayOneShot(TrapSound);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetInteger("Stage", 0);
    }

    // Update is called once per frame

    public void spawnNoiseMaker()
    {
        Vector3 spawnPosition = spawnPoint.position;

        NoiseMaker = (GameObject)Instantiate(NoiseMakerPrefab, spawnPosition, Quaternion.identity);
        Destroy(NoiseMaker, DestroyAfter);
    }
}
