using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyAnimations anim;

    private float health = 100f;
    public float maxHealth = 100;


    public Collider punchCollider;
    public Collider kickCollider;

    public HitBox punchHit;
    public HitBox kickHit;

    public float punchDamage;
    public float kickDamage;


    // Enemey live state
    public bool isAlive;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        GameManager.GetInstance().EnemyHealthUIUpdate(health / maxHealth);
        isAlive = true;

        punchCollider.enabled = false;
        kickCollider.enabled = false;

        punchHit.SetDamage(punchDamage);
        kickHit.SetDamage(kickDamage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePunch()
    {
        punchCollider.enabled = true;
    }

    public void EnableKick()
    {
        kickCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hitbox")
        {
            health -= other.GetComponent<HitBox>().GetDamage();

            GameManager.GetInstance().EnemyHealthUIUpdate(health / maxHealth);

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isAlive = false;
        anim.DieAnim();

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

        Debug.Log("Enemy Died!");
        GameManager.GetInstance().GameOver(1);
    }
}
