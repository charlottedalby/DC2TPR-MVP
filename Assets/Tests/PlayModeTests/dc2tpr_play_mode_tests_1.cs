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
        gameObject = new GameObject("TestObject");
        testPlayer = gameObject.AddComponent<Player>();
        _gameManager = gameObject.AddComponent<GameManager>();
        _healthBar = gameObject.AddComponent<HealthBar>();
        _GameController = gameObject.AddComponent<GameController>();
        _enemy = gameObject.AddComponent<Enemy>();
    }

    [Test]
    public void dc2tpr_play_mode_tests_1_US0001()
    {
        /* 
            - AC1
                - Simulates Game Starting 
                - Checks to see Deck size is 12
                - Checks to see Discard Pile size is 0 
                - Checks to see Hand size is 0
        */
        _GameController.Start();
        Assert.AreEqual(12, GameController.playerStartingDeck.Count);
        Assert.AreEqual(0, testPlayer.discardPile.Count);
        Assert.AreEqual(0, testPlayer.hand.Count);
    }

}
