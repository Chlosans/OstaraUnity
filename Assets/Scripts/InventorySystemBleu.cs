using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketEvent;

public class InventorySystemBleu : MonoBehaviour
{
    public GameObject quantiteText;
    public static int quantiteCristaux = 2;
    public static int quantiteGraines = 2;
    public static int quantiteFruits;

    // void Start()
    // {
    //     Debug.Log(GameManager.Instance.test);
    // }

    void Update()
    {
        // recpetion inventaire Joueur 2
        if (GameManager.Instance.sendPlayer == 2)
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