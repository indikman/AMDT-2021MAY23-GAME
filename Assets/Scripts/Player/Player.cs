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

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
