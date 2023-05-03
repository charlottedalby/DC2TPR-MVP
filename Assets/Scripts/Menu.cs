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
}
