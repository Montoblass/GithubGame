using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stance : MonoBehaviour {

    public Animator anim;

    public KeyCode Stance1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(Stance1))

            anim.SetTrigger("Stance");

	}

}
