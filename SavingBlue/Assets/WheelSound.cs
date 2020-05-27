using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSound : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.angularVelocity == 0)
        {
            AudioManager.instance.Stop("Wheel");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wheel")
        {
            if(rb.angularVelocity != 0)
            {
                AudioManager.instance.Play("Wheel");
            }
        }
    }
}
