using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    public Animator anim;
    public Joystick inputStick;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("Movement", Input.GetAxis("Horizontal"));
        anim.SetFloat("Movement", inputStick.Horizontal);
    }

    public void JumpAnim()
    {
        anim.SetTrigger("Jump");
    }

    public void PunchAnim()
    {
        anim.SetTrigger("Punch");
    }

    public void KickAnim()
    {
        anim.SetTrigger("Kick");
    }

    public void setYVelocity(float value)
    {
        anim.SetFloat("Yvelocity", value);
    }

    public void DieAnim()
    {
        anim.SetTrigger("Die");
    }
}
