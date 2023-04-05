using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextBattle()
    {
        Cursor.lockState = CursorLockMode.None;
        //Goes to load the BattleScreen
        SceneManager.LoadScene("BattleScreen");
    }

    public void loadMainMenu()
    {
        //Loads Main Menu
        SceneManager.LoadScene("MainMenu");
    }

    public void loadNewGame(){
        SceneManager.LoadScene("OverworldScreen");
    }

    public void loadOverworld(){
        SceneManager.LoadScene("OverworldScreen");
    }
}
