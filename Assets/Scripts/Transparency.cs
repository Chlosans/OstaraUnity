using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
   public void Hide()
   {
      GameObject.Find("MenuParametres").transform.localScale = new Vector3(0, 0, 0);
      GameObject.Find("MenuPrincipal").transform.localScale = new Vector3(1, 1,1 );
   }
   
   public void Show()
   {
      GameObject.Find("MenuParametres").transform.localScale = new Vector3(1, 1, 1);
      GameObject.Find("MenuPrincipal").transform.localScale = new Vector3(0,0,0 );
   }
    
}
