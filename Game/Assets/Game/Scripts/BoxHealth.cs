using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : MonoBehaviour {


    public int health = 20;
  
    public int fallBoundary = -20;

    void Update()
    {
        if (transform.position.y <= fallBoundary)
            Damage(999999);



    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }



    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameMaster.KillBox(this);
        }

    }



}