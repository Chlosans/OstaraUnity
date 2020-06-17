using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SocketEvent;
using ChoicePasseur;

public class Activation : MonoBehaviour
{
    private ChoiceSulimo _testJson;
    public GameObject BulleFirst;
    public GameObject BullePasAssezGraines;
    public GameObject BullePasAssezCristaux;
    public GameObject MusiqueAmbiance;
    public GameObject Musiquepasseur;
    private bool firstTime = true;
    public GameObject SoundPasAssezCristauxPasseur;
    public GameObject SoundPasAssezGraines;

    void Start()
    {
        Debug.Log(firstTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (firstTime == true)
        {
            BulleFirst.SetActive(true);
            firstTime = false;
            Musiquepasseur.SetActive(true);
            MusiqueAmbiance.SetActive(false);
        }

        if (firstTime == false && Choix.choix == 1)
        {
            if (InventorySystemViolet.quantiteGraines != 3 || InventorySystemVert.quantiteGraines != 3 || InventorySystemRouge.quantiteGraines != 3 || InventorySystemBleu.quantiteGraines != 3)
            {
                Debug.Log("pas assez cristaux");
                BullePasAssezCristaux.AddComponent<BulleScriptPasAssezCristaux>();
                BullePasAssezCristaux.SetActive(true);
                SoundPasAssezCristauxPasseur.SetActive(true);
            }

        }

        if (firstTime == false && Choix.choix == 2)
        {
            if (InventorySystemViolet.quantiteGraines != 3 || InventorySystemVert.quantiteGraines != 3 || InventorySystemRouge.quantiteGraines != 3 || InventorySystemBleu.quantiteGraines != 3)
            {

                Debug.Log(" Pas assez de graines");
                BullePasAssezGraines.AddComponent<BulleScriptPasAssezGraines>();
                BullePasAssezGraines.SetActive(true);
                SoundPasAssezGraines.SetActive(true);
            }
        }

        if (firstTime == false && Choix.choix == 1 && InventorySystemViolet.quantiteCristaux == 3 && InventorySystemVert.quantiteCristaux == 3 && InventorySystemRouge.quantiteCristaux == 3 && InventorySystemBleu.quantiteCristaux == 3)
        {

            // Envoi du choix du Sulimo avec le passeur --> Voiture -> Impact bon
            _testJson = new ChoiceSulimo();
            _testJson.eventName = "directionDesert";
            _testJson.changementComponent = "voiture";

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            Debug.Log("Assez de cristaux");
            SceneManager.LoadScene(5);
        }

        if (firstTime == false && Choix.choix == 2 && InventorySystemViolet.quantiteFruits >= 3 && InventorySystemVert.quantiteFruits >= 3 && InventorySystemRouge.quantiteFruits >= 3 && InventorySystemBleu.quantiteFruits >= 3)
        {

            // Envoi du choix du Sulimo avec le passeur --> Rosalie -> Impact bon
            _testJson = new ChoiceSulimo();
            _testJson.eventName = "directionDesert";
            _testJson.changementComponent = "rosalie";

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

            Debug.Log("Assez de fruits");
            SceneManager.LoadScene(6);
        }
    }

}

[Serializable]
public class ChoiceSulimo
{
    public string eventName;
    public string changementComponent;
}