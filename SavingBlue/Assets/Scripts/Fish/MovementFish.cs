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
    public Transform direction;

    public float rotAmount;
    public float SlowDownTime;
    public float StunnedTime;
    public float playerInput;
    public float MaxSpeed;
    private int currentFood;

    private bool flag;
    public float powerSwimSensitivity;
    private int swimAmount;
    public int powerSwimAmount;
    private bool stuck;
    private GameObject canRings;
    private GameObject MovingObstacle;

    public Rigidbody2D rb;
    bool slowed;
    public bool isDead = false;


    [SerializeField] PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        slowed = false;
        //shouldRotate = true;
        SlowDownTime = 0.25f;
        StunnedTime = 2.0f;
        currentFood = fishMouth.GetCurrentFood();
        Debug.Log(currentFood);
        pauseMenu = FindObjectOfType<PauseMenu>();
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

        if (Input.GetKeyDown(KeyCode.K))
        {
            stuck = true;
        }

        if(stuck == true)
        {
            Stuck();
        }

        if (Stunned == true)
        {
            Debug.Log("Stun");
            Stun();
            StunnedTime -= Time.deltaTime;
            if (StunnedTime < 0)
            {
                StunnedTime = 2.0f;
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
        playerInput = Input.GetAxis("Mouse X"); // Use playerInput = Input.GetAxis("Mouse X") * -1; if using the controller
        // Checks if player input was L2, if so rotate player clockwise and move forward the same speed as the input value
        if(!isDead)
        {
            if (playerInput < 0 && pauseMenu.GameIsPaused == false)
            {

                MoveFunc(playerInput * -1);
                Rotate(playerInput);
                Accelerate();
                RotateFin(playerInput);
                DirectionObject(playerInput);
            }
            // Checks if player input was R2, if so rotate player counterclockwise and move forward the same speed as the input value
            else if (playerInput > 0 && pauseMenu.GameIsPaused == false)
            {

                MoveFunc(playerInput);
                Rotate(playerInput);
                Accelerate();
                RotateFin(playerInput);
                DirectionObject(playerInput);
            }
            else if(playerInput == 0 && pauseMenu.GameIsPaused == false)
            {
                if(fin.transform.localEulerAngles.z > 180)
                {
                    fin.transform.localEulerAngles = new Vector3(fin.transform.localEulerAngles.x, fin.transform.localEulerAngles.y, fin.transform.localEulerAngles.z - 0.1f);
                }
                else if(fin.transform.localEulerAngles.z < 180)
                {
                    fin.transform.localEulerAngles = new Vector3(fin.transform.localEulerAngles.x, fin.transform.localEulerAngles.y, fin.transform.localEulerAngles.z + 0.1f);
                }
            }
            transform.position += transform.up * CurrentSpeed * Time.deltaTime;
        }
        else if(isDead)
        {
            transform.position += transform.up * Time.deltaTime;
        }
        Debug.Log("speed: " +CurrentSpeed);

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
        //Debug.Log("Before: " + fin.transform.eulerAngles.z);
            fin.transform.localEulerAngles = new Vector3(fin.transform.localEulerAngles.x, fin.transform.localEulerAngles.y, Mathf.Clamp(fin.transform.localEulerAngles.z + (playerInput * 2), 140, 220));
        //Debug.Log("Fin: " + fin.transform.eulerAngles.z + "Fish: " + transform.eulerAngles.z);
        //}
    }
    //Common accelerate function, which increase the speed

    void DirectionObject(float input)
    {
        direction.position = new Vector3(direction.position.x - input / 8, Camera.main.transform.position.y + 3, 10);
    }
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
        CurrentSpeed = curSpeed / 2f;
        yield return new WaitForSeconds(2f);
        slowed = false;
    }

    public void SetMaxSpeed(int FoodLevel)
    {
        if (MaxSpeed < 4)
        {
            MaxSpeed = FoodLevel + 1;
        }
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
            buttons.EducationalScene();
        }
        if (collision.gameObject.tag == "Pushable")
        {
            FindObjectOfType<AudioManager>().Play("Pushable Object");
        }
        else if(collision.gameObject.tag == "Pushable Exit")
        {
             FindObjectOfType<AudioManager>().Stop("Pushable Object");
        }
        if(collision.gameObject.tag == "Current Enter")
        {
            FindObjectOfType<AudioManager>().Play("Currents");
        }
        if(collision.gameObject.tag == "Current Exit")
        {
            FindObjectOfType<AudioManager>().Stop("Currents");
        }
        if(collision.gameObject.tag == "Can Rings" && canRings == null)
        {
            stuck = true;
            canRings = collision.gameObject;
            Destroy(canRings.GetComponent<Rigidbody2D>());
            canRings.transform.parent = transform;
            
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingObstacle")
        {
            MovingObstacle = collision.gameObject;
            Debug.Log("LOGLOG");
            FindObjectOfType<AudioManager>().Play("Obstacle");
            Stunned = true;
            Destroy(MovingObstacle.GetComponent<BoxCollider2D>());
        }

        if (collision.gameObject.tag == "Landscape")
        {
            FindObjectOfType<AudioManager>().Play("WallSfx");
        }
    }


    private void Stun()
    {

       CurrentSpeed = 0;
        //rb.rotation = 0;


    }

    private void Stuck()
    {
        if(CurrentSpeed > 0.15f)
        {
            CurrentSpeed -= 0.015f + (0.01f * CurrentSpeed);
            rotAmount = 0.2f;
        }

        if (flag)
        {
            if(Input.GetAxis("Mouse X") > powerSwimSensitivity)
            {
                swimPlus();
            }
        }
        else if (!flag)
        {
            if(Input.GetAxis("Mouse X") < -powerSwimSensitivity)
            {
                swimPlus();
            }
        }
        if(swimAmount >= powerSwimAmount)
        {
            stuck = false;
            rotAmount = 3;
            canRings.transform.parent = null;
            swimAmount = 0;
            Destroy(canRings);
        }
    }

    private void swimPlus()
    {
        swimAmount++;
        flag = !flag;
    }
}
