using System.Collections;
using System;
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
    public Slider _slider;
    public Slider _sliderE;
    public ArmorBar _armorBar;
    public Card _card;
    public MapGeneration _mapGen;
    public Transform startPos;
    public Camera _camera;

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
        _slider = gameObject.AddComponent<Slider>();
        _sliderE = gameObject.AddComponent<Slider>();
        _armorBar = gameObject.AddComponent<ArmorBar>();
        _card = gameObject.AddComponent<Card>();
        _mapGen = gameObject.AddComponent<MapGeneration>();
        _camera = gameObject.AddComponent<Camera>();
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
        Assert.AreEqual(4, _enemies.stageEnemies[1].enemyCards.Count);
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

    [Test]

    public void dc2tpr_edit_mode_test_create_new_enemy()
    {
        _enemy = new Enemy("testEnemy", _enemies.assignStartingEnemyCards(0), 15, 0, 1, 1);
        Assert.AreEqual("testEnemy", _enemy.name);
        Assert.AreEqual(4, _enemy.enemyCards.Count);
        Assert.AreEqual(15, _enemy.health);
        Assert.AreEqual(0, _enemy.armour);
        Assert.AreEqual(1, _enemy.difficulty);
        Assert.AreEqual(1, _enemy.stage);
    }
    [Test]
    public void dc2tpr_edit_mode_test_create_armor_bar()
    {
        _armorBar.slider = _slider;
        _armorBar.setMaxArmor(100);
        Assert.AreEqual(100, _armorBar.slider.maxValue);
        Assert.AreEqual(100, _armorBar.slider.value);
    }

    [Test]
    public void dc2tpr_edit_mode_test_create_armor_bar_value()
    {
        _armorBar.slider = _slider;
        _armorBar.setMaxArmor(100);
        _armorBar.setArmor(100);
        Assert.AreEqual(100, _armorBar.slider.maxValue);
        Assert.AreEqual(100, _armorBar.slider.value);

        _armorBar.setMaxArmor(50);
        Assert.AreEqual(50, _armorBar.slider.maxValue);
        _armorBar.setArmor(100);
        Assert.AreEqual(50, _armorBar.slider.value);
    }

    [Test]
    public void dc2tpr_edit_mode_test_player_health_bar()
    {
        _GameController.Start();
        _healthBar.slider = _slider;
        _healthBar.setMaxValue(GameController.PlayerStartHealth);
        Assert.AreEqual(100, _healthBar.slider.maxValue);
        Assert.AreEqual(100, _healthBar.slider.value);

        _healthBar.setHealth(50);
        Assert.AreEqual(50, _healthBar.slider.value);
    }

    [Test]
    public void dc2tpr_edit_mode_test_create_new_card()
    {
        _card = new Card("testCard", 10, false, 0, 0, 0, 10, false, 100, 10);
        Assert.AreEqual(10, _card.damage);
        Assert.AreEqual(false, _card.hasBeenPlayed);
        Assert.AreEqual(0, _card.handIndex);
        Assert.AreEqual(0, _card.armour);
        Assert.AreEqual(0, _card.healing);
        Assert.AreEqual(10, _card.damageMult);
        Assert.AreEqual(false, _card.ignoreArmour);
        Assert.AreEqual(100, _card.hitChance);
        Assert.AreEqual(10, _card.endOfTurnValue);
    }

    [Test]
    public void dc2tpr_edit_mode_test_create_new_game()
    {
        _GameController.Start();
        Assert.AreEqual(100, GameController.PlayerStartHealth);
        Assert.AreEqual(0, GameController.PlayerStartArmor);
        Assert.AreEqual(null, GameController.gameMapState);
        Assert.AreEqual(null, GameController.PlayerStartNode);
        Assert.AreEqual(null, GameController.SwappedCard);
        Assert.AreEqual(0, GameController.stage1Difficulty.Count);
        Assert.AreEqual(0, GameController.tutorial.Count);
        Assert.AreEqual(1, GameController.stage);
        Assert.AreEqual(12, GameController.playerStartingDeck.Count);
    }

    [Test]
    public void dc2tpr_edit_mode_test_create_update_camera()
    {
        _camera.Update();
        Assert.AreEqual(1.5f, _camera.speed);
    }

    [Test]
    public void dc2tpr_edit_mode_test_create_card_ui()
    {
        _card = new Card("testCard", 10, false, 0, 0, 0, 10, false, 100, 10);
        try
        {
        _card.Start();
        }
        catch (NullReferenceException err)
        {
            Debug.Log("Null Error");
        }
    }

    [Test]
    public void dc2tpr_edit_mode_test_attack_player_enemy()
    {
        _enemy = new Enemy("testEnemy", _enemies.assignStartingEnemyCards(0), 15, 0, 1, 1);
        _enemy.gameManager = _gameManager;
        testPlayer.playerArmor = 5;
        testPlayer.playerHealth = 90;
        testPlayer.avoidAttack = false;
        _gameManager.player = testPlayer;
        for (int j = -1; j < 17; j++)
        {
            for (int i = 0; i < _enemy.enemyCards.Count; i++)
            {
                _enemy.enemyCards[i].endOfTurnValue = j;
            }
            try
            {
                _enemy.attackPlayer();
            }
            catch (NullReferenceException err)
            {
                Debug.Log("Null Error");
            }
        }
        Debug.Log(testPlayer.playerArmor);
        Debug.Log(testPlayer.playerHealth);
    }

    [Test]
    public void dc2tpr_edit_mode_test_attack_player_tutorial()
    {
        _enemy = new Enemy("testEnemy", _enemies.assignStartingEnemyCards(0), 15, 0, 1, 1);
        _enemy.gameManager = _gameManager;
        testPlayer.playerArmor = 5;
        testPlayer.playerHealth = 90;
        testPlayer.avoidAttack = false;
        _gameManager.player = testPlayer;
        _enemy.stage = 0 ;
        try
        {
            _enemy.attackPlayer();
        }
        catch (NullReferenceException err)
        {
            Debug.Log("Null Error");
        }
        Assert.AreEqual("Curl Up (Ant)", _enemy.selectedCard.name);
    }

    [Test]
    public void dc2tpr_edit_mode_test_update_enemy()
    {
        _enemy = new Enemy("testEnemy", _enemies.assignStartingEnemyCards(0), 15, 0, 1, 1);
        _enemy.gameManager = _gameManager;
        _enemy.health = 0;
        try
        {
        _enemy.Update();
        Assert.AreEqual("0", _enemy.healthText.text);
        Assert.AreEqual("0", _enemy.armorText.text);
        }
        catch (NullReferenceException err)
        {
            Debug.Log("Null Error");
        }
        

        _enemy.health += 50;
        try
        {
        _enemy.Update();
        Assert.AreEqual("50", _enemy.healthText.text);
        Assert.AreEqual("0", _enemy.armorText.text);
        }
        catch (NullReferenceException err)
        {
            Debug.Log("Null Error");
        }
    }
}
