using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class dc2tpr_play_mode_tests_1
{

    private Player testPlayer;
    private GameObject gameObject;
    private GameManager _gameManager;
    private HealthBar _healthBar;
    private GameController _GameController;
    private Enemy _enemy;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        testPlayer = gameObject.AddComponent<Player>();
        _gameManager = gameObject.AddComponent<GameManager>();
        _healthBar = gameObject.AddComponent<HealthBar>();
        _GameController = gameObject.AddComponent<GameController>();
        _enemy = gameObject.AddComponent<Enemy>();
    }

    [Test]
    public void dc2tpr_play_mode_tests_1_US0001()
    {
        //Start Game
        //_GameController.Start();
        //Check to see Starting Deck is 12
        Assert.AreEqual(12, GameController.playerStartingDeck.Count);
    }

    [Test]
    public void dc2tpr_play_mode_tests_1_US0002()
    {
        _enemy.Start();
    // _gameManager.Start();
        Assert.AreEqual(0, _enemy.health);
    }

}
