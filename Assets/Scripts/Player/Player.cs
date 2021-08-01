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
    public float health;
    public PlayerAnimations anim;

    // Start is called before the first frame update
    void Start()
    {

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
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
