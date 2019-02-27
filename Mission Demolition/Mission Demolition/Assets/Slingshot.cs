using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
    // class level variable
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    [Header("Set dynamically")]
    public GameObject launchPoint;

    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    private Rigidbody projectileRigidbody;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    } // end of Awake method

    void Update()
    {
        // if slingshot is not in aimingMode, don't run the code
        if (!aimingMode) return;        // bad code, bad
    }
    void OnMouseDown()
    {
        // the player has pressed the mouse button while over slingshot
        aimingMode = true;
        // instantiating a projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        // start it at the launchPoint
        projectile.transform.position = launchPos;
        // set it to isKinematic for now
        //projectile.GetComponent<Rigidbody>().isKinematic = true;
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }
	// Use this for initialization
	void OnMouseEnter ()
	{
	    //print("Slingshot:OnMouseEnter()");
	    launchPoint.SetActive(true);
	}
	
	// Update is called once per frame
	void OnMouseExit ()
	{
	    //print("Slingshot:OnMouseExit()");
	    launchPoint.SetActive(false);
	}
}
