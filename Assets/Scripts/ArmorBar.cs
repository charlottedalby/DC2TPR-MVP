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
    }

    public void setMaxArmor(int Armor)
    {
        slider.maxValue = Armor;
        slider.value = Armor;
    }
}
