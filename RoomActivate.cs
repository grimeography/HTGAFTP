using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActivate : MonoBehaviour


{

    public GameObject Room;
    public GameObject thePlayer;

      void OnTriggerEnter(Collider C)
    {
        
        if (!Room.activeInHierarchy && C.gameObject == thePlayer)


        {
            Room.SetActive(true);
            Debug.Log("Active");
     
        }
    }


}
