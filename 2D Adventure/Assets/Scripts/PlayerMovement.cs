using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 200;
    [SerializeField] private float runSpeed = 400;
    [SerializeField] private float jumpForce = 300;

    private bool isRunning = false;
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
    }

    public void Jump()
    {
        rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
