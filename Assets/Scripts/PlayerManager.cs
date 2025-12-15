using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float playerSpeed = 1;
    private Animator animator;


    public PlayerAudioController playerAudio;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer playerSR;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        playerSR = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        animator.SetBool("walking", movement != Vector2.zero ? true : false);
        playerAudio.PlayWalkingAudio(animator.GetBool("walking"));

        if (movement.x > 0)
            playerSR.flipX = false;
        else if (movement.x < 0)
            playerSR.flipX = true;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * playerSpeed * Time.fixedDeltaTime));
    }

    void OnMove(InputValue movePosition)
    {
        movement = movePosition.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("Attack");
        playerAudio.PlayAttackAudio();
    }
}