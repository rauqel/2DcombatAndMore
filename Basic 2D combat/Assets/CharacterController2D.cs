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
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(horizontal * walkSpeed, playerRB.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);
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