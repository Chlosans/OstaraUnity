using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Connexion : MonoBehaviour
{
    public GameObject codeText;
    private int codeRamdon;

    private void Start()
    {

        codeRamdon = UnityEngine.Random.Range(1000,9999);
        Debug.Log(codeRamdon);
        codeText.GetComponent<TextMeshProUGUI>().text =  ""+codeRamdon ;
    }
    
    
  
}
