using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCristaux : MonoBehaviour
{
    public AudioSource collectSound;
    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();

        if (other.gameObject.tag == "Player1")
        {
            InventorySystemViolet.quantiteCristaux += 1;
        }
        if (other.gameObject.tag == "Player2")
        {
            InventorySystemVert.quantiteCristaux += 1;
        }
        if (other.gameObject.tag == "Player3")
        {
            InventorySystemRouge.quantiteCristaux += 1;
        }
        if (other.gameObject.tag == "Player4")
        {
            InventorySystemBleu.quantiteCristaux += 1;
        }

        Destroy(gameObject);
    }
}
