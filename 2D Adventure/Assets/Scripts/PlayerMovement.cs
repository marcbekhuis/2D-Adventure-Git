using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 200;
    [SerializeField] private float runSpeed = 400;
    [SerializeField] private float jumpForce = 300;
    [SerializeField] private PlayerMovementStates playerMovementStates;
    [Space]
    [Header("Ground check")]
    [SerializeField] private Vector2 groundCheckPosition;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundCheckLayers;

    private bool isRunning = false;
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckPlayerMovementState();
    }

    public void Running(bool state)
    {
        isRunning = state;
    }

    public void Move(float axis)
    {
        if (isRunning)
        {
            rigidbody2D.velocity = new Vector2(axis * runSpeed, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(axis * walkSpeed, rigidbody2D.velocity.y);
        }
        if (rigidbody2D.velocity.x < 0)
        {
            this.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Jump()
    {
        if (playerMovementStates != PlayerMovementStates.Jumping && playerMovementStates != PlayerMovementStates.Falling)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + (Vector3)groundCheckPosition, groundCheckSize);
    }

    enum PlayerMovementStates
    {
        Standing,
        Walking,
        Running,
        Jumping,
        Falling
    }

    private void CheckPlayerMovementState()
    {
        if (Physics2D.OverlapBox((Vector2)transform.position + groundCheckPosition, groundCheckSize, 0, groundCheckLayers))
        {
            if (rigidbody2D.velocity.x == 0)
            {
                playerMovementStates = PlayerMovementStates.Standing;
            }
            else if (rigidbody2D.velocity.x > walkSpeed || rigidbody2D.velocity.x < -walkSpeed)
            {
                playerMovementStates = PlayerMovementStates.Running;
            }
            else
            {
                playerMovementStates = PlayerMovementStates.Walking;
            }
        }
        else
        {
            if (rigidbody2D.velocity.y >= 0)
            {
                playerMovementStates = PlayerMovementStates.Jumping;
            }
            else
            {
                playerMovementStates = PlayerMovementStates.Falling;
            }
        }
    }
}
