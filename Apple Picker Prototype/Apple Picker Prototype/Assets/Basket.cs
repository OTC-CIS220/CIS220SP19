using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

	// Use this for initialization
	void Start ()
	{
        // find a reference to the ScoreCounter
	    GameObject scoreGO = GameObject.Find("ScoreCounter");
        // get the text component from the GameObject
	    scoreGT = scoreGO.GetComponent<Text>();
        // set the starting number of points to 0
	    scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        // get the current screen pos of mouse
        Vector3 mousePos2D = Input.mousePosition;
        //mousePos2D.z = -Camera.main.transform.position.z;

        // convert the point from 2D screen space into 3D game world space

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        // move the x position of the Basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            // parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            // add points for catching an Apple
            score += 100;
            // convert the score back to a string and display it
            scoreGT.text = score.ToString();

            // track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
