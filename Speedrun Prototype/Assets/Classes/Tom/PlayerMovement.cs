using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    public float jumpStrenght;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody rb;
    private bool canJump;

    public void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Movement();
        Jump();
    }

    public void Movement ()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xInput, 0, zInput) * Time.deltaTime * movementSpeed);
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
