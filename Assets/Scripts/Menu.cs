using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void NextBattle()
    {
        Cursor.lockState = CursorLockMode.None;
        //Goes to load the BattleScreen
        SceneManager.LoadScene("BattleScreen");
    }

    public void loadOverworld(){
        SceneManager.LoadScene("OverworldScreen");
    }

    public void exitGame(){
        Application.Quit();
    }

    public void loadMainMenu()
    {
        //Loads Main Menu
        SceneManager.LoadScene("MainMenu");
    }

    public void loadNewGame(){
        SceneManager.LoadScene("OverworldScreen");
    }

    public void loadOverworld20HP(){
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

