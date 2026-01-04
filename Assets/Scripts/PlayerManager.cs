using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    Rigidbody2D rb;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    GroundCheck groundCheck;
    PlayerAudioController playerAudio;

    public TextMeshProUGUI guiHealth;
    public GameObject restartPopup;
    // Determines how long we wait before destorying the game object
    public int destroyTimer = 1;
    
    private ItemLife itemLife;
    
    
    public bool deathTriggered = false;


    public Vector2 movementDirection;
    public int movementSpeed = 5;
    public int jumpImpulse = 5;
    [HideInInspector] public bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        groundCheck = gameObject.GetComponent<GroundCheck>();
        itemLife = gameObject.GetComponent<ItemLife>();
        playerAudio = gameObject.GetComponent<PlayerAudioController>();
        
        restartPopup.SetActive(false);

    }

    // Update is called once per frame

    void Update()
    {
        //UI
        guiHealth.text = "HP: " + itemLife.health.ToString();

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

        playerAudio.PlayWalkingAudio(animator.GetBool("Run"));
        
        //death trigger
        if (itemLife.health <= 0 && !deathTriggered) {

            // Call the Death Animation
            animator.SetTrigger("Death");

            // Update the Death Trigger Boolean to stop looping
            deathTriggered = true;

            //play audio
            playerAudio.PlayDeathAudio();
            
            stopMovement();
            
            // Start a Timer to Destory the Game Object
            StartCoroutine(DeactivateOnDeath(destroyTimer));
            
        }
    }
    
    // Destory Timer - invoked with Couroutine in Update()
    IEnumerator DeactivateOnDeath(int timer) {
        
        // Wait before destorying
        yield return new WaitForSeconds(timer);
        
        //show popup
        restartPopup.SetActive(true);

        canMove = false;
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
        playerAudio.PlayAttackAudio();

    }

    void OnJump() {

        // Trigger the Jump Animation
        if (groundCheck.isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpImpulse);
            animator.SetTrigger("Jump");
            playerAudio.PlayJumpAudio();
        }
    }

    public void stopMovement()
    {
        GetComponent<PlayerInput>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
