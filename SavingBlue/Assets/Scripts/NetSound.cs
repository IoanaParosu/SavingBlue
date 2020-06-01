using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSound : MonoBehaviour
{
    public Transform fishPos;
    float distance;
    float volume = 0.2f;
    bool isPlaying = true;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("FishNet");
        AudioManager.instance.ChangeVolume("FishNet", volume);
    }

    // Update is called once per frame
    void Update()
    {
        if (fishPos != null)
        {
            distance = fishPos.transform.position.y - transform.position.y;
        }

        //Debug.Log("volume: " + volume);


        if (distance < 13 && volume < 1)
        {
            if (isPlaying == false)
            {
                AudioManager.instance.Play("FishNet");
            }
            volume += 0.05f;
            AudioManager.instance.ChangeVolume("FishNet", volume);
        }
        if (distance > 13 && volume > 0.01f)
        {
            volume -= 0.003f;
            Debug.Log("volume: " + volume);
            AudioManager.instance.ChangeVolume("FishNet", volume);
            Debug.Log("Lowering");
            if (volume < 0.02f)
            {
                AudioManager.instance.Stop("FishNet");
                isPlaying = false;
            }
        }
    }
}
