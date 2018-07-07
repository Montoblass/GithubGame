using System.Collections;
using UnityEngine;

public class IntroEvent : MonoBehaviour
{

    public GameObject leaves;
    GameObject leavestormClone;
    public GameObject ParticleSpawner;
    bool Timer = false;
    private float _timer = 1f;
    public float EventLänge = 3f;
     

    void OnTriggerEnter2D(Collider2D col)
    {
       
       if (!Timer) Timer = true;
        Debug.Log("Object is in trigger");
    }

    void Update()
    {
        if (Timer)
        {
            _timer += Time.deltaTime;
 
            Debug.Log("Timer started");
        }
        if (_timer >= EventLänge)
        {
            Instantiate(leaves, ParticleSpawner.transform.position, ParticleSpawner.transform.rotation);
            this.enabled = false;
            enabled = false;
            Debug.Log("Timer ended");
        }
    }
       
        
    }

