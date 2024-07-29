using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;
    public Slider speechSlider;

    void Start()
    {
        // do we have saved volume player prefs?
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            // set the mixer volume levels based on the saved player prefs
            mixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
            mixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
            mixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
            mixer.SetFloat("SpeechVol", PlayerPrefs.GetFloat("SpeechVol"));
            SetSliders();
        }
        // otherwise just set the sliders
        else
        {
            SetSliders();
        }
    }

    void SetSliders()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVol");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
        speechSlider.value = PlayerPrefs.GetFloat("SpeechVol");
    }

    // called when we update the master slider
    public void UpdateMasterVolume()
    {
        mixer.SetFloat("MasterVol", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
    // called when we update the sfx slider
    public void UpdateSFXVolume()
    {
        mixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
    // called when we update the music slider
    public void UpdateMusicVolume()
    {
        mixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void UpdateSpeechVolume()
    {
        mixer.SetFloat("SpeechVol", speechSlider.value);
        PlayerPrefs.SetFloat("SpeechVol", speechSlider.value);
    }
}
