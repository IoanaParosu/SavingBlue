using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetScript : MonoBehaviour
{

    public float NetSpeed;
    public float AccelerationTime;
    public Rigidbody2D rb;
    public FishMouth fishMouth;
    public Transform fishPos;
    float distance;
    float volume = 0.2f;
    bool isPlaying = true;
    void Start()
    {
        NetSpeed = 1.0f;
        AccelerationTime = 5.0f;
        AudioManager.instance.Play("FishNet");
        AudioManager.instance.ChangeVolume("FishNet", volume);
    }

   
    void Update()
    {

        AccelerationTime -= Time.deltaTime;

        if (AccelerationTime <= 0.0f) //Decrease the speed of the fish
        {
            NetSpeed = NetSpeed + 0.15f;
            AccelerationTime = 5.0f;
        }


        rb.velocity = new Vector2(0, NetSpeed);

        if(fishPos != null)
        {
            distance = fishPos.transform.position.y - transform.position.y;
        }

        AudioManager.instance.ChangeVolume("FishNet", volume);
        //Debug.Log("volume: " + volume);


        if (distance < 13 && volume < 1)
        {
            if(isPlaying == false)
            {
                AudioManager.instance.Play("FishNet");
            }
            volume += 0.05f;
        }
        if (distance > 13 && volume > 0.01f)
        {
            volume -= 0.005f;
            if(volume < 0.05f)
            {
                AudioManager.instance.Stop("FishNet");
                isPlaying = false;
            }
        }
        //if(distance < 20 && distance > 10)
        //{
        //    FindObjectOfType<AudioManager>().ChangeVolume("FishNet", 0.5f);
        //}
        //else if(distance < 10)
        //{
        //    FindObjectOfType<AudioManager>().ChangeVolume("FishNet", 1f);
        //}
        //else if(distance > 30)
        //{
        //    FindObjectOfType<AudioManager>().Stop("FishNet");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fishMouth.Die();
            AudioManager.instance.Stop("FishNet");
            Destroy(collision.gameObject);
            SceneManager.LoadScene("YouLose");
        }
    }
}
