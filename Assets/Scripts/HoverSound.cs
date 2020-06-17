using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSound : MonoBehaviour
{

    public AudioSource AudioHoverSound;
    public void OnMouseOver()
    {
        AudioHoverSound.Play();
    }

}
