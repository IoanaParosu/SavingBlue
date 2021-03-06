﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMouth : MonoBehaviour
{
    public CircleCollider2D mouth;
    public SpriteRenderer spR;
    public HealthBar healthBar;
    public FoodBar foodBar;
    public int maxTox;
    int currentTox;
    private bool IsPlayingSound;
    public int currentFood;
    public GameObject fish;
    public Timer timer;
    public Buttons buttons;
    public MovementFish movementFish;
    public float FoodTimer;
    public float SoundTimer;
    [SerializeField] PauseMenu pauseMenu;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer deadeyes;
    public Animator fishAnimation1;
    public Animator fishAnimation2;
    public Animator fishAnimation3;
    public AudioSource deathSfx;
    MovementFish movement;
    AudioSource audio;





    // Start is called before the first frame update
    void Start()
    {
        //spR = GetComponent<SpriteRenderer>();
        mouth.enabled = false;
        //healthBar = FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
        healthBar.SetMaxTox(maxTox);
        currentTox = 0;
        currentFood = 1;
        FoodTimer = 10.0f;
        SoundTimer = 1.0f;
        IsPlayingSound = false;
        foodBar.SetCurrentFood(currentFood);
        movementFish.SetMaxSpeed(currentFood);
        pauseMenu = FindObjectOfType<PauseMenu>();
        movement = FindObjectOfType<MovementFish>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (FoodTimer <= 10.0f && currentFood > 0) //Decreasing the food level
        {

            FoodTimer -= Time.deltaTime;
            if (FoodTimer < 0)
            {
                currentFood--;
                foodBar.MinusOne();
                movementFish.SetMaxSpeed(currentFood);
                FoodTimer = 10.0f;
                Debug.Log(currentFood);
            }
        }

        if (IsPlayingSound == true)
        {
            SoundTimer -= Time.deltaTime;
        }

        CheckMouthSound();

        if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.E) && pauseMenu.GameIsPaused == false)
        {
            mouth.enabled = true;
            spR.material.color = new Color(0, 1, 1);
            spriteRenderer.enabled = true;
            animator.SetBool("IsOpened", true);
            if (SoundTimer == 1.0f)
            {
                audio.Play();
                IsPlayingSound = true;
            }


        }
        else
        {
            mouth.enabled = false;
            spR.material.color = new Color(1, 1, 1);
            animator.SetBool("IsOpened", false);
            spriteRenderer.enabled = false;
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            audioManager.Play("eatFoodSfx");
            audioManager.ChangePitch("eatFoodSfx", Random.Range(0.75f, 1f));
            Debug.Log("Yum");
            if (currentFood != 5)
            {
                currentFood++;
                foodBar.SetCurrentFood(currentFood);
                movementFish.SetMaxSpeed(currentFood);
            }
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Plastic")
        {
            FindObjectOfType<AudioManager>().Play("eatPlasticSfx");

            TakeDamage();
            
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "AntiPlastic")
        {
            PlasticDown();

            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage()
    {
        PlasticUp();
        if(currentTox > 4)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        deadeyes.enabled = true;
        fishAnimation1.enabled = false;
        fishAnimation2.enabled = false;
        fishAnimation3.enabled = false;
        movement.isDead = true;
        AudioManager.instance.Stop("FishNet");
        deathSfx.Play();

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
        Destroy(fish);
        buttons.LoseScene();
    }


    public int GetCurrentFood()
    {
        return currentFood;
    }

    public void PlasticUp()
    {
        currentTox++;
        healthBar.SetTox(currentTox);
    }
    public void PlasticDown()
    {
        currentTox--;
        healthBar.SetTox(currentTox);
    }
    public void CheckMouthSound()
    {
        if (SoundTimer < 0)
        {
            IsPlayingSound = false;
            SoundTimer = 1.0f;
        }
    }

}
