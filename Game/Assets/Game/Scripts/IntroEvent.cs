using System.Collections;
using UnityEngine;

public class IntroEvent : MonoBehaviour {

    public GameObject leaves;
    public GameObject ParticleSpawner;

    void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(leaves, ParticleSpawner.transform.position, ParticleSpawner.transform.rotation);
        Debug.Log("Object is in trigger");
    }
   
}
