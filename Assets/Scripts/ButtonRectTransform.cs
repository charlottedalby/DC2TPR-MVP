using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonRectTransform : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform buttonRectTransform;

    private void Awake()
    {
        buttonRectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Increase the scale of the button when the mouse pointer enters it
        buttonRectTransform.localScale = new Vector3(1.2f, 1.2f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Reset the scale of the button when the mouse pointer exits it
        buttonRectTransform.localScale = new Vector3(1f, 1f, 1f);
    }
}
