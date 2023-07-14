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
        if (GameController.stage != 0) {
            GameController.stage += 1;
        }
        else{
            GameController.stage = -1;
        }
        GameController.PlayerStartHealth = 100;
    }

}
