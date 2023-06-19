using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Class: HealthBar
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. slider: Unity Slider 

    Methods: 

    a. setHealth()
    b. setMaxHealth()
*/

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    /*
        Method: setHealth()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Slider value equal to Health 

    */

    public void setHealth(int health)
    {
        slider.value = health;
    }

    /*
        Method: setMaxHealth()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Slider Max Value equals 100
        b. Slide Value equals health 
        
    */

    public void setMaxValue(int health)
    {
        slider.maxValue = 100;
        slider.value = health;
    }
}
