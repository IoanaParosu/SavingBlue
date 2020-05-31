using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanRingsSound : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audio.Play();
        }
    }
}
