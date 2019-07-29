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
    [SerializeField]
    private int pointsGained = 0;
    [SerializeField]
    private float minX = -9.5f, maxX = 9.5f;


    // Update is called once per frame
    void FixedUpdate()
    {
        GroundDetection();
        Move();
    }
    private void Update()
    {
        CheckBoundaries();
    }

    private void GroundDetection()
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

    private void CheckBoundaries()
    {
        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
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

    public void AddPoints(int point)
    {
        pointsGained += point;
    }
}
