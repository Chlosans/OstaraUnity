using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public GameObject Bulle;
    public static bool player1=false;
    public static bool player2=false;
    public static bool player3=false;
    public static bool player4=false;

    private void OnTriggerEnter(Collider other)
    {
        Bulle.SetActive(true);
        if (other.gameObject.tag=="Player1" )
        {
            player1=true;
        }
        if (other.gameObject.tag=="Player2" )
        {
            player2=true;
        } 
        if (other.gameObject.tag=="Player3" )
        {
            player3=true;
        } 
        if (other.gameObject.tag=="Player4" )
        {
            player4=true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        Bulle.SetActive(false);
        if (other.gameObject.tag=="Player1" )
        {
            player1 =false;
        }
        if (other.gameObject.tag=="Player2" )
        {
            player2 =false;
        }
        if (other.gameObject.tag=="Player3" )
        {

            player3 =false;
        }
        if (other.gameObject.tag=="Player4" )
        {
            player4 =false;
        }    
    }
}
