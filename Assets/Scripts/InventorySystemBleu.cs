using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystemBleu : MonoBehaviour
{
    public GameObject quantiteText;
    public static int quantiteCristaux;
    public static int quantiteGraines;

    void Update()
    {
        quantiteText.GetComponent<Text>().text = quantiteGraines + Environment.NewLine + quantiteCristaux ;
    }
}