using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour {

    private Animator animator = null;


    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {




        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        animator.Play("dooropen");
    }


}
