using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    public float groundCheckDistance = 0.7f;

    public float fallDownMultiplier = 1.5f;

    private float horizontal;
    private Rigidbody player;
    private bool isGround;
    private PlayerAnimations anim;

    // TEMP
    public Transform enemy;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerAnimations>();
        isGround = true;
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        anim.setYVelocity(player.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Punch"))
        {
            Punch();
        }

        if (Input.GetButtonDown("Kick"))
        {
            Kick();
        }

        if (Physics.Raycast(transform.position, transform.up * -1, groundCheckDistance))
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


        // quickly come down when jumps
        if(player.velocity.y < 0)
        {
            player.velocity = new Vector3(player.velocity.x, player.velocity.y * fallDownMultiplier, player.velocity.z);
        }

    }


    private void FixedUpdate()
    {
        var moveSpeed = movementSpeed * Time.fixedDeltaTime * horizontal;

        player.velocity = new Vector3(moveSpeed, player.velocity.y, player.velocity.z);
    }

    void Kick()
    {
        if (isGround)
        {
            anim.KickAnim();
        }
    }

    void Punch()
    {
        if (isGround)
        {
            
            anim.PunchAnim();
        }
    }

    void Jump()
    {
        if (isGround)
        {
            player.AddForce(transform.up * jumpSpeed);
            anim.JumpAnim();
        }
            
    }
}
