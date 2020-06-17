using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SocketEvent;

public class CollectGraines : MonoBehaviour
{
    public AudioSource collectSound;
    private CollectGrainePlayer _testJson;
    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();

        if (other.gameObject.tag == "Player4")
        {
            // add une graine au J4 -> envoie l'info à la manette 
            Debug.Log("Graine Ramasse");
            _testJson = new CollectGrainePlayer();
            _testJson.eventName = "collectGraine";
            _testJson.idPlayer = 4;
            _testJson.addGraine = 1;

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            InventorySystemViolet.quantiteGraines += 1;
        }
        if (other.gameObject.tag == "Player1")
        {
            // add une graine au J1 -> envoie l'info à la manette 
            _testJson = new CollectGrainePlayer();
            _testJson.eventName = "collectGraine";
            _testJson.idPlayer = 1;
            _testJson.addGraine = 1;

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            InventorySystemVert.quantiteGraines += 1;
        }
        if (other.gameObject.tag == "Player3")
        {
            // add une graine au J3 -> envoie l'info à la manette 
            _testJson = new CollectGrainePlayer();
            _testJson.eventName = "collectGraine";
            _testJson.idPlayer = 3;
            _testJson.addGraine = 1;

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            InventorySystemRouge.quantiteGraines += 1;
        }
        if (other.gameObject.tag == "Player2")
        {
            // add une graine au J2 -> envoie l'info à la manette 
            _testJson = new CollectGrainePlayer();
            _testJson.eventName = "collectGraine";
            _testJson.idPlayer = 2;
            _testJson.addGraine = 1;

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            InventorySystemBleu.quantiteGraines += 1;
        }
        Destroy(gameObject);
    }
}

[Serializable]
public class CollectGrainePlayer
{
    public string eventName;
    public int idPlayer;
    public int addGraine;
}