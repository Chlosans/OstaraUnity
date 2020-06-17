using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketEvent;
using System;

public class Jardinage : MonoBehaviour
{
    private AfficheButton _testJson;
    public GameObject Planter;
    public GameObject Pluie;
    public GameObject BoutonsPluie;
    public static bool clickPlanter1 = false;
    public static bool clickPlanter2 = false;
    public static bool clickPlanter3 = false;
    public static bool clickPlanter4 = false;
    public static bool clickPluie1 = false;
    public static bool clickPluie2 = false;
    public static bool clickPluie3 = false;
    public static bool clickPluie4 = false;
    public static bool clickRam1 = false;
    public static bool clickRam2 = false;
    public static bool clickRam3 = false;
    public static bool clickRam4 = false;
    public static bool firstGraine = true;
    public static bool firstPluie = true;
    public static string clickPluie;
    public GameObject Ramasser;
    public static Vector3 Player1Position;
    public GameObject Fruitier1;
    public GameObject Fruitier2;
    public GameObject Fruitier3;
    public GameObject Fruitier4;

    public static void PluieButton(string data)
    {
        Debug.Log("Bonjour Pluie");
        clickPluie = data;
    }

    public void HaveclickPlanter1()
    {
        clickPlanter1 = true;
    }
    public void HaveclickPlanter2()
    {
        clickPlanter2 = true;
    }
    public void HaveclickPlanter3()
    {
        clickPlanter3 = true;
    }
    public void HaveclickPlanter4()
    {
        clickPlanter4 = true;
    }

    public void HaveclickPluie1()
    {
        clickPluie1 = true;
    }
    public void HaveclickPluie2()
    {
        clickPluie2 = true;
    }
    public void HaveclickPluie3()
    {
        clickPluie3 = true;
    }
    public void HaveclickPluie4()
    {
        clickPluie4 = true;
    }

    public void HaveclickRam1()
    {
        clickRam1 = true;
    }
    public void HaveclickRam2()
    {
        clickRam2 = true;
    }
    public void HaveclickRam3()
    {
        clickRam3 = true;
    }
    public void HaveclickRam4()
    {
        clickRam4 = true;
    }

    IEnumerator PlayAnimPluie()
    {

        Pluie.SetActive(true);
        Fruitier1.SetActive(true);
        yield return new WaitForSeconds(15);
        Pluie.SetActive(false);

        // Affiche Button Recolte Fruit sur la manette des joueurs
        _testJson = new AfficheButton();
        _testJson.eventName = "afficheContainerRecolte";
        _testJson.eventContainer = true;

        SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

    }

    void Update()
    {

        // réception click ButtonPlanter des joueurs
        if (firstGraine == true)
        {
            if (InventorySystemViolet.quantiteGraines == 3 && InventorySystemVert.quantiteGraines == 3 && InventorySystemRouge.quantiteGraines == 3 && InventorySystemBleu.quantiteGraines == 3)
            {
                // Affiche Bouton Planter
                _testJson = new AfficheButton();
                _testJson.eventName = "afficheContainerPlanter";
                _testJson.eventContainer = true;

                SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));

                firstGraine = false;
            }
        }

        // réception click ButtonPluie des joueurs
        if (firstPluie == true)
        {
            Debug.Log("clickPluie : / " + clickPluie);
            if (clickPluie == "{\"data\":\"clickPluie\"}")
            {
                Debug.Log("if ClickPluie");
                // Appelle la fonction animation Pluie
                BoutonsPluie.SetActive(false);
                StartCoroutine(PlayAnimPluie());
                firstPluie = false;
            }
        }

    }

}

[Serializable]
public class AfficheButton
{
    public string eventName;
    public bool eventContainer;
}