using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSound : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        if(rb.angularVelocity == 0)
        {
            AudioManager.instance.Stop("Wheel");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (rb.angularVelocity != 0)
            {
                AudioManager.instance.Play("Wheel");
                Debug.Log("Play Wheel");
            }
        }
      
    }
}
