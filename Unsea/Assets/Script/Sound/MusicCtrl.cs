using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCtrl : MonoBehaviour
{
    public AudioSource MusicVolume;
    public AudioClip Bgm;
    public AudioClip PanicSound;
 
    public void panicSound()
    {//did not use yet 
     //will use to make dynamic sound
        MusicVolume.PlayOneShot(PanicSound);
    }
}
