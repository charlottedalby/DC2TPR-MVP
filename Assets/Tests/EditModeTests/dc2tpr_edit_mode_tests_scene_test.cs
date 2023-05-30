using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class dc2tpr_edit_mode_tests_scene_test
{
    [Test]
    public void dc2tpr_edit_mode_tests_scene_main_menu_displayed()
    {
        //Loads Main Menu
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is MainMenu 
        Assert.AreEqual("MainMenu", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_overworld_scene_displayed(){
        //Loads Main Menu
        EditorSceneManager.OpenScene("Assets/Scenes/OverworldScreen.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Overworld Scene   
        Assert.AreEqual("OverworldScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_battle_scene_displayed(){
        //Loads Main Menu
        EditorSceneManager.OpenScene("Assets/Scenes/BattleScreen.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Battle Screen  
        Assert.AreEqual("BattleScreen", activeScene.name);
    }
    
    [Test]
    public void dc2tpr_edit_mode_tests_scene_game_over_scene_displayed(){
        //Loads Main Menu
        EditorSceneManager.OpenScene("Assets/Scenes/GameOver.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is gameOver  
        Assert.AreEqual("GameOver", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_you_win_scene_displayed(){
        //Loads Main Menu
        EditorSceneManager.OpenScene("Assets/Scenes/YouWin.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is YouWin Screen 
        Assert.AreEqual("YouWin", activeScene.name);
    }
}

