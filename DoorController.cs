using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
  public GameObject Door;
  Animator Animator ;
  bool Play;
  string Open = "Base Layer.Open";
  string Close = "Base Layer.Close";

    // Start is called before the first frame update
    void Start()
    {
      Animator = Door.GetComponent<Animator> ();
      if (Door.name == "Back Doors")
        {
          Open = "Base Layer.BD OPEN";
          Close = "Base Layer.BD CLOSE";
        }
    }
    void OnTriggerEnter(Collider other)

      {
        Animator.Play (Open,0,0);
        Debug.Log ("HitCollider");


      }
      void OnTriggerExit (Collider other)
    {


        Animator.Play (Close,0,0);
        Debug.Log ("HitCollider");

      }




}
