using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSound : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.angularVelocity == 0)
        {
            audio.Stop();
            //AudioManager.instance.Stop("Wheel");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(rb.angularVelocity != 0)
            {
                audio.Play();
                //AudioManager.instance.Play("Wheel");
            }
        }
    }
}
