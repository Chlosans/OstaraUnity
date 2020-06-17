using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SocketEvent;

public class BulleScript : MonoBehaviour
{
    private FirstPassage _testJson;
    public GameObject Bulle;
    public string[] Phrase;
    private Text Txt;
    public bool defilement = true;
    public float speed;
    private string TxtDepart;
    public int Duration = 2;
    public bool ExitOnResponse = false;
    private int ligne = 0;
    public GameObject Choix;

    private void Start()
    {
        Txt = transform.GetChild(0).GetComponent<Text>();
        StartCoroutine(AfficheText());
    }

    IEnumerator AfficheText()
    {
        if (ligne != 9)
        {
            TxtDepart = Phrase[ligne].Replace("¶", System.Environment.NewLine);
            string temps = TxtDepart;
            int nbChar = TxtDepart.Length;

            for (int i = 0; i < nbChar; i++)
            {
                yield return new WaitForSeconds(speed);
                Txt.text = temps.Substring(0, i + 1);
            }

            ligne = ligne + 1;
            StartCoroutine(ElementSuivant());
        }
        else
        {
            Choix.SetActive(true);
            Bulle.SetActive(false);

            // envoie au manette le fait qu'il faut afficher la div choice du mobile
            _testJson = new FirstPassage();
            _testJson.eventName = "firstPassage";
            _testJson.afficheDiv = "affiche div Choice";

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));
        }
    }

    IEnumerator ElementSuivant()
    {
        yield return new WaitForSeconds(Duration);
        StartCoroutine(AfficheText());

    }
}

public class FirstPassage
{
    public string eventName;
    public string afficheDiv;
}