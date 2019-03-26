using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    public static ProjectileLine S; // Singleton
    [Header("Set in Inspector")] private float minDist = 0.1f;
    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;

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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
