using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{



  
    public GameObject thePlayer;

    public GameObject dollar;
    public float YPos = 2f;






    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == thePlayer)
        {
            StartCoroutine("StartDollar");
            //GameObject particles = Instantiate(dollar, thePlayer.transform.position);
            //particles.GetComponent<ParticleSystem>("dollar").Play();
            //particles.duration = 10.0f;

            Debug.Log("CoRoutineStarted");

        }

        Debug.Log("TriggerTriggered");
    }

    IEnumerator StartDollar()
    {
        GameObject particles = Instantiate(dollar, thePlayer.transform);
        Vector3 Pos = thePlayer.transform.position;
        Pos.y += YPos;
        particles.transform.position = Pos;
        particles.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(15);
        //particles.GetComponent<ParticleSystem>().Stop();
        //yield return new WaitForSeconds(5);
        GameObject.Destroy(particles);



    }





}

