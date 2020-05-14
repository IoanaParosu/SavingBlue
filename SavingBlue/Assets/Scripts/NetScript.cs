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
    void Start()
    {
        NetSpeed = 1.0f;
        AccelerationTime = 5.0f;
        FindObjectOfType<AudioManager>().ChangeVolume("FishNet", 0.3f);
        FindObjectOfType<AudioManager>().Play("FishNet");
    }

   
    void Update()
    {

        AccelerationTime -= Time.deltaTime;

        if (AccelerationTime <= 0.0f) //Decrease the speed of the fish
        {
            NetSpeed = NetSpeed + 0.15f;
            AccelerationTime = 5.0f;
        }

        distance = fishPos.transform.position.y - transform.position.y;


        if(distance < 20 && distance > 10)
        {
            FindObjectOfType<AudioManager>().ChangeVolume("FishNet", 0.65f);
        }
        else if(distance < 10)
        {
            FindObjectOfType<AudioManager>().ChangeVolume("FishNet", 1f);
        }

        Debug.Log("distance: " + distance);

        rb.velocity = new Vector2(0, NetSpeed);
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
