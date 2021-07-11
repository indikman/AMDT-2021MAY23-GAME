using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealth : MonoBehaviour
{

    public float Health = 100;

    public void GetDamage()
    {
        Health -= 10f;

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
