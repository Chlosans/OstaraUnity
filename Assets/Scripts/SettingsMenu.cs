using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;


    private void Start()
    {
        float music = PlayerPrefs.GetFloat("volume", -30);
        
        Slider musicSlider = GameObject.Find("MusiqueSlider").GetComponent<Slider>();
        musicSlider.SetValueWithoutNotify(music);

        AdjustMusicVolume(music);
    }

    public void AdjustMusicVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
        PlayerPrefs.SetFloat("volume",volume);
        
        PlayerPrefs.Save();
    }

}
