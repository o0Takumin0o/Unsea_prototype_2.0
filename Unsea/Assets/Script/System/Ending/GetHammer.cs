using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHammer : MonoBehaviour
{
    public GameObject hammer;
    EndGameButton endGameButton;
    public AudioSource PlayerAudioSource;
    public AudioClip HammerSound;
    public Animator PlayAnim;
    SoundFx soundFX;


    // Start is called before the first frame update
    void Start()
    {
        hammer.SetActive(false);
        endGameButton = GameObject.Find("EndingButton").GetComponent<EndGameButton>();
        soundFX = GameObject.Find("SoundCtrl").GetComponent<SoundFx>();
    }

    private void Update()
    {
        if (endGameButton.GoodEnd == true)
        {
            PlayAnim.SetInteger("Stage", 3);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Hammer")
        {
            hammer.SetActive(true);
            endGameButton.hasHammer = true;
            soundFX.CollectedAllpointSound();
        }
    }
    void hammerSound()
    {
        PlayerAudioSource.PlayOneShot(HammerSound);
    }
}
