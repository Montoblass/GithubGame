using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealth : MonoBehaviour {



    public int health = 1;

    public Animator deathanim;

    public int fallBoundary = -20;

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
            deathanim.SetBool("death", true);
            Destroy(gameObject, 0.46f);
        }

    }

   

}