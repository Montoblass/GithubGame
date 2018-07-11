using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{



    public Animator anim;

    public Animation animation;

    private bool attack1 = false;

    private bool attack2 = false;

    private float attackTimer = 0;

    private float attackCd = 0.3f;

    public Collider2D attackTrigger;

    public KeyCode Attack1;






    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }




    public void CreateHitbox(int createhitbox)
    {
        attackTrigger.enabled = true;
    }


    public void DestroyHitbox(int destroyhitbox)
    {
        attackTrigger.enabled = false;
    }




    // Update is called once per frame
    public void Update()
    {



        //Melee attack
        if (Input.GetKeyDown(Attack1) && !attack1)
        {

            attack1 = true;
            attackTimer = attackCd;

        }


        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("attack1") &&
           anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f))
        {

            attackTimer -= Time.deltaTime;
            anim.SetBool("attack2", true);


        }
        else
        {
            attack1 = false;

        }

        if (Input.GetKeyDown(Attack1) && attackTimer > 0)
        {
            TransitionToAttack2Combo();
        }



        if (Input.GetKeyUp(Attack1))
        {
            attack1 = false;
        }



        anim.SetBool("attack1", attack1);

        if (attack2)
        {
            attack1 = false;
        }

    }



    void TransitionToAttack2Combo()
    {
        attack2 = true;
    }
}
  














