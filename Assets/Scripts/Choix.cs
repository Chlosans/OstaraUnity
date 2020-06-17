using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketEvent;
using System;

namespace ChoicePasseur
{
    public class Choix : MonoBehaviour
    {
        private ContainerConcertation _testJson;
        public static string voiture;
        public static string rosalie;
        public GameObject FumeeMoyen;
        public GameObject FumeeBeaucoup;
        public GameObject FumeeMoins;
        public GameObject ChoixDossier;
        public GameObject Bulle;
        public static int choix = 0;
        public GameObject MusiqueAmbiance;
        public GameObject Musiquepasseur;
        public GameObject Graines1;
        public GameObject Graines2;
        public GameObject Graines3;
        public GameObject Graines4;
        public GameObject Cristal1;
        public GameObject Cristal2;
        public GameObject Cristal3;
        public GameObject Cristal4;

        public static void Voiture(string data)
        {
            Debug.Log(data + " voiture ");
            voiture = data;
        }

        public static void Rosalie(string data)
        {
            Debug.Log(data + " rosalie ");
            rosalie = data;
        }

        public void ChoixCristaux()
        {
            FumeeMoyen.SetActive(false);
            FumeeBeaucoup.SetActive(true);
            ChoixDossier.SetActive(false);
            Bulle.SetActive(false);
            choix = 1;
            Musiquepasseur.SetActive(false);
            MusiqueAmbiance.SetActive(true);
            Cristal1.SetActive(true);
            Cristal2.SetActive(true);
            Cristal3.SetActive(true);
            Cristal4.SetActive(true);

            _testJson = new ContainerConcertation();
            _testJson.eventName = "secondPassage";
            _testJson.eventContainer = "le container concertation doit partir";

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

        }

        public void ChoixGraines()
        {
            FumeeMoyen.SetActive(false);
            FumeeMoins.SetActive(true);
            ChoixDossier.SetActive(false);
            Bulle.SetActive(false);
            choix = 2;
            Musiquepasseur.SetActive(false);
            MusiqueAmbiance.SetActive(true);
            Graines1.SetActive(true);
            Graines2.SetActive(true);
            Graines3.SetActive(true);
            Graines4.SetActive(true);

            _testJson = new ContainerConcertation();
            _testJson.eventName = "secondPassage";
            _testJson.eventContainer = "le container concertation doit partir";

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

        }

        void Update()
        {
            if (rosalie == "{\"data\":\"rosalie\"}")
            {
                Debug.Log("Bonjour Rosalie");
                ChoixGraines();
            }

            if (voiture == "{\"data\":\"voiture\"}")
            {
                Debug.Log("Bonjour Voiture");
                ChoixCristaux();
            }
        }
    }
}

[Serializable]
public class ContainerConcertation
{
    public string eventName;

    public string eventContainer;
}