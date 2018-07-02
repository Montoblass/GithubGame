﻿using System.Collections;
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
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z*-1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < backgrounds.Length; i++)  {
            // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // set a target x position which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // create a target position which is the backgrounds current position with its target x position
            Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // fade between current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // set the previousCamPos to the cameras position at the end of the frame
        previousCamPos = cam.position;
	}
}
