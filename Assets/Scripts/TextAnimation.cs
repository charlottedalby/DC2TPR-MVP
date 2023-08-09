using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    public GameManager gameManager;
    public bool visible;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
        visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.player.availableCardSlots[0] == false && visible == true)
        {
            StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
            visible = false;
        }
        if (gameManager.player.availableCardSlots[0] == true && visible == false)
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
            visible = true;
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
