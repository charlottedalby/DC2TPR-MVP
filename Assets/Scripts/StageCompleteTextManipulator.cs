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

public class StageCompleteTextManipulator : MonoBehaviour
{
    public Text stageCompleteText;
    /*
        Method: Start()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Set Stage Complete Text on Scene 
    */

    public void Start()
    {
        string newText = "Stage " + GameController.stage + " Complete";
        stageCompleteText.text = newText;
        // Uncomment to level up stage, commented as games breaks as stage 2 enemies assets are not implemented
        // GameController.stage += 1;
    }

}
