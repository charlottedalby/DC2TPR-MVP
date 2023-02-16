using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class dc2tpr_intital_tests
{
    private GameManager _gameManager;
    private Card _card;
    private Enemy _enemy;
    private Text _damageText;

    [SetUp]
    public void SetUp()
    {
        //Creates a new Game Manager Object 
        var gameManagerObject = new GameObject("GameManager");
        
        //Creating a new Game Manager and Setting it up to have CardSlots and a Discard Pile
        _gameManager = gameManagerObject.AddComponent<GameManager>();
        _gameManager.availableCardSlots = new bool[10];
        _gameManager.discardPile = new List<Card>();

        //Game Manager is the Initialised
        _gameManager.Initialize();
        
        //Creates a new Card Object
        var cardObject = new GameObject("Card");
        _card = cardObject.AddComponent<Card>();
        //Initialises Card
        _card.Initialize();

        //Creates a New Enemy 
        var enemyObject = new GameObject("Enemy");
        _enemy = enemyObject.AddComponent<Enemy>();
        //Initialises Enemy
        _enemy.Initialize();

    }

    [Test]
    public void TestCardDamageRange()
    {
        //Sets Variable Damage to _card's damage
        int damage = _card.damage;

        //Checks to see that damage is between 1 and 6
        Assert.IsTrue(damage >= 1 && damage <= 6, "Card damage should be between 1 and 6 inclusive");
    }

    [Test]
    public void TestCardHasBeenPlayed()
    {
    // Ensure that the card's hasBeenPlayed property is false when the card is first created
    Assert.That(_card.hasBeenPlayed, Is.False);
    _card.hasBeenPlayed = true;
    // Ensure that the card's hasBeenPlayed property is true after the card has been played
    Assert.That(_card.hasBeenPlayed, Is.True);
    }

    [Test]
    public void TestCardMoveToDiscardPile()
    {
        //Initilises the Card
        _card.Initialize();
        
        //Mimics MoveToDiscardPile Method at the Moment
        _gameManager.discardPile.Add(_card);

        //Checks to see if the Discard Pile now Contains card
        Assert.That(_gameManager.discardPile.Contains(_card), Is.True);
    }
}
