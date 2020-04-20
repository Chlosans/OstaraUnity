using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MannetteIsConnected : MonoBehaviour
{
    //si continuerPartie = false et les 4 personnages sont connectés
    public void PlayCinematicIntro()
    {
            SceneManager.LoadScene("CinematiqueIntro");
    }
    
    //si continuerPartie = true et les 4 personnages sont connectés-> charger la partie sauvegardée 

}
