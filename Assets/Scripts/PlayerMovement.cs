using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    GroundCheck groundCheck;


    public Vector2 movementDirection;
    public int movementSpeed = 5;
    public int jumpImpulse = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        groundCheck = gameObject.GetComponent<GroundCheck>();

    }

    // Update is called once per frame

    void Update()
    {

        // Is the Player Moving?
        if (movementDirection != Vector2.zero)
        {
            // Is the Run animation set the False?
            if (animator.GetBool("Run") == false)
            {
                // Enable the Run Animation
                animator.SetBool("Run", true);

            }

            if (movementDirection.x < 0) { spriteRenderer.flipX = true; }
            else {
                spriteRenderer.flipX = false;
            }

        }
        // If the player is not moving - they're standing still
        else {
            // Disable the Run Animation
            animator.SetBool("Run", false);
        }
    }

    void FixedUpdate()
    {
            // Move the Player on the X axis only
            rb.linearVelocity = new Vector2((movementDirection.x * movementSpeed ), rb.linearVelocity.y);

    }

    void OnMove(InputValue movementValue)
    {
        // When user input is detected - update the movement variable
        movementDirection = movementValue.Get<Vector2>();
    }

    void OnFire() {
        // Trigger the Attack Animation
        animator.SetTrigger("Attack");

    }

    void OnJump() {

        // Trigger the Jump Animation
        if (groundCheck.isGrounded)
        {
            Debug.Log("Player has Jumped!");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpImpulse);
            animator.SetTrigger("Jump");
        }
    }
}
