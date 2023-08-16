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
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Scene 
        Assert.AreEqual("MainMenu", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_overworld_scene_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/OverworldScreen.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Scene   
        Assert.AreEqual("OverworldScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_battle_scene_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/BattleScreen.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Scene  
        Assert.AreEqual("BattleScreen", activeScene.name);
    }
    
    [Test]
    public void dc2tpr_edit_mode_tests_scene_game_over_scene_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/GameOver.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Scene  
        Assert.AreEqual("GameOver", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_you_win_scene_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/YouWin.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("YouWin", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_card_stealing_scene_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/CardStealing.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("CardStealing", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_Demo_scene_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/DemoScene.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("DemoScene", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_Event_Stop_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/EventStop.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("EventStop", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_Game_Complete_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/GameComplete.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("GameComplete", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_Player_Card_Steal_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/PlayerCardStealScreen.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("PlayerCardStealScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_stage_complete_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/StageComplete.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("StageComplete", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_tutorial_battle_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/TutorialBattleScreen.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("TutorialBattleScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_tutorial_help_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/TutorialHelp.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("TutorialHelp", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_tutorial_overworld_displayed(){
        EditorSceneManager.OpenScene("Assets/Scenes/TutorialOverworldScreen.unity");
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("TutorialOverworldScreen", activeScene.name);
    }
}

