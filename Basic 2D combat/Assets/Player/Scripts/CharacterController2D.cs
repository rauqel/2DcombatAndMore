using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("Movement")]
    private float currentSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpForce;

    [Header("Ground Check")]
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Key Codes")]
    private KeyCode jumpButton = KeyCode.Space;
    private KeyCode sprintButton = KeyCode.LeftShift;

    [Header("Conditions")]
    private bool isSprinting;

    private Animator anim;

    private float horizontal;
    private bool isFacingRight = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector2(horizontal * currentSpeed, playerRB.velocity.y);

        anim.SetFloat("PlayerVelocity", Mathf.Abs(playerRB.velocity.magnitude));
        anim.SetBool("isSprinting", isSprinting);

        Flip();
        Jump();
        Run();
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

    private void Run()
    {
        if (Input.GetKey(sprintButton) && IsGrounded())
            isSprinting = true;
        else
            isSprinting = false;


        //
        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
        }
        else
            currentSpeed = walkSpeed;
    }
}