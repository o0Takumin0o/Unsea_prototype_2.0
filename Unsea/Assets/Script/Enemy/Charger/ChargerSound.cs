using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerSound : MonoBehaviour
{
    [SerializeField]
    AudioClip IdelSound;
    [SerializeField]
    AudioClip MoveSound;
    [SerializeField]
    AudioClip ChaseSound;
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

    private void ChaseNoise()
    {
        audioSource.PlayOneShot(ChaseSound);
    }
}
