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
        Debug.Log("volume: " + volume);


        if (distance < 15 && volume < 1)
        {
            volume += 0.001f;
        }
        else if(distance > 15 && volume > 0.001f)
        {
            volume -= 0.001f;
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
            Destroy(collision.gameObject);
            //SceneManager.LoadScene("YouLose");
        }
    }
}
