using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSfx : MonoBehaviour
{
    public AudioClip ShootingSound;
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }
    public void ShootSound()
    {
        audioSource.PlayOneShot(ShootingSound);
    }
}
