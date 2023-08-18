using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    Class: RestStopChanger
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. stage1Background
    b. stage2Background
    c. stage3Background
    d. stage4Background

    Methods: 

    a. Start()

    Purpose:
    
    a. Set rest stop background based on stage user in on

*/
public class RestStopChanger : MonoBehaviour
{

    public Sprite stage1Background;
    public Sprite stage2Background;
    public Sprite stage3Background;
    public Sprite stage4Background;
    public string message;
    
    public void Start()
    {
        stage1Background = GameObject.Find("Stage1").GetComponent<Image>().sprite;
        stage2Background = GameObject.Find("Stage2").GetComponent<Image>().sprite;
        stage3Background = GameObject.Find("Stage3").GetComponent<Image>().sprite;
        stage4Background = GameObject.Find("Stage4").GetComponent<Image>().sprite;
        
        Image background = GameObject.Find("Background").GetComponent<Image>();

        if (GameController.stage == 1)
        {
            background.sprite = stage1Background;
            message = "Stage 1 Background Correct";
        }

        else if (GameController.stage == 2)
        {
            background.sprite = stage2Background;
            message = "Stage 2 Background Correct";
        }

        else if (GameController.stage == 3)
        {
            background.sprite = stage3Background;
            message = "Stage 3 Background Correct";
        }

        else if (GameController.stage == 4)
        {
            background.sprite = stage4Background;
            message = "Stage 4 Background Correct";
        }
    }

    
}
