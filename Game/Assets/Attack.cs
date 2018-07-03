using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Animator anim;

    public int meleeDamage;

    public KeyCode Attack1;
	// Use this for initialization
	void Start () {

      


    }
	
	// Update is called once per frame
	void Update () {
        //Melee attack
        if (Input.GetKeyDown(Attack1))
        {
            anim.SetTrigger("attack1");
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, 1.0f);
            if (hitObjects.Length <= 2)
            {
                hitObjects[2].SendMessage("TakeDamage", meleeDamage, SendMessageOptions.DontRequireReceiver);
                Debug.Log("hit" + hitObjects[2].name);
            }
        }
       
    }

  

}
