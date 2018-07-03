using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Animator anim;

    public int meleeDamage;
    public float meleeRange;
    public KeyCode Stance1;
    public Transform meleeHitPoint;

    public KeyCode Attack1;
	// Use this for initialization
	void Start () {

      


    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(Stance1))
        {



            //Melee attack
            if (Input.GetKeyDown(Attack1))
            {
                anim.SetTrigger("attack1");
                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleeHitPoint.position, meleeRange);
                if (hitObjects.Length > 2)
                {
                    hitObjects[1].SendMessage("TakeDamage", meleeDamage, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("hit" + hitObjects[1].name);
                }
            }

        }
       
    }

  

}
