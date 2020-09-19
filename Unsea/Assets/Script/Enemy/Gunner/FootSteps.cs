using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] StepSound;
    
    private AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Step()
    {
        AudioClip clip = StepSound[UnityEngine.Random.Range(0, StepSound.Length)];
        audioSource.PlayOneShot(clip);
    }

    
}