using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Collider punchCollider;
    public Collider kickCollider;

    public HitBox punchHit;
    public HitBox kickHit;

    public float punchDamage;
    public float kickDamage;

    public bool isAlive;
    public PlayerAnimations anim;
    public float maxHealth = 100f;

    private float health;

    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        GameManager.GetInstance().PlayerHealthUIUpdate(health / maxHealth);

        isAlive = true;

        punchCollider.enabled = false;
        kickCollider.enabled = false;

        punchHit.SetDamage(punchDamage);
        kickHit.SetDamage(kickDamage);
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
        if (other.gameObject.tag == "hitbox")
        {
            health -= other.GetComponent<HitBox>().GetDamage();

            GameManager.GetInstance().PlayerHealthUIUpdate(health / maxHealth);

            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        isAlive = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        anim.DieAnim();
        GameManager.GetInstance().GameOver(2);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
