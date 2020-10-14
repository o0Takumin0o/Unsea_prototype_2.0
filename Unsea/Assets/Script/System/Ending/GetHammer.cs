using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHammer : MonoBehaviour
{
    public GameObject hammer;
    EndGameButton endGameButton;
    public AudioSource PlayerAudioSource;
    public AudioClip HammerSound;
    //public Animator PlayAnim;
    SoundFx soundFX;
    public PlayerCtrl playerCtrl;
    bool oneTime;

    // Start is called before the first frame update
    void Start()
    {
        hammer.SetActive(false);
        endGameButton = GameObject.Find("EndingButton").GetComponent<EndGameButton>();
        soundFX = GameObject.Find("SoundCtrl").GetComponent<SoundFx>();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    private void Update()
    {
        
        if (endGameButton.GoodEnd == true && !oneTime)
        {
            playerCtrl.enabled = false;
            playerCtrl.animator.SetInteger("Stage", 3);
            oneTime = true;
            StartCoroutine(PlayerCtrlOn());
        }

    }
    IEnumerator PlayerCtrlOn()
    {
        yield return new WaitForSeconds(1);
        playerCtrl.enabled = true;
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
