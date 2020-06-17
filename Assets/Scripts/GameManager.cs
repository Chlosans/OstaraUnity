using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dictionary;
using SocketEvent;

// Dictionnaire pour recevoir l'inventaire des joueurs
public class GameManager : Singleton<GameManager>
{
    public int sendPlayer;
    public int quantiteCristaux;
    public int quantiteGraines;
    public int quantiteFruits;
    public int idPlayer;
    void Update()
    {
        Client.UpdateGlobalData();
    }
}
