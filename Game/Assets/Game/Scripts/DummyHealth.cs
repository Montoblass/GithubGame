using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealth : MonoBehaviour {

    public int health;

    [System.Serializable]
    public class DummyStats
    {
        public int health = 20;
    }

    public DummyStats dummyStats = new DummyStats();

    public int fallBoundary = -20;

    void Update()
    {
        if (transform.position.y <= fallBoundary)
            DamageBox(999999);



    }


    public void TakeDamage(int damage)
    {
        health -= damage;

    }


    public void DamageBox(int damage)
    {
        dummyStats.health -= damage;
        if (dummyStats.health <= 0)
        {
            GameMaster.KillDummy(this);

        }

    }





}