using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulleScript : MonoBehaviour
{
    public string[] Phrase;
    private TextMeshProUGUI Txt;
    public bool defilement = true;
    public float speed;
    private string TxtDepart;
    public int Duration = 2;
    public bool ExitOnResponse=false;

    private void Start()
    {
        Txt = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (Activation.player1 == true && Activation.player2 == true && Activation.player3 == true &&
            Activation.player4 == true)
        {
            TxtDepart = Phrase[1].Replace("¶",System.Environment.NewLine);
        }
        else
        {
            TxtDepart = Phrase[0].Replace("¶",System.Environment.NewLine);
        }
        StartCoroutine(AfficheText());
    }

    IEnumerator AfficheText()
    {
        string temps = TxtDepart;
        int nbChar = TxtDepart.Length;

        for (int i = 0; i < nbChar; i++)
        {
            yield return new WaitForSeconds(speed);
            Txt.text = temps.Substring(0, i);
        }
        
        StartCoroutine(RefreshDiscussion());
    }

    IEnumerator RefreshDiscussion()
    {
        Debug.Log("Refresh");
        yield return new WaitForSeconds(Duration);

        TxtDepart = Phrase[0].Replace("¶", System.Environment.NewLine);
            StartCoroutine(AfficheText());
        
    }
}
