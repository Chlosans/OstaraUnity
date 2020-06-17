using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulleScriptPasAssezGraines : MonoBehaviour
{
    private Text Txt;
    private bool defilement = true;
    private float speed = 0.06f;
    private string TxtDepart;
    private int Duration = 1;
    private int ligne = 0;
    private GameObject Bulle;

    private void Start()
    {
        Bulle = gameObject;
        Txt = transform.GetChild(0).GetComponent<Text>();
        StartCoroutine(AfficheText());
    }

    IEnumerator AfficheText()
    {
        if (ligne !=1)
        {
            TxtDepart = "Vous n'avez pas assez de graines...";
            string temps = TxtDepart;
            int nbChar = TxtDepart.Length;

            for (int i = 0; i < nbChar; i++)
            {
                yield return new WaitForSeconds(speed);
                Txt.text = temps.Substring(0, i+1);
            }

            ligne = ligne + 1;
            StartCoroutine(ElementSuivant());
        }
        else
        {
            Destroy(Bulle.GetComponent<BulleScriptPasAssezGraines>());
            Bulle.SetActive(false);
           
        }
    }

    IEnumerator ElementSuivant()
    {
        yield return new WaitForSeconds(Duration);
        StartCoroutine(AfficheText());
        
    }
}