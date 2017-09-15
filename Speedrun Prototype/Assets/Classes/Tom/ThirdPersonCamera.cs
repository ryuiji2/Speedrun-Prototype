using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    private float distanceFromTarget = 5;
    public Vector2 distanceMinMax = new Vector2(1f, 10f);

    public float mouseSensitivity = 5;

    private float yRotation;
    private float xRotation;
    public Vector2 xRotMinMax = new Vector2(-5, 85);

    private float scrollwheel;

    public float rotationSmoothTime = .12f;
    private Vector3 rotationSmoothVelocity;
    private Vector3 currentRotation;

    // Is LateUpdate to be sure target.position is set so the camera is moved to the correct position
    private void LateUpdate()
    {
        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, xRotMinMax.x, xRotMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(xRotation, yRotation), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        // Allows the user to zoom in and out
        scrollwheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollwheel < 0)
        {
            distanceFromTarget++;
        }
        else if (scrollwheel > 0)
        {
            distanceFromTarget--;
        }
        distanceFromTarget = Mathf.Clamp(distanceFromTarget, distanceMinMax.x, distanceMinMax.y);

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
