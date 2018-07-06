using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {


    public Animator anim;

    private bool attack1 = false;

    private float attackTimer = 0;

    private float attackCd = 0.3f;

    public Collider2D attackTrigger;



    public KeyCode Stance1;
    
    public KeyCode Attack1;


	// Use this for initialization
	void Awake ()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;    
    }

    void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetKey(Stance1))
        {



            //Melee attack
            if (Input.GetKeyDown(Attack1) && !attack1)
            {

                attack1 = true;
                attackTimer = attackCd;
                attackTrigger.enabled = true;

            }



            if (attack1)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    attack1 = false;
                    attackTrigger.enabled = false;
                }
            }

            anim.SetBool("attack1", attack1);


        }

        else
        {
            attackTrigger.enabled = false;
        }
    }


  

}
