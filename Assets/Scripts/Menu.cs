using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
/*
    Class: Menu 
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. N/A

    Methods: 

    a. NextBattle()
        i. Unlocks Player Cursor
        ii. Loads Battle Scene 

    b. loadOverworld()
        i. Loads Overworld Scene

    c. exitGame()
        i. Quits Application

    d. loadMainMenu()
        i. GameController PlayerStartNode is set to null
        ii. Loads Main Menu Scene 

    e. loadOverworld20HP()
        i. GameController playerStartHealth is increased by 20
        ii. If GameController playerStartHealth is greater than 100
        iii. GameController playerStartHealth equals 100
        iv. Loads Overworld Scene

    f. loadCardSteal()
        i. Loads Card Stealing Scene 

    g. loadCardSwap()
        i. Loads Card Swap Scene

    h. loadPlayerCardsScene()
        i. Loads Player Card Steal Scene

    i. loadPlayerCardCancel()
        i. Loads Player Card Steal Scene
*/

public class Menu : MonoBehaviour
{
    public Animator animator; 
    public string message = "";
    
    public void NextBattle()
    {
        Cursor.lockState = CursorLockMode.None;
        if (GameController.stage == 0){
            fadeToLevel("TutorialBattleScreen");
        }
        else {
            fadeToLevel("BattleScreen");
        }
        
    }

    public void loadOverworld()
    {
        if (GameController.stage == 0){
            fadeToLevel("TutorialOverworldScreen");
        }
        else {
            fadeToLevel("OverworldScreen");
        }
    }

    public void loadTutorial()
    {
        GameController.stage = 0;
        fadeToLevel("TutorialOverworldScreen");
    }

    public void exitGame()
    {
        message = "Quitting Game";
        Application.Quit();
    }

    public void loadMainMenu()
    {
        GameController.PlayerStartNode = null;
        fadeToLevel("MainMenu");
    }

    public void loadOverworld20HP()
    {
        GameController.PlayerStartHealth += 20;
        
        if (GameController.PlayerStartHealth > 100)
        {
            GameController.PlayerStartHealth = 100;
        }

        if (GameController.stage == 0){
            fadeToLevel("TutorialOverworldScreen");
        }
        else {
            fadeToLevel("OverworldScreen");
        }
    }
    
    public void loadCardSteal()
    {
        if (GameController.stage == -1) 
        {
            fadeToLevel("MainMenu");
        }
        else 
        {
            fadeToLevel("CardStealing");
        }
    }

    public void LoadPlayerCardsScene()
    {
        fadeToLevel("PlayerCardStealScreen");
    }

    public void loadPlayerCardCancel()
    {
        fadeToLevel("PlayerCardStealScreen");
    } 

    public void loadGameOver()
    {
        fadeToLevel("GameOver");
    }

    public void loadStageComplete()
    {
        fadeToLevel("StageComplete");
    }

    public void loadYouWin()
    {
        fadeToLevel("YouWin");
    }

    public void loadRestStop()
    {
        fadeToLevel("RestStop");
    }

    public void loadEventStop()
    {
        fadeToLevel("EventStop");
    }
    public void loadGameComplete()
    {
        fadeToLevel("GameComplete");
    }

    public void fadeToLevel(string name)
    {
        if (animator != null)
        {
            animator.SetTrigger("FadeOut");
            SceneManager.LoadScene(name);
        }
        //Testing Purposes
        else
        {
        #if UNITY_EDITOR
        string tempName = "Assets/Scenes/";
        string amendedNameOne = tempName + name;
        string amendedNameTwo = amendedNameOne +".unity";
        name = amendedNameTwo;
        UnityEditor.SceneManagement.EditorSceneManager.OpenScene(name);
        #endif
    }
        }
    }

