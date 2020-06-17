using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;
using SocketEvent;

namespace verifConnexion
{
    public class Connexion : MonoBehaviour
    {
        private TestJson _testJson;
        public Text codeText;
        private int codeRamdon1;
        private int codeRamdon2;
        private int codeRamdon3;
        private int codeRamdon4;
        private int codeRamdonglobal;
        public GameObject ImgPerso1;
        public GameObject ImgPerso2;
        public GameObject ImgPerso3;
        public GameObject ImgPerso4;
        public GameObject bouton;
        public static string player;


        private void Start()
        {

            codeRamdon1 = UnityEngine.Random.Range(1, 9);
            codeRamdon2 = UnityEngine.Random.Range(1, 9);
            codeRamdon3 = UnityEngine.Random.Range(1, 9);
            codeRamdon4 = UnityEngine.Random.Range(1, 9);
            codeText.text = "" + codeRamdon1 + " " + codeRamdon2 + " " + codeRamdon3 + " " + codeRamdon4;

            codeRamdonglobal = int.Parse(codeRamdon1.ToString() + codeRamdon2.ToString() + codeRamdon3.ToString() +
                                         codeRamdon4.ToString());

            // envoi le code de connexion au serveur
            _testJson = new TestJson();
            _testJson.eventName = "codeRandom";
            _testJson.codeUnity = codeRamdonglobal;

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

        }

        public static void ConnexionVerif(string data)
        {
            //Debug.Log(data);
            player = data;
        }

        public void Update()
        {
            // comparaison des données idJoueur reçu pour afficher le perso à l'écran Connexion

            if (player == "{\"data\":1}")
            {
                ImgPerso1.SetActive(true);
            }
            if (player == "{\"data\":2}")
            {
                ImgPerso2.SetActive(true);
            }
            if (player == "{\"data\":3}")
            {
                ImgPerso3.SetActive(true);
            }
            if (player == "{\"data\":4}")
            {
                ImgPerso4.SetActive(true);
                bouton.SetActive(true);
            }
        }

    }

}

[Serializable]
public class TestJson
{
    public string eventName;
    public int codeUnity;
}