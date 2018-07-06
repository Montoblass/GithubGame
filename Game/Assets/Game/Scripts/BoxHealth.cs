using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : MonoBehaviour {


    public int health = 20;
  
    public int fallBoundary = -20;

    public GameObject DeathParticle;
    public GameObject ParticleSpawner; //position des objects woher die particle kommen wird für transform gebraucht sprich das object was stirbt hier rein (Name ungünstig gewählt)

    void Update()
    {
        if (transform.position.y <= fallBoundary)
            TakeDamage(999999);



    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            dead();
        }

    }

    public void dead()
    {
        Instantiate(DeathParticle, ParticleSpawner.transform.position, ParticleSpawner.transform.rotation);
        Destroy(this.gameObject);
        

    }

}