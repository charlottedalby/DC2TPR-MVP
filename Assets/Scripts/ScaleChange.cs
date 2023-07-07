using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Class: ArmorBar
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. isHovering
    b. text


    Methods: 

    a. changeScale()
*/

public class ScaleChange : MonoBehaviour
{
    private bool isHovering = false;
    public Text text;


    /*
        Method: changeColour
        Visibility: Public
        Output: N/A
        Purpose: 

        a. If the increase parameter is true:
        b. Check if the object is not already hovering (isHovering is false).
        c. Set the colour of the Text to a slightly Highlighter Yellow.
        d. Set isHovering to true.
        e. If the increase parameter is false:
        f. Set the colour of the Text to the original colour white.
        g. Set isHovering to false.
    */

    public void changeColour(bool increase)
    {
        if (increase)
        {
            if(!isHovering)
            {
                text.color = new Color(255, 255, 0);
                isHovering = true;
            }   
        }

        else
        {
            text.color = new Color(255, 255, 255);
            isHovering = false;
        }
    }
}
