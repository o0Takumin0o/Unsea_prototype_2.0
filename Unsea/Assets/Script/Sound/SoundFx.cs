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

    public void Swimsound()
    {
        GameSfx.PlayOneShot(SwimSound);
    }

    public void ShootSound()
    {
        GameSfx.PlayOneShot(ShootingSound);
    }
    private float SoundCountdown = 0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (SoundCountdown <= 0f)
            {
                Swimsound();
                SoundCountdown = 1.5f / 1;
            }
            SoundCountdown -= Time.deltaTime;
        }
    }
}
