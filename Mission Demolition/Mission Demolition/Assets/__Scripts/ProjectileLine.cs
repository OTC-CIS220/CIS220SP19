using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    public static ProjectileLine S; // Singleton
    [Header("Set in Inspector")]
    private float minDist = 0.1f;
    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;

    /// <summary>
    /// poi property - has a getter to allow access of our poi
    /// to outsiders, and a setter to allow others to update the poi
    /// </summary>
    public GameObject poi {
        get {
            return _poi;
        }
        set
        {
            _poi = value;
            if (_poi != null)
            {
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
}

// Use this for initialization
	void Awake () {
        S = this;   // set the singleton to poi
        // get a reference to the line renderer
        line = GetComponent<LineRenderer>();
        // disable the line renderer until it is needed
        line.enabled = false;
        // initialize our points List
        points = new List<Vector3>();
	}  // end of Awake method

    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
        // This is called to add a point to the line
        Vector3 pt = _poi.transform.position;
        if (points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            return;
        }
        if (points.Count == 0 )
        {
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS;
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;
            // Sets the first two points
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            // enable our line renderer
            line.enabled = true;
        }  // end of if
        else
        {
            // normal behavior of adding a point
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;
        }  // end of else
    }  // end of AddPoint
    public Vector3 lastPoint
    {
        get
        {
            if (points == null) return Vector3.zero;
            return points[points.Count - 1];
        }
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (poi == null)
        {
            //if there is no poi, search for one
            if (FollowCam.POI != null)
            {
                if (FollowCam.POI.tag == "Projectile")
                {
                    poi = FollowCam.POI;
                }  // end of if
                else
                {
                    return; // nothing found
                }  // end of else
            }  // end of if
        }  // end of if
        // if there is a poi, it's loc is added every fixed update
        AddPoint();
        if (FollowCam.POI == null)
        {
            poi = null;
        }
	}  // end of FixedUpdate method
}
