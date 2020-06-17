using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SocketEvent;

public class CollectCristaux : MonoBehaviour
{
    public AudioSource collectSound;
    private CollectCristauxPlayer _testJson;
    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();

        if (other.gameObject.tag == "Player4")
        {
            // add un cristaux au J4 -> envoie l'info à la manette 
            _testJson = new CollectCristauxPlayer();
            _testJson.eventName = "collectCristaux";
            _testJson.idPlayer = 4;
            _testJson.addCristaux = 1;

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            InventorySystemViolet.quantiteCristaux += 1;
        }
        if (other.gameObject.tag == "Player1")
        {
            // add un cristaux au J1 -> envoie l'info à la manette 
            _testJson = new CollectCristauxPlayer();
            _testJson.eventName = "collectCristaux";
            _testJson.idPlayer = 1;
            _testJson.addCristaux = 1;

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            InventorySystemVert.quantiteCristaux += 1;
        }
        if (other.gameObject.tag == "Player3")
        {
            // add un cristaux au J3 -> envoie l'info à la manette 
            _testJson = new CollectCristauxPlayer();
            _testJson.eventName = "collectCristaux";
            _testJson.idPlayer = 3;
            _testJson.addCristaux = 1;

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            InventorySystemRouge.quantiteCristaux += 1;
        }
        if (other.gameObject.tag == "Player2")
        {

            // add un cristaux au J2 -> envoie l'info à la manette 
            _testJson = new CollectCristauxPlayer();
            _testJson.eventName = "collectCristaux";
            _testJson.idPlayer = 2;
            _testJson.addCristaux = 1;

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            InventorySystemBleu.quantiteCristaux += 1;
        }

        Destroy(gameObject);
    }
}

[Serializable]
public class CollectCristauxPlayer
{
    public string eventName;
    public int idPlayer;
    public int addCristaux;
}