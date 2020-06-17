using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource AudioClickSound;
    public void PlaySound()
    {
        AudioClickSound.Play();
    }
}
