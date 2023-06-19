using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void NextBattle()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("BattleScreen");
    }

    public void loadOverworld()
    {
        SceneManager.LoadScene("OverworldScreen");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void loadMainMenu()
    {
        GameController.PlayerStartNode = null;
        SceneManager.LoadScene("MainMenu");
    }

    public void loadOverworld20HP()
    {
        GameController.PlayerStartHealth += 20;
        
        if (GameController.PlayerStartHealth > 100)
        {
            GameController.PlayerStartHealth = 100;
        }

        SceneManager.LoadScene("OverworldScreen");
    }
    
    public void loadCardSteal()
    {
        SceneManager.LoadScene("CardStealing");
    }

    public void loadCardSwap()
    {
        SceneManager.LoadScene("CardSwap");
    }

    public void LoadPlayerCardsScene()
    {
        SceneManager.LoadScene("PlayerCardStealScreen");
    }

    public void loadPlayerCardCancel()
    {
        SceneManager.LoadScene("PlayerCardStealScreen");
    }
    
}

