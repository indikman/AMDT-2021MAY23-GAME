using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
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
       // Debug.Log("Collission happened!! : " + collision.gameObject.tag);

        if(other.gameObject.tag == "enemy")
        {
            //other.gameObject.GetComponent<TestHealth>().GetDamage();
            other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            //other.gameObject.GetComponent<TestHealth>().GetDamage();
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            //other.gameObject.GetComponent<TestHealth>().GetDamage();
            other.gameObject.transform.Rotate(0, 100 * Time.deltaTime, 0);
        }
    }



}
