﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    // static = only one instance of this variable in the game
    public static int score = 1000;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Text gt = this.GetComponent<Text>();
	    gt.text = "High Score: " + score;
	}
}
