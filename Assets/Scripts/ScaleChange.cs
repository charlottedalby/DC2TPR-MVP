using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    public float scaleMultiplier = 1.2f; // Scale multiplier to adjust the scale change
    private bool isHovering = false;
    private RectTransform rectTransform;
    private Vector3 originalScale;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void ChangeScale(bool increase)
    {
        if (increase)
        {
            if(!isHovering)
            {
                Debug.Log("Hovering over the GameObject");
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
