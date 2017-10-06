using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public GameObject thisPlatform;
    public Vector3 platformTrans;
    public int disValue;
    public bool dirChange;
    public int moveSpeed;

    public virtual void Start () {
        thisPlatform = this.gameObject;
        platformTrans = thisPlatform.transform.position;
        dirChange = true;
    }


    public virtual void Moving () {
        if (dirChange == true) {
            thisPlatform.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
        } else {
            thisPlatform.transform.Translate (-Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (thisPlatform.transform.position.x >= platformTrans.x + disValue) {
            dirChange = false;
        }
        if (thisPlatform.transform.position.x <= platformTrans.x - disValue) {
            dirChange = true;
        }
    }
}
