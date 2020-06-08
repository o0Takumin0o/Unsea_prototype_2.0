using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFx : MonoBehaviour
{
    [Header("UI")]
    public AudioSource GameSfx;
    public AudioClip HoverFx;
    public AudioClip ClickFx;
    public AudioClip PickupSound;
    public AudioClip SwimSound;
    
    [Header("GamePlay")]
    public AudioClip ShootingSound;
    private float coolDown = 1.5f;
    //private bool isPlaying = false;
    float timeStamp;
    
    /*public static MenuFx instance;
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

    public void HoverSound()
    {
        GameSfx.PlayOneShot(HoverFx);
    }


    public void ClickSound()
    {
        GameSfx.PlayOneShot(ClickFx);
    }
    

    public void CheckSound()
    {
        GameSfx.PlayOneShot(HoverFx);
    }

    public void Pickup()
    {
        GameSfx.PlayOneShot(PickupSound);
    }
    public void swimSound()
    {
        GameSfx.PlayOneShot(SwimSound);
    }
    public void ShootSound()
    {
        GameSfx.PlayOneShot(ShootingSound);
    }
}
