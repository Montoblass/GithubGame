using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    public Animator anim;

    private void Start()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;

    public IEnumerator RespawnPlayer() {
        yield return new WaitForSeconds(spawnDelay);


        Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("TODO: Add Spawn Particles");


    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }


    public static void KillBox (BoxHealth box)
    {
        Destroy(box.gameObject);
       
    }

    public void KillDummy(DummyHealth dummy)
    {

        anim.SetTrigger("death");

    }


}
