using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    [System.Serializable]
    public class PlayerStats {
        public int Health = 100;
}

public PlayerStats playerStats = new PlayerStats();

public int fallBoundary = -30;

void Update () {
      
    if (transform.position.y <= fallBoundary)
        DamagePlayer (999999);
        if (Input.GetKeyDown(KeyCode.O))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
           
        }
    }
   



public void DamagePlayer (int damage) {
    playerStats.Health -= damage;
    if (playerStats.Health <= 0) {
        GameMaster.KillPlayer(this);
    }

}


    


}
