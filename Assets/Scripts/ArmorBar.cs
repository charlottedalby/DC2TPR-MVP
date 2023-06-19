using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Class: ArmorBar
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. slider: Unity Slider 

    Methods: 

    a. setArmor()
    b. setMaxArmor()
*/

public class ArmorBar : MonoBehaviour
{

    public Slider slider;
    
    /*
        Method: setArmor()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Slider value equal to armor 
        b. If slider value is greater than max slider value 
        c. Then Slider value is equal to Max Value 
    */

    public void setArmor(int Armor)
    {
        slider.value = Armor;
        if (slider.value > slider.maxValue)
        {
            slider.value = slider.maxValue;
        }
    }

    /*
        Method: setMaxArmor()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Slider max value equal to armor
        b. Slider value equal to armor
    */

    public void setMaxArmor(int Armor)
    {
        slider.maxValue = Armor;
        slider.value = Armor;
    }
}
