using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : MonoBehaviour {


    [System.Serializable]
    public class BoxStats
    {
        public int Health = 100;
    }

    public BoxStats boxStats = new BoxStats();

    public int fallBoundary = -20;

    void Update()
    {
        if (transform.position.y <= fallBoundary)
            DamageBox(999999);



    }



    public void DamageBox(int damage)
    {
        boxStats.Health -= damage;
        if (boxStats.Health <= 0)
        {
            GameMaster.KillBox(this);
        }

    }





}
