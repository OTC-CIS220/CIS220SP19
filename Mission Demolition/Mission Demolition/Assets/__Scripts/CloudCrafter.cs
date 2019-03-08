using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int numClouds = 40;          // the # of clouds to make
    public GameObject cloudPrefab;      // cloud prefab
    public Vector3 cloudPosMin = new Vector3(-50, -5, 10);
    public Vector3 cloudPosMax = new Vector3(150, 100, 10);
    public Vector3 zeroVal = new Vector3(0, 0, 0);
    public Vector3 oneVal = new Vector3(1, 1, 1);
    public float cloudScaleMin = .25f;
    public float cloudScaleMax = 1f;
    public float cloudSpeedMult = 0.5f;

    public GameObject[] cloudInstances;

    // Use this for initialization
    void Awake()
    {
        // make an array large enough to hold all our cloud instances
        cloudInstances = new GameObject[numClouds];
        // find the cloudAnchor parent GameObject
        GameObject anchor = GameObject.Find("CloudAnchor");
        // iterate through and make cloud instances
        for (int i = 0; i < numClouds; i++)
        {
            // make an instance of our cloud prefab
            GameObject cloud = Instantiate<GameObject>(cloudPrefab);
            // position cloud
            Vector3 cPos = zeroVal;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            // scale cloud
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);
            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
            // smaller clouds should be further away
            cPos.z = 100 - 90 * scaleU;
            // apply these transforms to the cloud
            cloud.transform.position = cPos;
            cloud.transform.localScale = oneVal * scaleVal;
            // make cloud a child of the anchor
            cloud.transform.SetParent(anchor.transform);
            cloudInstances[i] = cloud;

        }  // end of for loop
    }

    // Update is called once per frame
    void Update()
    {
        // Iterate over each cloud that was created
        foreach (GameObject cloud in cloudInstances)
        {
            // get the cloud scale and position
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            // move larger clouds faster
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            // if a cloud has moved too far to the left
            if (cPos.x <= cloudPosMin.x)
            {
                cPos.x = cloudPosMax.x;
            }

            cloud.transform.position = cPos;
        }
    }
}
