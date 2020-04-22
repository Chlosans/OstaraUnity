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
    
    //fonction à faire : si il y a une partie enregistrée dans la bdd mettre le bouton continuer en non disabled
    
    //fonction à faire : si le user appuie sur continuer la partie -> mettre la variable globale "continuerPartie" à true et appeler la fonction ConnectManette()
    
   


}
