using System.Collections;
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
    public int currentFood;
    public GameObject fish;
    public Timer timer;
    public Buttons buttons;
    public MovementFish movementFish;
    public float FoodTimer;

    // Start is called before the first frame update
    void Start()
    {
        //spR = GetComponent<SpriteRenderer>();
        mouth.enabled = false;
        healthBar = FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
        healthBar.SetMaxTox(maxTox);
        currentTox = 0;
        currentFood = 1;
        FoodTimer = 10.0f;
        foodBar.SetCurrentFood(currentFood);
        movementFish.SetMaxSpeed(currentFood);


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


        if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Mouse0))
        {
            mouth.enabled = true;
            spR.material.color = new Color(0, 1, 1);
        }
        else
        {
            mouth.enabled = false;
            spR.material.color = new Color(1, 1, 1);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            FindObjectOfType<AudioManager>().Play("eatFoodSfx");
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
            //FindObjectOfType<AudioManager>().Play("eatPlasticSfx");

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
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Destroy(fish);
        //timer.StopTimer();
        //timer.SaveTime();
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
}
