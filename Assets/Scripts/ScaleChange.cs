using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class: ArmorBar
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. scaleMultiplier
    b. isHovering
    c. rectTransform
    d. originalScale


    Methods: 

    a. Start()
    b. changeScale()
*/

public class ScaleChange : MonoBehaviour
{
    public float scaleMultiplier = 1.2f;
    private bool isHovering = false;
    private RectTransform rectTransform;
    private Vector3 originalScale;

    /*
        Method: Start()
        Visibility: Private
        Output: N/A
        Purpose: 

        a. Get the RectTransform component attached to the current object and assign it to the rectTransform variable.
        b. Store the initial local scale of the RectTransform in the originalScale variable.
    */

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    /*
        Method: ChangeScale
        Visibility: Public
        Output: N/A
        Purpose: 

        a. If the increase parameter is true:
        b. Check if the object is not already hovering (isHovering is false).
        c. Set the local scale of the RectTransform to a slightly increased scale.
        d. Set isHovering to true.
        e. If the increase parameter is false:
        f. Set the local scale of the RectTransform to the original scale.
        g. Set isHovering to false.
    */

    public void ChangeScale(bool increase)
    {
        if (increase)
        {
            if(!isHovering)
            {
                rectTransform.localScale = new Vector3(1.2f, 1.1f, 1.1f);
                isHovering = true;
            }   
        }

        else
        {
            rectTransform.localScale = originalScale;
            isHovering = false;
        }
    }
}
