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

public class TutorialTextManipulator : MonoBehaviour
{
    public Text stageCompleteText;
    /*
        Method: Start()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Set Stage Complete Text on Scene 
    */

    public GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        if (GameController.stage == 0 && gameManager.enemy.difficulty == 1) {
            stageCompleteText.text = "Kick is our strongest attack in our hand, click on the card to use the attack";
        }
        if (GameController.stage == 0 && gameManager.enemy.difficulty == 2) {
            if (gameManager.player.deck.Count > 0) {
                stageCompleteText.text = "";
            }
            if (gameManager.player.deck.Count > 3) {
                stageCompleteText.text = "Other cards increases or multiplies your attack on your next turn, click the Meditate card";
            }
            if (gameManager.player.deck.Count > 6) {
                stageCompleteText.text = "Some cards gives armor which protects our health, click the Grapple card";
            }
        }
    }
}
