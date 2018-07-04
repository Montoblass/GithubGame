using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealth : MonoBehaviour {

    [System.Serializable]
    public class DummyStats
    {
        public int Health = 100;
    }

    public DummyStats dummyStats = new DummyStats();

    public int fallBoundary = -20;

    void Update()
    {
        if (transform.position.y <= fallBoundary)
            DamageBox(999999);



    }



    public void DamageBox(int damage)
    {
        dummyStats.Health -= damage;
        if (dummyStats.Health <= 0)
        {
           
            GameMaster.KillDummy(this);
        }

    }





}
