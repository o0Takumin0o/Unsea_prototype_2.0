using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerCtrl : MonoBehaviour
{//Set music and sound effect volume
    public AudioMixer audioMixer;
    [Space(10)]//creat sapce between list in inspecter make it easyer to look
    public Slider musicSlider;
    public Slider sfxSlider;

    public void SetMusicVolume(float volume)
    {//change  0.001 to 1 of slider value to -80 and 0 of mixer 
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetSfxVolume(float volume)
    {//change  0.001 to 1 of slider value to -80 and 0 of mixer 
        audioMixer.SetFloat("sfxVolume", volume);
    }

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0);
    }
    
    private void OnDisable()
    {//only save when exit scene
        float musicVolume = 0;
        float sfxVolume = 0;

        audioMixer.GetFloat("musicVolume", out musicVolume);
        audioMixer.GetFloat("sfxVolume", out sfxVolume);

        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume",  sfxVolume);
        PlayerPrefs.Save();
    }


}
