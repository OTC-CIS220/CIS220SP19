using System.Collections;               // using statements - allow us to access pre existing code lib
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// the class statement declares the class
/// this class name is Enemy
/// it inherits from the Unity class MonoBehavior
/// </summary>
public class Enemy : MonoBehaviour {
    // variables that are global to our class
    // class variables or instance variables
    public float speed = 10f;       // milliseconds
    public float fireRate = 0.3f;   // shots/second 

	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public virtual void Move()
    {
        Vector3 tempPos = pos;      // executes the getter
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;              // executes the setter
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject other = coll.gameObject;
        switch (other.tag)
        {
            case "Hero":
                break;
            case "HeroLaser":
                Destroy(this.gameObject);
                break;
        }
    }
    /// <summary>
    /// property - method that works like a field
    /// if we use it on the right hand side of an equals sign
    /// we run the getter;
    /// left hand side, run the setter
    /// </summary>
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }
}
