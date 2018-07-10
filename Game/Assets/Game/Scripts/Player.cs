using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

<<<<<<< HEAD

    [SerializeField]
    private PlayerStats Health;
=======
    [SerializeField]
    private Stat health;
>>>>>>> 5fce600adf14331ad3a361fcb623bab4d3841db2

    [System.Serializable]
    public class PlayerStats {
        public int Health = 100;
}

public PlayerStats playerStats = new PlayerStats();

public int fallBoundary = -30;

void Update () {
        health.MyCurrentValue = 10;
    if (transform.position.y <= fallBoundary)
        DamagePlayer (999999);
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue += 10;
        }
    }
   



public void DamagePlayer (int damage) {
    playerStats.Health -= damage;
    if (playerStats.Health <= 0) {
        GameMaster.KillPlayer(this);
    }

}


    


}
