using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class dc2tpr_game_manager_test
{
   private GameManager _gameManager;
    private Enemy _enemy;
    private List<Card> _deck;
    private List<Card> _discardPile;
    private Text _deckSizeText;
    private Text _discardSizeText;
    private Transform[] _cardSlots;
    private bool[] _availableCardSlots;

    [SetUp]
    public void SetUp()
    {
        // create instances of the necessary components
        _gameManager = new GameObject().AddComponent<GameManager>();
        _enemy = new GameObject().AddComponent<Enemy>();
        _deck = new List<Card>();
        _discardPile = new List<Card>();
        _deckSizeText = new GameObject().AddComponent<Text>();
        _discardSizeText = new GameObject().AddComponent<Text>();
        _cardSlots = new Transform[1];
        _availableCardSlots = new bool[1];

        // initialize the values of the variables
        _gameManager.deck = _deck;
        _gameManager.discardPile = _discardPile;
        _gameManager.deckSizeText = _deckSizeText;
        _gameManager.discardSizeText = _discardSizeText;
        _gameManager.cardSlots = _cardSlots;
        _gameManager.availableCardSlots = _availableCardSlots;
        _gameManager.enemy = _enemy;
    }

    [Test]
    public void TestInitialize()
    {
        _gameManager.Initialize();
        Assert.AreEqual(_gameManager.enemy, _enemy);
    }

    [Test]
    public void TestDrawCard()
    {
        Card card = new GameObject().AddComponent<Card>();
        _deck.Add(card);
        _availableCardSlots[0] = true;
        _gameManager.Initialize();
        _gameManager.DrawCard();
        Assert.AreEqual(0, _deck.Count);
        Assert.AreEqual(false, _availableCardSlots[0]);
        Assert.AreEqual(card.handIndex, 0);
        Assert.AreEqual(card.transform.position, _cardSlots[0].position);
    }

    [Test]
    public void TestShuffleCard()
    {
        //Creates a New Card
        Card card = new GameObject().AddComponent<Card>();
        //Adds Card to Discard Pile        
        _discardPile.Add(card);
        //Shuffles Cards
        _gameManager.Shuffle();

        //Checks that Deck.Count is equal to 1, as 1 card has been added
        Assert.AreEqual(1, _deck.Count);
        //Checks that Discard Pile is now equal to 0 as Card has been removed 
        Assert.AreEqual(0, _discardPile.Count);
        //Checks that Card in Deck is Equal to Card orginally added 
        Assert.AreEqual(card, _deck[0]);
    }
}

