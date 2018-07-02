using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds;         // array (list) of all the back and foreground to be parallaxed
    private float[] parallaxScales;         // the proportion of the cameras movement to move the background by
    public float smoothing = 1f;            // how smooth the parallax is going to be. keep above 0

    private Transform cam;                  // refrence to main camera transform
    private Vector3 previousCamPos;         // the position of the camera in the previous frame

    // is called before Start(). Great for references.
    private void Awake() {
        // set up the reference
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start () {
        // the previous frame had the current frames cameras position
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length)
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
