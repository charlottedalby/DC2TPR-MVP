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

    /*
        Test: dc2tpr_play_mode_tests_1_US0001()
        
        User Story: US0001
        
        Test Execution Descripton: 

        We want to ensure that the player always has the correct deck size 
        and hand size throughout a battle.

        Pre-requisite: 

        The Player has entered a battle 

        Acceptance Criteria: 

        AC1: 
        
        When a player enters a battle, they should have a deck size of 12, 
        discard pile size of 0, and no cards visible in hand. There should be a 
        small pause before the player draws any cards from their deck
        
        AC2: 
        
        When a battle begins, the player should automatically draw 3 cards 
        from their deck.

        AC3: 

        When a player has drawn the first 3 cards of their deck, the player should 
        have a deck size of 9, discard pile size of 0, and have 3 cards viewable in 
        hand.

        AC4:

        Any cards drawn from the deck during the battle should be randomly chosen 
        from the deck.

    */

    [Test]
    public void dc2tpr_play_mode_tests_1_US0001()
    {
        _GameController.Start();
        Assert.AreEqual(12, GameController.playerStartingDeck.Count);
        Assert.AreEqual(0, testPlayer.discardPile.Count);
        Assert.AreEqual(0, testPlayer.hand.Count);
    }

    [Test]
    public void dc2tpr_play_mode_tests_1_US0002()
    {
        _enemy.Start();
    // _gameManager.Start();
        Assert.AreEqual(0, _enemy.health);
    }

}
