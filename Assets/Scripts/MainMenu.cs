using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private bool continuerPartie = false;

    public void ConnectManette()
    {
       SceneManager.LoadScene("Connexion");
       
    }
    

}
