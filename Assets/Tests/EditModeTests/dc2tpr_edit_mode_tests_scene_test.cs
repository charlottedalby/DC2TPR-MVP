using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Diagnostics;

public class dc2tpr_edit_mode_tests_scene_test
{
    public Stopwatch stopwatch;
    public long maxTime;
    [SetUp]
    public void Setup()
    {
        stopwatch = new Stopwatch();
        maxTime = 1500;
    }
    [Test]
    public void dc2tpr_edit_mode_tests_scene_main_menu_displayed()
    {
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Scene 
        Assert.AreEqual("MainMenu", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_overworld_scene_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/OverworldScreen.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Scene   
        Assert.AreEqual("OverworldScreen", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_battle_scene_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/BattleScreen.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Scene  
        Assert.AreEqual("BattleScreen", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }
    
    [Test]
    public void dc2tpr_edit_mode_tests_scene_game_over_scene_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/GameOver.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Scene  
        Assert.AreEqual("GameOver", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_you_win_scene_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/YouWin.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("YouWin", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_card_stealing_scene_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/CardStealing.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("CardStealing", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_Demo_scene_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/DemoScene.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("DemoScene", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_Event_Stop_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/EventStop.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("EventStop", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_Game_Complete_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/GameComplete.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("GameComplete", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_Player_Card_Steal_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/PlayerCardStealScreen.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("PlayerCardStealScreen", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_stage_complete_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/StageComplete.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("StageComplete", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_tutorial_battle_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/TutorialBattleScreen.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("TutorialBattleScreen", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_tutorial_help_displayed()
    {
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/TutorialHelp.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("TutorialHelp", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_scene_tutorial_overworld_displayed(){
        stopwatch.Start();
        EditorSceneManager.OpenScene("Assets/Scenes/TutorialOverworldScreen.unity");
        stopwatch.Stop();
        //Sets Active Scene to Current Loadded Scene 
        Scene activeScene = SceneManager.GetActiveScene();
        //Checks Active Scene is Correct Screen
        Assert.AreEqual("TutorialOverworldScreen", activeScene.name);
        UnityEngine.Debug.Log($"Scene load time: {stopwatch.ElapsedMilliseconds} ms");
        Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxTime, $"Scene load time exceeded{maxTime} ms.");
    }
}

