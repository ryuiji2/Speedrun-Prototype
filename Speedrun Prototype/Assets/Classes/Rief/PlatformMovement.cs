using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformMovement : MonoBehaviour {
    
    public GameObject thisPlatform;
    public bool rightDir;
    public int moveSpeed;

	void Start () {
    }
	
	void Update () {
        Moving ();
	}

    void Moving ()
    {   
        if(rightDir == true)
        {
            thisPlatform.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            thisPlatform.transform.Translate (-Vector3.right * moveSpeed * Time.deltaTime);
        }
        if(thisPlatform.transform.position.x >= 2)
        {
            rightDir = false;
        }
        if(thisPlatform.transform.position.x <= -2)
        {
            rightDir = true;
        }
    }
}
