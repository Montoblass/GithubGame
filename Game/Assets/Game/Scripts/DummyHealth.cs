using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealth : MonoBehaviour {

    public Animator anim;

    public int health = 1;

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
            GameMaster.KillDummy(this);
        }

    }



}