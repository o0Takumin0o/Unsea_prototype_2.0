using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCtrl : MonoBehaviour
{
    public AudioSource MusicVolume;
    public AudioClip Bgm;
    public AudioClip PanicSound;
    private float PanicSoundCountdown = 0f;

    private void Start()
    {
        MusicVolume = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        MusicVolume.PlayOneShot(Bgm);
        //MusicVolume.clip = PanicSound;
    }

    public void PlayPanicSound()
    {
        if (PanicSoundCountdown <= 0f)
        {
            MusicVolume.PlayOneShot(PanicSound);
            PanicSoundCountdown = 33f / 1;
        }
        PanicSoundCountdown -= Time.deltaTime;
        //MusicVolume.Play();
        //MusicVolume.PlayOneShot(PanicSound);
    }
    public void StopPanicSound()
    {
        MusicVolume.Stop();
    }
}
