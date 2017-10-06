using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlatform : PlatformMovement {

    public override void Start () {

        base.Start ();

    }
    public void Update () {
        Moving ();
    }

    public override void Moving () {

        if (dirChange == true) {
            thisPlatform.transform.Translate (Vector3.up * moveSpeed * Time.deltaTime);
        } else {
            thisPlatform.transform.Translate (-Vector3.up * moveSpeed * Time.deltaTime);
        }

        if (thisPlatform.transform.position.y >= platformTrans.y + 2) {
            dirChange = false;
        }
        if (thisPlatform.transform.position.y <= platformTrans.y - 2) {
            dirChange = true;
        }
    }
}
