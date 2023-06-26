using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Class: StageCompleteTextManipulator
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. stageCompleteText

    Methods: 

    a. Start()
*/

public class StageTextManipulator : MonoBehaviour
{
    public Text stageText;
    /*
        Method: Start()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Set Stage Text on Scene 
    */

    public void Start()
    {
        string newText = "Stage " + GameController.stage;
        stageText.text = newText;
    }

}
