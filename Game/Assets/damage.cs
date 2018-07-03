using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour {

    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
