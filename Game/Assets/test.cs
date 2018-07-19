using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public Collider2D attackTrigger;
    public Animator anim;
    private bool enter = true;

    public void CreateHitbox(int createhitbox)
    {
        attackTrigger.enabled = true;
    }

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
         anim = GetComponent<Animator>();

	}

    void OnTriggerEnter(Collider other)
    {
        anim.SetBool("enter", true);
        GetComponent<Animation>().Play();
    }
    void OnTriggerExit(Collider other)
    {
        anim.SetBool("enter", false);
    }
}
