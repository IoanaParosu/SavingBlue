using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxTox(int health)
    {
        slider.maxValue = health;
        slider.value = 0;
    }
    public void SetTox(int health)
    {
        slider.value = health;
    }
}
