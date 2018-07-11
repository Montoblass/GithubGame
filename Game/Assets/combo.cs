using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public Collider2D attackTrigger;

    public Animator anim;//You may not need an animator, but if so declare it here   

    int noOfClicks; //Determines Which Animation Will Play
    bool canClick; //Locks ability to click during animation event



    public void CreateHitbox(int createhitbox)
    {
        attackTrigger.enabled = true;
    }


    public void DestroyHitbox(int destroyhitbox)
    {
        attackTrigger.enabled = false;
    }


    void Start()
    {
        //Initialize appropriate components
        anim = GetComponent<Animator>();

        noOfClicks = 0;
        canClick = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { ComboStarter(); }
    }

    void ComboStarter()
    {
        if (canClick)
        {
            noOfClicks++;
        }

        if (noOfClicks == 1)
        {
            anim.SetInteger("animation", 31);
        }
    }

    public void ComboCheck()
    {

        canClick = false;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("knightattack1") && noOfClicks == 1)
        {//If the first animation is still playing and only 1 click has happened, return to idle
            anim.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("knightattack1") && noOfClicks >= 2)
        {//If the first animation is still playing and at least 2 clicks have happened, continue the combo          
            anim.SetInteger("animation", 33);
            canClick = true;
        }
      
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("knightattack2"))
        { //Since this is the third and last animation, return to idle          
            anim.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }
    }
}
