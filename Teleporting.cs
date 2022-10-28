using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Teleporting : MonoBehaviour
{

    public Transform teleportTarget;
    public GameObject thePlayer;
    public GameObject Room;




    void OnTriggerEnter(Collider C)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
        if (Room.activeInHierarchy && C.gameObject == thePlayer)


        {
            StartCoroutine("TurnOff");
            //Room.SetActive(false);
            //Debug.Log("Active");

        }
    }
    IEnumerator TurnOff()
    {
        yield return new WaitForEndOfFrame();
        Room.SetActive(false);
    }
}
