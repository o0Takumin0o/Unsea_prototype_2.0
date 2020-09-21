using UnityEngine;

public class GunnerSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip StepSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    private void Step()
    {
        audioSource.PlayOneShot(StepSound);
    }   
}