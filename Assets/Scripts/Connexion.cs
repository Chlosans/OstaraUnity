using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;


public class Connexion : MonoBehaviour
{
    public Text codeText;
    private int codeRamdon1;
    private int codeRamdon2;
    private int codeRamdon3;
    private int codeRamdon4;
    private int codeRamdonglobal;
    

    private void Start()
    {

        codeRamdon1 = UnityEngine.Random.Range(1,9);
        codeRamdon2 = UnityEngine.Random.Range(1,9);
        codeRamdon3 = UnityEngine.Random.Range(1,9);
        codeRamdon4 = UnityEngine.Random.Range(1,9);
        codeText.text = "" + codeRamdon1 + " " + codeRamdon2 + " " + codeRamdon3 + " " + codeRamdon4;

        codeRamdonglobal = int.Parse(codeRamdon1.ToString() + codeRamdon2.ToString() + codeRamdon3.ToString() + codeRamdon4.ToString());
    
    }
    
    
  
}
