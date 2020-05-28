using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{

    public GameObject MovingObstacle_1;
    public GameObject MovingObstacle_2;
    public GameObject MovingObstacle_3;
    public GameObject MovingObstacle_4;
     Rigidbody2D rb1;
     Rigidbody2D rb2;
     Rigidbody2D rb3;
     Rigidbody2D rb4;


    void Start()
    {
        rb1 = MovingObstacle_1.GetComponent<Rigidbody2D>();
        rb2 = MovingObstacle_2.GetComponent<Rigidbody2D>();
        rb3 = MovingObstacle_3.GetComponent<Rigidbody2D>();
        rb4 = MovingObstacle_4.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }


    public void Action_one()
    {
        rb1.velocity = new Vector2(-1, -0.5f);
        
    }

    public void Action_two()
    {
        rb2.velocity = new Vector2(-0.3f, -1);
    }

    public void Action_three()
    {
        rb3.velocity = new Vector2(0.5f, -1);
        FindObjectOfType<AudioManager>().Play("Can_Rings");
    }

    public void Action_four()
    {
    
        rb4.velocity = new Vector2(0, -1);
        FindObjectOfType<AudioManager>().Play("Can_Rings");
    }

    public void Action_five()
    {

    }
}
