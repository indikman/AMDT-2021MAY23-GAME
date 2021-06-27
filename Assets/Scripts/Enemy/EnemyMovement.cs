using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > player.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
