using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public AudioSource music;

    public float movementSpeed = 10f;
    public float rotateSpeed = 3f;

    public Transform cameraTarget;

    public float jumpStrenght;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody rb;
    private int numberJumps = 2;

    public void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        numberJumps = 2;
    }

    public void Update()
    {
        Movement();
        Jump();
    }

    public void LateUpdate()
    {
        float targetRotation = cameraTarget.eulerAngles.y;
        transform.eulerAngles = Vector3.up * targetRotation;
    }

    public void Movement ()
    {
        Vector2 keyInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (keyInput != Vector2.zero)
        {
            transform.Translate(new Vector3(keyInput.x, 0f, keyInput.y) * Time.deltaTime * movementSpeed);
            if (numberJumps == 2)
                if (!anim.GetBool("Run"))
                    anim.SetBool("Run", true);
            Music();
        }
        else
        {
            anim.SetBool("Run", false);
            music.Pause();
        }
    }

    public void Music ()
    {
        if (!music.isPlaying)
        {
            music.Play();
        }
        else music.UnPause();
    }

    public void Jump ()
    {
        if (Input.GetButtonDown("Jump") && numberJumps >= 1)
        {
            numberJumps--;
            rb.velocity += new Vector3(0, jumpStrenght, 0);
            anim.SetTrigger("Jump");
        }
        
        if(rb.velocity.y < 0)
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 &&  !Input.GetButton("Jump"))
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platform")
            numberJumps = 2;
    }

    public void EndRun ()
    {
        print("Stopped!");
    }
}
