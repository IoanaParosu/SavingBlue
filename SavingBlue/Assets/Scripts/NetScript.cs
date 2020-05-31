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
    public GameObject fish;
    public SpriteRenderer deadeyes;
    public Transform fishPos;
    public Animator fishAnimation1;
    public Animator fishAnimation2;
    public Animator fishAnimation3;
    public Rigidbody2D fishRB;
    MovementFish movement;
    bool isDead;
    void Start()
    {
        NetSpeed = 1.0f;
        AccelerationTime = 5.0f;
        movement = GameObject.FindObjectOfType<MovementFish>();
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
        if(isDead)
        {
            if(transform.position.y + 3.2f > fishPos.transform.position.y)
            {
                fishPos.transform.position = new Vector2(fishPos.transform.position.x, transform.position.y + 3.2f);
            }
            if (fishRB.rotation < 90)
            {
                fishRB.rotation += 0.12f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(DieFromNet());

        }
    }

    IEnumerator DieFromNet()
    {
        isDead = true;
        deadeyes.enabled = true;
        fishAnimation1.enabled = false;
        fishAnimation2.enabled = false;
        fishAnimation3.enabled = false;
        movement.enabled = false;
        AudioManager.instance.Stop("FishNet");
        yield return new WaitForSeconds(1f);
        AudioManager.instance.Play("Death");

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
        Destroy(fish);
        //timer.StopTimer();
        //timer.SaveTime();
        SceneManager.LoadScene("YouLose");
    }
}
