﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerT;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerT != null)
        {
            transform.position = new Vector3(playerT.position.x, playerT.position.y, -10);
        }
    }   
    
    public void SetVolume(int volume)
    {
        audioSource.volume = volume;
    }
}
