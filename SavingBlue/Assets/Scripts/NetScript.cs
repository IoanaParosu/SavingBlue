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
    void Start()
    {
        NetSpeed = 1.0f;
        AccelerationTime = 5.0f;
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
