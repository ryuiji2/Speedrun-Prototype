using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {
    
    public GameObject thisPlatform;
    public bool rightDir;
    public int moveSpeed;

    public virtual void Start ()
    {
        thisPlatform = this.gameObject;
        rightDir = true;
    }


    public virtual void Moving ()
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
