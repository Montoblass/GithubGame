using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageDummy : MonoBehaviour {

    public Animator anim;

    public int health;  

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
           
        }
      
    }

    void Update()
    {
        if (health <= 0)
        {
          
        }
    }
}