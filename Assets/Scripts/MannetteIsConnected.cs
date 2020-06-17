using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SocketEvent;


public class MannetteIsConnected : MonoBehaviour
{

    private Video _testJson;

    //si continuerPartie = false et les 4 personnages sont connectés
    public void PlayCinematicIntro()
    {
        _testJson = new Video();
        _testJson.eventName = "videoMobilePlay";
        _testJson.activeVideo = "active";

        SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

        SceneManager.LoadScene("CinematiqueIntro");
    }

    //si continuerPartie = true et les 4 personnages sont connectés-> charger la partie sauvegardée 

}

[Serializable]
public class Video
{
    public string eventName;
    public string activeVideo;
}
