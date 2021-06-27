using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    public float groundCheckDistance = 0.7f;

    private float horizontal;
    private Rigidbody player;
    private bool isGround;

    // TEMP
    public Transform enemy;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        isGround = true;
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if(Physics.Raycast(transform.position, transform.up * -1, groundCheckDistance))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if(transform.position.x >= enemy.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }


    }


    private void FixedUpdate()
    {
        var moveSpeed = movementSpeed * Time.fixedDeltaTime * horizontal;

        player.velocity = new Vector3(moveSpeed, player.velocity.y, player.velocity.z);
    }

    void Jump()
    {
        if (isGround)
        {
            player.AddForce(transform.up * jumpSpeed);
        }
            
    }
}
