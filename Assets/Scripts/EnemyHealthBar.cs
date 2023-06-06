using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider Slider;

    public void setEnemyHealth(int health)
    {
        Slider.value = health;
    }

    public void setEnemyMaxHealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }
}
