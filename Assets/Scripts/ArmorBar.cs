using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    public Slider slider;
    public void setArmor(int Armor)
    {
        
        slider.value = Armor;
        //if armor is greater than max armor value then make value max armor
        if (slider.value > slider.maxValue){
            slider.value = slider.maxValue;
        }
    }

    public void setMaxArmor(int Armor)
    {
        slider.maxValue = Armor;
        slider.value = Armor;
    }
}
