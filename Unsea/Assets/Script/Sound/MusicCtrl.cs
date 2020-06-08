using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCtrl : MonoBehaviour
{
    public AudioSource MusicVolume;
    public AudioClip Bgm;
    public AudioClip PanicSound;
    /*public static MusicCtrl instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }*/
    
    public void panicSound()
    {
        MusicVolume.PlayOneShot(PanicSound);
    }


}
