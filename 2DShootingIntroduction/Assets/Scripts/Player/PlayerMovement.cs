using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody2D rigBody;
    public float jumpSpeed = 3f, moveSpeed = 2f;
    public bool isGrounded, facingRight;
    public LayerMask groundLayers;
    RaycastHit2D hit;


    // Update is called once per frame
    void FixedUpdate()
    {
        GroundDetection();
        Move();
    }

    public void GroundDetection()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayers);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void Move()
    {
        if (joystick.Vertical > 0.4f && isGrounded)
        {
            rigBody.velocity = new Vector2(rigBody.velocity.x, jumpSpeed);
        }
        if (joystick.Horizontal > 0)
        {
            rigBody.velocity = new Vector2(moveSpeed, rigBody.velocity.y);
            if (!facingRight)
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            facingRight = true;
        }
        if (joystick.Horizontal < 0)
        {
            rigBody.velocity = new Vector2(-moveSpeed, rigBody.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            facingRight = false;
        }
    }
}
