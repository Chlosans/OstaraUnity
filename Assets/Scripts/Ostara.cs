using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ChoicePasseur;
public class Ostara : MonoBehaviour
{

    public static string choice;

    public static void Choice(string data)
    {
        Debug.Log(data);
        choice = data;
    }
    public void GoodOrBad()
    {
        // récpetion choix des joueurs Obstacle 1 pour lancer tel ou tel cinématique désert (Rosalie/Voiture)
        if (choice == "{\"data\":\"voiture\"}")
        {
            SceneManager.LoadScene(9);
        }
        if (choice == "{\"data\":\"rosalie\"}")
        {
            SceneManager.LoadScene(8);
        }
    }
}
