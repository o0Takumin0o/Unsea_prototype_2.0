using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSound : MonoBehaviour
{
    [SerializeField]
    AudioClip IdelSound;
    [SerializeField]
    AudioClip MoveSound;
    [SerializeField]
    AudioClip MakeSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void IdelNoise()
    {
        audioSource.PlayOneShot(IdelSound);
    }

    private void MoveNoise()
    {
        audioSource.PlayOneShot(MoveSound);
    }

    private void MakeNoise()
    {
        audioSource.PlayOneShot(MakeSound);
    }
    
}
