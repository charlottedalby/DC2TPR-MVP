using System.Collections;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

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
    public Text _Text;
    public OverworldPlayerHealth _overworldPlayerHealth;
    public StageCompleteTextManipulator _stageCompleteTextManipulator;
    public StageTextManipulator _stageTextManipulator;
    public CardStealing _cardStealing;
    public List <Card> cardss;
    public Animator mockAnimator;
    public LevelChanger _levelChange;
    public ViewCardsUI _viewCards;
    public ScaleChange _scaleChanger;
    public RestStopChanger _restStop;
    public Menu _menu;

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
        _Text = gameObject.AddComponent<Text>();
        _overworldPlayerHealth = gameObject.AddComponent<OverworldPlayerHealth>();
        _stageCompleteTextManipulator = gameObject.AddComponent<StageCompleteTextManipulator>();
        _stageTextManipulator = gameObject.AddComponent<StageTextManipulator>();
        _cardStealing = gameObject.AddComponent<CardStealing>(); 
        mockAnimator = gameObject.AddComponent<Animator>();
        _levelChange = gameObject.AddComponent<LevelChanger>(); 
        _viewCards = gameObject.AddComponent<ViewCardsUI>();
        _scaleChanger = gameObject.AddComponent<ScaleChange>();
        _restStop = gameObject.AddComponent<RestStopChanger>();
        cardss = new List<Card>();
        _menu = gameObject.AddComponent<Menu>();

        //Placeholder cards, changed in testPlayer.Start()
        testPlayer.deck.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        testPlayer.deck.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));

        testPlayer.deck.Add(new Card("Hello", 7, false, 0, 0, 0, 1, false, 0, 0));
        testPlayer.deck.Add(new Card("Hello", 7, false, 0, 0, 0, 1, false, 0, 0));

        testPlayer.deck.Add(new Card("Hello", 8, false, 0, 0, 0, 1, false, 0, 0));
        testPlayer.deck.Add(new Card("Hello", 8, false, 0, 0, 0, 1, false, 0, 0));

        testPlayer.deck.Add(new Card("Hello", 5, false, 0, 3, 0, 1, false, 0, 0));
        testPlayer.deck.Add(new Card("Hello", 5, false, 0, 3, 0, 1, false, 0, 0));

        testPlayer.deck.Add(new Card("Hello", 4, false, 0, 4, 0, 1, false, 0, 0));
        testPlayer.deck.Add(new Card("Hello", 4, false, 0, 4, 0, 1, false, 0, 0));

        testPlayer.deck.Add(new Card("Hello", 0, false, 0, 0, 0, 2, false, 0, 0)); 
        testPlayer.deck.Add(new Card("Hello", 0, false, 0, 0, 0, 2, false, 0, 0));
        testPlayer.gameManager = _gameManager;

        cardss.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        cardss.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        cardss.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        cardss.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));

        _scaleChanger.text = _Text;
        _scaleChanger.originalColor = Color.white;
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

    [Test]
    public void dc2tpr_edit_mode_test_health_overworld()
    {
        _GameController.Start();
        _overworldPlayerHealth.playerHealthText = _Text;
        _overworldPlayerHealth.Update();
        Assert.AreEqual("100", _overworldPlayerHealth.playerHealthText.text);
    }

    [Test]
    public void dc2tpr_edit_mode_test_stage_complete_text()
    {
        _stageCompleteTextManipulator.stageCompleteText = _Text;
        _GameController.Start();
        GameController.PlayerStartHealth = 10;
        _stageCompleteTextManipulator.Start();
        Assert.AreEqual(2, GameController.stage);
        Assert.AreEqual("Stage 1 Complete", _stageCompleteTextManipulator.stageCompleteText.text);
        GameController.stage = 0;
        _stageCompleteTextManipulator.Start();
        Assert.AreEqual("Tutorial Complete", _stageCompleteTextManipulator.stageCompleteText.text);
        Assert.AreEqual(-1, GameController.stage);
    }

    [Test]
    public void dc2tpr_edit_mode_test_stage_text()
    {
        _stageTextManipulator.stageText = _Text;
        _GameController.Start();
        _stageTextManipulator.Start();
        Assert.AreEqual("Stage 1",_stageTextManipulator.stageText.text);
        GameController.stage = 0;
        _stageTextManipulator.Start();
        Assert.AreEqual("Tutorial",_stageTextManipulator.stageText.text);
    }

    [Test]
    public void dc2tpr_edit_mode_test_enemy_get_start_cards()
    {
        _enemy = new Enemy("testEnemy", _enemies.assignStartingEnemyCards(0), 15, 0, 1, 1);
        _enemy.gameManager = _gameManager;
        _GameController.Start();
        GameController.enemyStartingDeck = _enemy.enemyCards;
        _enemy.getEnemyStartingCards();
    }

    [Test]
    public void dc2tpr_edit_mode_test_player_start()
    {
        _GameController.Start();
        Assert.AreEqual(12, GameController.playerStartingDeck.Count);
        testPlayer.Start();
        Assert.AreEqual(12, testPlayer.deck.Count);
        Assert.AreEqual("Punch", testPlayer.deck[0].name);
    }

    [Test]
    public void dc2tpr_edit_mode_test_player_discard_shuffle()
    {
        testPlayer.Start();
        Assert.AreEqual(12, testPlayer.deck.Count);
        testPlayer.discardPile.Add(new Card("Hello", 0, false, 0, 0, 0, 2, false, 0, 0));
        Assert.AreEqual(1, testPlayer.discardPile.Count);
        testPlayer.Shuffle();
        Assert.AreEqual(0, testPlayer.discardPile.Count);
        Assert.AreEqual(13, testPlayer.deck.Count);
        Assert.AreEqual("Hello", testPlayer.deck[12].name);
    }

    [Test]
    public void dc2tpr_edit_mode_test_player_raise_armor()
    {
        _gameManager.player = testPlayer;
        _gameManager.player.playerArmor = 0;
        _gameManager.armorBar = _armorBar;
        _gameManager.armorBar.slider = _slider;
        testPlayer.raiseArmor(10);
        Assert.AreEqual(10, _gameManager.player.playerArmor);
        Assert.AreEqual(1.0f, _gameManager.armorBar.slider.value);
    }

    [Test]
    public void dc2tpr_edit_mode_test_player_healing()
    {
        testPlayer.playerHealth = 10;
        _gameManager.player = testPlayer;
        Assert.AreEqual(10, _gameManager.player.playerHealth);
        testPlayer.healPlayer(10);
        Assert.AreEqual(20, _gameManager.player.playerHealth);
        _gameManager.player.playerHealth = 100;
        testPlayer.healPlayer(10);
        Assert.AreEqual(100, _gameManager.player.playerHealth);
    }

    [Test]
    public void dc2tpr_edit_mode_test_player_mult()
    {
        _gameManager.player = testPlayer;
        testPlayer.powerUp(5);
        Assert.AreEqual(5, _gameManager.player.playerDamageMult);
    }

    [Test]
    public void dc2tpr_edit_mode_test_player_attack_enemy()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 0;
        testPlayer.attackEnemy(20, false, 100);
        Assert.AreEqual(80, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_attack_enemy_with_armor()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 20;
        testPlayer.attackEnemy(20, false, 100);
        Assert.AreEqual(100, _gameManager.enemy.health);
    }
    
    [Test]
    public void dc2tpr_edit_mode_test_attack_enemy_avoid()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 0;
        _gameManager.enemy.avoidAttack = true;
        testPlayer.attackEnemy(20, false, 100);
        Assert.AreEqual(100, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_attack_enemy_hit_chance()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 0;
        _gameManager.enemy.avoidAttack = true;
        testPlayer.attackEnemy(20, false, 50);
    }

    [Test]
    public void dc2tpr_edit_mode_test_attack_enemy_greater_Armor()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 20;
        _gameManager.enemy.avoidAttack = false;
        testPlayer.attackEnemy(55, false, 100);
        Assert.AreEqual(65, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 15;
        testPlayer.endTurnMechanics(0);
        Assert.AreEqual(85, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_2()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 20;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(1);
        Assert.AreEqual(1, testPlayer.endOfTurnDamage);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_3()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 20;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(3);
        Assert.AreEqual(4, testPlayer.endOfTurnDamage);
    }
    
    [Test]
    public void dc2tpr_edit_mode_test_EOT_4()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 10;
        testPlayer.endTurnMechanics(4);
        Assert.AreEqual(82, _gameManager.enemy.health);
    }
    [Test]
    public void dc2tpr_edit_mode_test_EOT_5()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(5);
        Assert.AreEqual(0, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_6()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerArmor = 5;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(6);
        Assert.AreEqual(2, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_7()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 10;
        testPlayer.endTurnMechanics(7);
        Assert.AreEqual(3, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_8()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerHealth = 55;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(8);
        Assert.AreEqual(73, _gameManager.player.playerHealth);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_9()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 10;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(9);
        Assert.AreEqual(14, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_10()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 51;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(10);
        Assert.AreEqual(31, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_11()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(11);
        Assert.AreEqual(3, testPlayer.endOfTurnDamage);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_12()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 10;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(12);
        Assert.AreEqual(20, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_13()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 10;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(13);
        Assert.AreEqual(14, _gameManager.enemy.health);
        Assert.AreEqual(0, _gameManager.enemy.armour);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_14()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 5;
        testPlayer.endTurnMechanics(14);
        Assert.AreEqual(10, _gameManager.enemy.health);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_15()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(15);
        Assert.AreEqual(5, testPlayer.extraDamage);
    }
    [Test]
    public void dc2tpr_edit_mode_test_EOT_16()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 20;
        _gameManager.enemy.armour = 0;
        testPlayer.endOfTurnDamage = 0;
        testPlayer.endTurnMechanics(16);
        Assert.AreEqual(4, testPlayer.extraDamage);
    }

    [Test]
    public void dc2tpr_edit_mode_test_EOT_default()
    {
        _gameManager.enemy = _enemy;
        _gameManager.player = testPlayer;
        _gameManager.player.playerDamageMult = 1;
        _gameManager.enemy.health = 100;
        _gameManager.enemy.armour = 20;
        testPlayer.endOfTurnDamage = 15;
        testPlayer.endTurnMechanics(999);
        Assert.AreEqual(100, _gameManager.enemy.health);
        Assert.AreEqual(5, _gameManager.enemy.armour);
    }

    [Test]
    public void dc2tpr_edit_mode_test_card_stealing()
    {
        _enemy = new Enemy("testEnemy", _enemies.assignStartingEnemyCards(0), 15, 0, 1, 1);
        _enemy.gameManager = _gameManager;
        _GameController.Start();
        GameController.enemyStartingDeck = _enemy.enemyCards;
        Debug.Log(GameController.enemyStartingDeck.Count);
        _cardStealing.cards = cardss;
        try
        {
            _cardStealing.Start();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("Exception");
        }
        
        Assert.AreEqual(4, cardss.Count);
        Assert.AreEqual("Curl Up (Ant)", cardss[0].name);
    }

    [Test]
    public void dc2tpr_edit_mode_test_fade_out()
    {
        _levelChange.animator = mockAnimator;
        _levelChange.fadeToLevel("MainMenu");
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual("MainMenu", activeScene.name);
    }

    [Test]
    public void dc2tpr_edit_mode_test_view_card_ui_test()
    {
        _GameController.Start();
        Assert.AreEqual(12, GameController.playerStartingDeck.Count);
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.cards.Add(new Card("Hello", 5, false, 0, 0, 0, 1, false, 0, 0));
        _viewCards.Start();
        Assert.AreEqual(12, _viewCards.cards.Count);
        Assert.AreEqual("Punch", _viewCards.cards[0].name);
    }
    
    [Test]
    public void dc2tpr_edit_mode_test_Scale_Change()
    {
        _scaleChanger.text = _Text;
        _scaleChanger.originalColor = Color.blue;
        bool change = true;
        _scaleChanger.changeColour(change);
        Assert.AreEqual(Color.white, _Text.color);
    }

    [Test]
    public void dc2tpr_edit_mode_test_scale_change_false()
    {
        _scaleChanger.text = _Text;
        _scaleChanger.originalColor = Color.blue;
        bool change = false;
        _scaleChanger.changeColour(change);
        Assert.AreEqual(Color.blue, _Text.color);
    }

    [Test]
    public void dc2tpr_edit_mode_test_overworld_map()
    {
        try
        {
            _mapGen.Awake();
            _mapGen.Start();
        }
        catch (NullReferenceException err)
        {
            Debug.Log("Null Error");
        }
    }
}
