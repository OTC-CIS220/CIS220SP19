using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountItHigher : MonoBehaviour {
    // class level variable
    private int _num = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(nextNum);
	}  // end of Update method

    public int nextNum
    {
        get
        {
            _num++;
            return (_num);
        }  // end of getter
    }  // end of nextNum property

    public int currentNum
    {
        get { return _num;}
        set { _num = value; }
    }  // end of currentNum property


}
