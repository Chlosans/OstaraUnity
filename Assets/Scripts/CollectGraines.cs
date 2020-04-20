using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGraines : MonoBehaviour
{
    public AudioSource collectSound;
    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        InventorySystem.quantiteGraines += 1;
        Destroy(gameObject);
    }
}
