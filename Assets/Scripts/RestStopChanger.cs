using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestStopChanger : MonoBehaviour
{

    public Sprite stage1Background;
    public Sprite stage2Background;
    public Sprite stage3Background;
    public Sprite stage4Background;
    
    void Start()
    {
        stage1Background = GameObject.Find("Stage1").GetComponent<Image>().sprite;
        stage2Background = GameObject.Find("Stage2").GetComponent<Image>().sprite;
        stage3Background = GameObject.Find("Stage3").GetComponent<Image>().sprite;
        stage4Background = GameObject.Find("Stage4").GetComponent<Image>().sprite;
        
        Image background = GameObject.Find("Background").GetComponent<Image>();

        if (GameController.stage == 1)
        {
            background.sprite = stage1Background;
        }

        else if (GameController.stage == 2)
        {
            background.sprite = stage2Background;
        }

        else if (GameController.stage == 3)
        {
            background.sprite = stage3Background;
        }

        else if (GameController.stage == 4)
        {
            background.sprite = stage4Background;
        }
    }

    
}
