﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    static public bool goalMet = false;
	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		// when the trigger is hit by something,
        // check to see if it is a projectile
        if (other.gameObject.tag == "Projectile")
        {
            // if so, set goalMet to tru
            Goal.goalMet = true;
            // also set the alpha of the color to a higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
	}
	
}
