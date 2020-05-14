﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFish : MonoBehaviour
{
    public float RotateSpeed;
    public float CurrentSpeed = 1.0f;
    bool Stunned;
    //bool shouldRotate;

    public Buttons buttons;
    public FishMouth fishMouth;
    public PolygonCollider2D Body;
    public LevelControl levelControl;
    public MovingObstacleBehaviour movingObstacleBehaviour;
    public Transform fin;

    public float rotAmount;
    public float SlowDownTime;
    public float StunnedTime;
    public float playerInput;
    public float MaxSpeed;
    private int currentFood;


    public Rigidbody2D rb;
    bool slowed;
    // Start is called before the first frame update
    void Start()
    {
        slowed = false;
        //shouldRotate = true;
        SlowDownTime = 0.25f;
        StunnedTime = 3.0f;
        currentFood = fishMouth.GetCurrentFood();
        Debug.Log(currentFood);
    }

    // Update is called once per frame
    void Update()
    {


            SlowDownTime -= Time.deltaTime;
            {
                if (SlowDownTime <= 0.0f && CurrentSpeed >= 0.0f)  //Decrease the speed of the fish
                {
                    CurrentSpeed = CurrentSpeed - 0.10f;
                    SlowDownTime = 0.25f;
                }
            }


        if (Stunned == true)
        {
            Stun();
            StunnedTime -= Time.deltaTime;
            if (StunnedTime < 0)
            {
                StunnedTime = 3.0f;
                Stunned = false;
            }
           
        }


        //if (fin.transform.rotation.z <= 0.15f || fin.transform.rotation.z >= 0.99f)
        //{
        //    Debug.Log("Im False NOWW");
        //    shouldRotate = false;
        //}
        //else
        //{
        //    shouldRotate = true;
        //}




        // Get player input from triggers (L2 ranges from -0.01 to -1, R2 ranges from 0.01 to 1)
        playerInput = Input.GetAxis("Mouse X");
        // Checks if player input was L2, if so rotate player clockwise and move forward the same speed as the input value
        if (playerInput < 0)
        {
            
            MoveFunc(playerInput * -1);
            Rotate(playerInput);
            Accelerate();
            RotateFin(playerInput);
        }
        // Checks if player input was R2, if so rotate player counterclockwise and move forward the same speed as the input value
        else if (playerInput > 0)
        {
            
            MoveFunc(playerInput);
            Rotate(playerInput);
            Accelerate();
            RotateFin(playerInput);
        }
        transform.position += transform.up * CurrentSpeed * Time.deltaTime;
        //TestTest
    }
    // Move function. Takes float as parameter, preferably players input
    void MoveFunc(float input)
    {
        transform.position += transform.up * CurrentSpeed * input * Time.deltaTime;
    }
    // Rotate function. Takes float as parameter, preferably players input
    void Rotate(float input)
    {
        rb.rotation += rotAmount * input;
        
    }
    void RotateFin(float input)
    {
        //if (shouldRotate)
        //{
        Debug.Log("Before: " + fin.transform.eulerAngles.z);
            fin.transform.eulerAngles = new Vector3(fin.transform.eulerAngles.x, fin.transform.eulerAngles.y, fin.transform.eulerAngles.z + playerInput);
            Debug.Log("After: "+ fin.transform.eulerAngles.z);
        //}
    }
    //Common accelerate function, which increase the speed
    void Accelerate()
    {
        if (CurrentSpeed < MaxSpeed)
        {
            if (slowed == false)
            {
                CurrentSpeed = CurrentSpeed + 0.01f;
            }
        }
        
    }
    public void Slower()
    {
        if (slowed == false)
        {
            StartCoroutine(SlowDown());
        }
    }
    IEnumerator SlowDown()
    {
        slowed = true;
        float curSpeed = CurrentSpeed;
        CurrentSpeed = 1f;
        yield return new WaitForSeconds(2f);
        slowed = false;
    }

    public void SetMaxSpeed(int FoodLevel)
    {
        MaxSpeed = FoodLevel + 1;
    }

    public void SetCurrentFood(int FoodLevel)
    {
        currentFood = FoodLevel;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Trigger 1")
        {
            Debug.Log(125);
            levelControl.Action_one();
        }
        else if (collision.name == "Trigger 2")
        {
            Debug.Log(125);
            levelControl.Action_two();
        }
        else if (collision.name == "Trigger 3")
        {
            Debug.Log(125);
            levelControl.Action_three();
        }
        else if (collision.name == "Trigger 4")
        {
            Debug.Log(125);
            levelControl.Action_four();
        }
        else if(collision.name == "FinishLine")
        {
            buttons.WinScene();
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingObstacle")
        {
            FindObjectOfType<AudioManager>().Play("Obstacle");
            Stunned = true;
        }

        if (collision.gameObject.tag == "Constant Obstacle")
        {
            FindObjectOfType<AudioManager>().Play("Obstacle");
        }
        if(collision.gameObject.tag == "Plastic Cluster")
        {
            FindObjectOfType<AudioManager>().Play("Pushable Object");
        }
        if(collision.gameObject.tag == "Landscape")
        {
            FindObjectOfType<AudioManager>().Play("WallSfx");
        }
        if (collision.gameObject.tag == "Wheel")
        {
            FindObjectOfType<AudioManager>().Play("WheelSfx");
        }
    }


    private void Stun()
    {

       CurrentSpeed = 0;
        rb.rotation = 0;


    }
}
