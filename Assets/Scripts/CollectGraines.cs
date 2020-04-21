using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGraines : MonoBehaviour
{
    public AudioSource collectSound;
    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        
        if (other.gameObject.tag == "Player1")
        {
            InventorySystemViolet.quantiteGraines += 1;
        }
        if (other.gameObject.tag == "Player2")
        {
            InventorySystemVert.quantiteGraines += 1;
        }
        if (other.gameObject.tag == "Player3")
        {
            InventorySystemRouge.quantiteGraines += 1;
        }
        if (other.gameObject.tag == "Player4")
        {
            InventorySystemBleu.quantiteGraines += 1;
        }
        Destroy(gameObject);
    }
}
