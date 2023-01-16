using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    private float currentSpeed;

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;

    private float horizontal;
    private bool isFacingRight = true;

    private KeyCode jumpButton = KeyCode.Space;

    private void Start()
    {

    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
        Jump();
        SmoothMovement();
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(horizontal * currentSpeed, playerRB.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);
    }

    private void SmoothMovement()
    {
        if(playerRB.velocity.magnitude == 0)
        {
            currentSpeed = 0;
        }
        /*else
        {
            currentSpeed += Time.deltaTime;
        }*/
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("hey");
            currentSpeed += Time.deltaTime;
        }
        if(currentSpeed >= walkSpeed)
        {
            currentSpeed = walkSpeed;
        }

       // Debug.Log(currentSpeed);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpButton) && IsGrounded())
            playerRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}