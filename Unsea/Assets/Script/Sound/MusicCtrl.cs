using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCtrl : MonoBehaviour
{
    public AudioSource MusicVolume;
    
    public AudioClip Bgm;
    public AudioClip PanicSound;
    public AudioClip Gameover;
    private float PanicSoundCountdown = 0f;
    private float GameoverCountdown = 0f;

    private void Start()
    {
        MusicVolume = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        
        //MusicVolume.PlayOneShot(Bgm);
        MusicVolume.clip = Bgm;
        
        //MusicVolume.clip = PanicSound;
        MusicVolume.Play();
        //panicSound.Play();
    }

    public void PlayPanicSound()
    {
        
        if (PanicSoundCountdown <= 0f)
        {
            //panicSound.Play();
            MusicVolume.PlayOneShot(PanicSound);
            PanicSoundCountdown = 1f / 1;
        }
        PanicSoundCountdown -= Time.deltaTime;
        //MusicVolume.Play();
        //MusicVolume.PlayOneShot(PanicSound);*/
    }
    
    public void GameOverSound()
    {
        if (GameoverCountdown <= 0f)
        {
            MusicVolume.PlayOneShot(Gameover);
            GameoverCountdown = 3f / 1;
        }
        GameoverCountdown -= Time.deltaTime;
        MusicVolume.PlayOneShot(Gameover);
    }
}
