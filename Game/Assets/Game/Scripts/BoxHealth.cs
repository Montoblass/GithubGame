using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : MonoBehaviour {


    public int health = 20;
  
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
            dead();
        }

    }

    public void dead()
    {
        Destroy(this.gameObject);

    }

}