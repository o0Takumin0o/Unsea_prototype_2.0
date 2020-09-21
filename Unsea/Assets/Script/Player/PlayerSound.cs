using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip SwimSound;
    //public AudioClip HitCrabSound;



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayerMoveSound()
    {
        audioSource.PlayOneShot(SwimSound);
        /*AudioClip clip = SwimSound;
        audioSource.PlayOneShot(clip);*/
    }
    /*public void PlayerlourSound()
    {
        audioSource.PlayOneShot(HitCrabSound);
    }*/
}
