using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class dc2tpr_edit_mode_tests_menu_tests
{
    public Menu _menu;
    public GameController _gameController;
    public  GameObject gameObject;
    public Animator mockAnimator;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        _gameController = gameObject.AddComponent<GameController>();
        _menu = gameObject.AddComponent<Menu>();

        mockAnimator = new GameObject().AddComponent<Animator>();
        _menu.animator = mockAnimator;
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_next_battle()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        _menu.NextBattle();
        
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("BattleScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_next_tutorial_battle()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        GameController.stage = 0;
        _menu.NextBattle();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("TutorialBattleScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_load_overworld()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        _menu.loadOverworld();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("OverworldScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_load_overworld_tutorial()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        GameController.stage = 0;
        _menu.loadOverworld();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("TutorialOverworldScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_load_tutorial()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        _menu.loadTutorial();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("TutorialOverworldScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_quit_game()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        _menu.exitGame();
        Assert.AreEqual(_menu.message, "Quitting Game");
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_load_main_menu()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        _menu.loadMainMenu();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("MainMenu", activeScene.name);
        Assert.AreEqual(null, GameController.PlayerStartNode);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_load_overworld_after_rest()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        GameController.PlayerStartHealth = 70; 
        _menu.loadOverworld20HP();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("OverworldScreen", activeScene.name);
        Assert.AreEqual(90, GameController.PlayerStartHealth);
    }
    [Test]
    public void dc2tpr_edit_mode_tests_menu_load_overworld_after_rest_2()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        GameController.PlayerStartHealth = 100; 
        _menu.loadOverworld20HP();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("OverworldScreen", activeScene.name);
        Assert.AreEqual(100, GameController.PlayerStartHealth);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_load_overworld_after_rest_tutorial()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        GameController.stage = 0;
        _menu.loadOverworld20HP();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("TutorialOverworldScreen", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_load_card_steal()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        _menu.loadCardSteal();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("CardStealing", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_menu_load_card_steal_tutorial()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        _gameController.Start();
        GameController.stage = -1;
        _menu.loadCardSteal();
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("MainMenu", activeScene.name);
    }
}
