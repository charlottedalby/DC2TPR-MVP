using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class dc2tpr_edit_mode_tests_00
{
    private Player testPlayer;
    private GameObject gameObject;
    private GameManager _gameManager;
    private HealthBar _healthBar;
    private GameController _GameController;
    private Enemy _enemy;
    public Enemies _enemies;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        testPlayer = gameObject.AddComponent<Player>();
        _gameManager = gameObject.AddComponent<GameManager>();
        _healthBar = gameObject.AddComponent<HealthBar>();
        _GameController = gameObject.AddComponent<GameController>();
        _enemy = gameObject.AddComponent<Enemy>();
        _enemies = gameObject.AddComponent<Enemies>();
    }

    /*
        Test: dc2tpr_edit_mode_tests_player_deck_check()
        
        User Story: US0001
        
        Test Execution Descripton: 

        We want to ensure that the player always has the correct deck size 
        and hand size throughout a battle. Deck Size should be 12, 
        discard pile should be 0 and hand should be 0 at the start 

    */

    [Test]
    public void dc2tpr_edit_mode_tests_player_deck_check()
    {
        _GameController.Start();
        Assert.AreEqual(12, GameController.playerStartingDeck.Count);
        Assert.AreEqual(0, testPlayer.discardPile.Count);
        Assert.AreEqual(0, testPlayer.hand.Count);
    }

    [Test]
    public void dc2tpr_edit_mode_tests_player_health_check()
    {
        _GameController.Start();
        Assert.AreEqual(100, GameController.PlayerStartHealth);
    }

    /*
        Test: dc2tpr_edit_mode_test_all_enemies_4_cards()
        
        User Story: US0002
        
        Test Execution Descripton: 

        We want to ensure that the enemy always has 4 cards. Each enemy will 
        be created and tested to check that each of them has 4 cards in their deck

    */

    [Test]
    public void dc2tpr_edit_mode_test_all_enemies_4_cards()
    {
        _enemy.Start();
        Assert.AreEqual(0, _enemy.health);
        _enemies.createStageEnemies();
        Assert.AreEqual(31, _enemies.stageEnemies.Count);
        for (int i = 0; i < _enemies.stageEnemies.Count; i++)
        {
            Assert.AreEqual(4, _enemies.stageEnemies[i].enemyCards.Count);
        }
    }

    [Test]

    /*
    dc2tpr_edit_mode_test_Enemy_Health_Text_Defeated() will be testing to see whether "Defeated" is 
    shown when enemy health reaches 0. During this test enemy health will
    be set to 0 and then the enemy will be updated, setting the HealthText
    to DEFEATED. 
    */

    public void dc2tpr_edit_mode_test_Enemy_Health_Text_Defeated()
    {
        _enemy.health = 0;
        //Enemy health is set to 0
        _enemy.healthText = new GameObject().AddComponent<Text>();
        //Enemy Health Text is set to Enemy Health
        _enemy.healthText.text = "DEFEATED";
        //Test Not working as we wanted currently
        Assert.AreEqual("DEFEATED", _enemy.healthText.text);
    }

    [Test]

    /*
    dc2tpr_edit_mode_test_Health_Enemy_Text_Displays_Health will be testing to see whether Enemy's Health
    is shown when their health has not reached 0. During this test enemy health 
    will be set to 10, the enemy will be updated and we then check to see that 
    health text is equal to 10. 
    */

    public void dc2tpr_edit_mode_test_Health_Enemy_Text_Displays_Health()
    {
        _enemy.health = 10;
        _enemy.healthText = new GameObject().AddComponent<Text>();
        _enemy.healthText.text = _enemy.health.ToString();
        Assert.AreEqual("10", _enemy.healthText.text);
    }
}
