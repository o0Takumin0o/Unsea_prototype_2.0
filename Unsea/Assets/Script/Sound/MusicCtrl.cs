using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCtrl : MonoBehaviour
{//still not used yet
    public AudioSource MusicVolume;
    public AudioClip Bgm;
    public AudioClip PanicSound;

    
    public void panicSound()
    {
        MusicVolume.PlayOneShot(PanicSound);
    }


}
