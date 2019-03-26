using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionDemolition : MonoBehaviour {
    public enum GameMode
    {
        idle,
        playing,
        levelEnd
    }
    static private MissionDemolition S; // a private singleton
    [Header("Set in Inspector")]
    public Text uitLevel;       // text_level text
    public Text uitShots;       // the shots text
    public Text uitButton;      // the text on the ui button
    public Vector3 castlePos;   // the place to put castles
    public GameObject[] castles; // all the castles
    [Header("Set dynamically")]
    public int level;           // level of current play
    public int levelMax;        // the number of levels
    public int shotsTaken;
    public GameObject castle;   // current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot"; // FollowCam mode
	// Use this for initialization
	void Start () {
        S = this;

        level = 0;
        levelMax = castles.Length;
        StartLevel();
	}
	
    void StartLevel()
    {
        // get rid of any old castles
        if (castle != null)
        {
            Destroy(castle);
        }  // end of if
        // destroy old projectiles
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }  // end of foreach

        // instantiate the new castle
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;

        // reset the camera
        SwitchView("Show Both");
        ProjectileLine.S.Clear();

        // reset the goal
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }  // end of StartLevel

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }
	// Update is called once per frame
	void Update () {
        UpdateGUI();
        // check for level end
        if (( mode == GameMode.levelEnd) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            SwitchView("Show Both");
            // start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }  // end of if
	}  // end of Update method

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }  // end of if
        StartLevel();
    }  // end of NextLevel method

    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitButton.text;
        } // end of if
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;

            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;

            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        } // end of switch
    } // end of SwitchView method

    // static method that allows code anywhere to increment shotsTaken
    public static void ShotFired()
    {
        S.shotsTaken++;
    }
}
