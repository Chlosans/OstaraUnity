using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionSound : MonoBehaviour
{
    public AudioSource ApparitionAudioSound;
    public void Start()
    {
        ApparitionAudioSound.Play();
    }
}
