using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystemRouge : MonoBehaviour
{
    public GameObject quantiteText;
    public static int quantiteCristaux = 1;
    public static int quantiteGraines = 1;
    public static int quantiteFruits;

    void Update()
    {
        // envoie inventaire joueur 3
        if (GameManager.Instance.sendPlayer == 3)
        {

            quantiteCristaux = GameManager.Instance.quantiteCristaux;
            quantiteGraines = GameManager.Instance.quantiteGraines;
            quantiteFruits = GameManager.Instance.quantiteFruits;

            quantiteText.GetComponent<Text>().text = GameManager.Instance.quantiteGraines + Environment.NewLine + GameManager.Instance.quantiteCristaux + Environment.NewLine + GameManager.Instance.quantiteFruits;
        }
        // envoi données si graine/cristaux ramassé
        quantiteText.GetComponent<Text>().text = quantiteGraines + Environment.NewLine + quantiteCristaux + Environment.NewLine + quantiteFruits;
    }
}