using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerAnimations anim;

    public float health = 100f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hitbox")
        {
            health -= other.GetComponent<HitBox>().GetDamage();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        anim.DieAnim();
        Debug.Log("Enemy Died!");
    }
}
