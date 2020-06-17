using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketEvent;


public class InventorySystemVert : MonoBehaviour
{
    public GameObject quantiteText;
    public static int quantiteCristaux = 2;
    public static int quantiteGraines = 6;
    public static int quantiteFruits;

    // void Start()
    // {
    // Debug.Log(GameManager.Instance.test);
    // }

    void Update()
    {
        // envoi inventaire joueur 1
        if (GameManager.Instance.sendPlayer == 1)
        {

            quantiteCristaux = GameManager.Instance.quantiteCristaux;
            quantiteGraines = GameManager.Instance.quantiteGraines;
            quantiteFruits = GameManager.Instance.quantiteFruits;

            quantiteText.GetComponent<Text>().text = GameManager.Instance.quantiteGraines + Environment.NewLine + GameManager.Instance.quantiteCristaux + Environment.NewLine + GameManager.Instance.quantiteFruits;
        }
        // Debug.Log("Else Vert");
        // Debug.Log(GameManager.Instance.quantiteCristaux);
        // envoi données si graine/cristaux ramassé
        quantiteText.GetComponent<Text>().text = quantiteGraines + Environment.NewLine + quantiteCristaux + Environment.NewLine + quantiteFruits;
    }
}