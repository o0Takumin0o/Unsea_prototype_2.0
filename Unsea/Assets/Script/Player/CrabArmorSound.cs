using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabArmorSound : MonoBehaviour
{
    public AudioSource audioSource;
    
    public AudioClip HitCrabSound;

    public void CrabMakeNoise()
    {
        audioSource.PlayOneShot(HitCrabSound);
    }
}
