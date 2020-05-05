using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxFood(float maxSpeed)
    {
        slider.maxValue = maxSpeed;
    }
    public void SetCurrentFood(float curSpeed)
    {
        slider.value = curSpeed;
        Debug.Log(curSpeed);
    }
    public void MinusOne()
    {
        
        slider.value -= 1;
    }
    public void PlusOne()
    {
        slider.value += 1;
    }
}
