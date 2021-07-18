using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyState
    {
        IDLE,
        ALERT,
        ACTION,
        DEAD
    }

    public Transform player;
    public Enemy enemy;
    public EnemyAnimations anim;
    public EnemyState state = EnemyState.IDLE;
    public float movementSpeed;
    public Rigidbody enemyBody;


    public float distanceToPlayer;
    

    private bool isFighing;

    // Start is called before the first frame update
    void Start()
    {
        isFighing = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Mathf.Abs(Vector3.Distance(transform.position, player.position));



        // Enemey rotates towards the player
        RotateTowardsPlayer();

        if(state == EnemyState.IDLE)
        {
            isFighing = false;
            // wait
            if (distanceToPlayer < 1.5f)
            {
                state = EnemyState.ACTION;
            }



        }else if (state == EnemyState.ALERT)
        {

            isFighing = false;

            // move towards the player
            if (distanceToPlayer < 1.5f)
            {
                state = EnemyState.ACTION;
            }

        }
        else if (state == EnemyState.ACTION)
        {
            enemyBody.velocity = new Vector3(0, enemyBody.velocity.y, enemyBody.velocity.z);
            anim.enemyHorizontal = 0;

            // occasionally hit the player

            if (distanceToPlayer >= 1.5f)
            {
                state = EnemyState.ALERT;
            }

            // Wait for a random time and kick/punch
            if (!isFighing)
            {
                isFighing = true;
                Invoke("Fight", Random.Range(1, 3));
            }
                



        }
        else if (state == EnemyState.DEAD)
        {
            // stay dead!
            isFighing = false;
        }



    }

    private void FixedUpdate()
    {
        if (state == EnemyState.ALERT)
        {
            float dir=1;
            if(transform.position.x >= player.position.x)
            {
                dir = -1;
            }


            var moveSpeed = movementSpeed * Time.fixedDeltaTime * dir;
            enemyBody.velocity = new Vector3(moveSpeed, enemyBody.velocity.y, enemyBody.velocity.z);
            anim.enemyHorizontal = dir;
        }
    }

    void MoveTowardsPlayer()
    {

    }

    void Fight()
    {
        if (state == EnemyState.ACTION)
        {
            enemy.EnablePunch();
            anim.PunchAnim();
            isFighing = false;
        }
    }

    void RotateTowardsPlayer()
    {
        if (transform.position.x > player.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

    }
}
