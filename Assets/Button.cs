using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
   public int buttontype;
   public GameObject player;
   public void OnButtonPress(){

      player.GetComponent<player>().moveList.Add(buttontype);

      if (buttontype==5)
      {
          player.GetComponent<player>().startup=true;
      }
   }
}
