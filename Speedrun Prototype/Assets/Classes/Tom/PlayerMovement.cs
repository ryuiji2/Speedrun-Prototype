using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float rotateSpeed = 3f;

    public Transform cameraTarget;
    private bool detectInput;

    public float jumpStrenght;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody rb;
    private bool canJump;

    public void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Movement();
        Jump();
    }

    public void LateUpdate()
    {
        if(detectInput)
        {
            float targetRotation = cameraTarget.eulerAngles.y;
            transform.eulerAngles = Vector3.up * targetRotation;
        }
    }

    public void Movement ()
    {
        Vector2 keyInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (keyInput != Vector2.zero)
        {
            if (Input.GetButton("Fire2"))
            {
                detectInput = true;
                transform.Translate(new Vector3(keyInput.x, 0f, keyInput.y) * Time.deltaTime * movementSpeed);
            }
            else
            {
                detectInput = false;
                transform.Translate(new Vector3(0f, 0f, keyInput.y) * Time.deltaTime * movementSpeed);
                transform.Rotate(new Vector3(0f, keyInput.x, 0f) * rotateSpeed);
            }
        }
        else
        {
            detectInput = false;
        }
    }

    public void Jump ()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.velocity += new Vector3(0, jumpStrenght, 0);
            canJump = false;
        }
        
        if(rb.velocity.y < 0)
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 &&  !Input.GetButton("Jump"))
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platform" && canJump == false)
            canJump = true;
    }
}
