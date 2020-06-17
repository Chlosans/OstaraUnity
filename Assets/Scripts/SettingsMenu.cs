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
    public static string quit;
    public AudioMixer audioMixer;

    public static void Quit(string data)
    {
        Debug.Log(data);
        quit = data;
    }



    private void Start()
    {
        float music = PlayerPrefs.GetFloat("volume", -10);

        Slider musicSlider = GameObject.Find("MusiqueSlider").GetComponent<Slider>();
        musicSlider.SetValueWithoutNotify(music);

        AdjustMusicVolume(music);
    }

    public void AdjustMusicVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);

        PlayerPrefs.Save();
    }

    public void QuitGame()
    {
        // si click sur le boutton quitter le jeu se ferme
        if (quit == "{\"data\":\"quit\"}")
        {
            Application.Quit();

        }
    }

}
