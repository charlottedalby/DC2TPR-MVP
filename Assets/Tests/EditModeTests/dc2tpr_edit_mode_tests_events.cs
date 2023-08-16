using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class dc2tpr_edit_mode_tests_events
{
    private Player testPlayer;
    private GameObject gameObject;
    private GameManager _gameManager;
    private HealthBar _healthBar;
    private GameController _GameController;
    private Enemy _enemy;
    public Enemies _enemies;
    public Slider _slider;
    public ArmorBar _armorBar;
    public Card _card;
    public Event _event;
    public EventManager _eventManager;
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
        _armorBar = gameObject.AddComponent<ArmorBar>();
        _card = gameObject.AddComponent<Card>();
        _event = gameObject.AddComponent<Event>();
        _eventManager = gameObject.AddComponent<EventManager>();
        _menu = gameObject.AddComponent<Menu>();

        List<int> Event1 = new List<int>{1, 2, 3};
        List<int> Event2 = new List<int>{1, 2, 3};
        List<int> Event3 = new List<int>{1, 2, 3};
        List<int> Event4 = new List<int>{1, 2, 3};
        List<int> Event5 = new List<int>{1, 2, 3};
        List<int> Event6 = new List<int>{1, 2, 3};
        List<int> Event7 = new List<int>{1, 2, 3};
        List<int> Event8 = new List<int>{1, 2, 3};
        List<int> Event9 = new List<int>{1, 2, 3};

        _eventManager.Event1 = Event1;
        _eventManager.Event2 = Event1;
        _eventManager.Event3 = Event1;
        _eventManager.Event4 = Event1;
        _eventManager.Event5 = Event1;
        _eventManager.Event6 = Event1;
        _eventManager.Event7 = Event1;
        _eventManager.Event8 = Event1;
        _eventManager.Event9 = Event1;
        
        _eventManager.generateEvents();
        _eventManager.menu = _menu;
    }

    [Test]

    public void dc2tpr_edit_mode_test_create_new_event()
    {
        List<int> Event1 = new List<int>{1, 2, 3};
        _event = new Event(0, "testEvent", Event1, false);
        Assert.AreEqual(0, _event.EventID);
        Assert.AreEqual("testEvent", _event.Description);
        Assert.AreEqual(3, _event.Stages.Count);
        Assert.AreEqual(false, _event.Skipable);
    }

    [Test]
    public void dc2tpr_edit_mode_test_event_manager_generate_events()
    {   
        Assert.AreEqual(9, _eventManager.Events.Count);
        Assert.AreEqual("Inn - Heal 20% of missing health", _eventManager.Events[0].Description);
        Assert.AreEqual("Ambush - Take 5% of current Health", _eventManager.Events[1].Description);
        Assert.AreEqual("Potion Master - Either Heal 10 Health or Take 10 Damage", _eventManager.Events[2].Description);
        Assert.AreEqual("Merchant Boss - Swap Card out for a card from the boss stage", _eventManager.Events[3].Description);
        Assert.AreEqual("Merchant Lucky Dip  - Swap of enemy worst card or best card of enemy", _eventManager.Events[4].Description);
        Assert.AreEqual("Ambush - Take 15% current health damage but steal a card (Easy Enemy)", _eventManager.Events[5].Description);
        Assert.AreEqual("Cleric - Full Heal", _eventManager.Events[6].Description);
        Assert.AreEqual("Scout – Skip or reduce health by 20% and take a Hard Enemy Card ", _eventManager.Events[7].Description);
        Assert.AreEqual("Boss Battle Fight Boss from previous stage", _eventManager.Events[8].Description);
    }

    [Test]
    public void dc2tpr_edit_mode_test_event_1()
    {
        GameController.PlayerStartHealth = 80;
        _eventManager.runEvents(0);
        Assert.AreEqual(96, GameController.PlayerStartHealth);

        GameController.PlayerStartHealth = 100;
        _eventManager.runEvents(0);
        Assert.AreEqual(100, GameController.PlayerStartHealth);
    }
}
