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
        var gameManagerObject = new GameObject("GameManager");
        _gameManager = gameManagerObject.AddComponent<GameManager>();
        _gameManager.availableCardSlots = new bool[10];
        _gameManager.discardPile = new List<Card>();
        _gameManager.Initialize();
        
        var cardObject = new GameObject("Card");
        _card = cardObject.AddComponent<Card>();
        _damageText = new GameObject("DamageText").AddComponent<Text>();
        _damageText.transform.SetParent(cardObject.transform);
        _card.damageText = _damageText;
        _card.Initialize();

        var enemyObject = new GameObject("Enemy");
        _enemy = enemyObject.AddComponent<Enemy>();
        _enemy.Initialize();

    }

    [Test]
    public void TestCardDamageRange()
    {
        int damage = _card.damage;
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
        Debug.Log("test deck: " + _gameManager.deck.Count);
        _card.PlayCard();
        // Ensure that the card has been added to the discard pile and that it is no longer active
        
        Debug.Log("test discard pile: " +_gameManager.discardPile.Count);

        Assert.That(_gameManager.discardPile.Contains(_card), Is.True);
        Assert.That(_card.gameObject.activeSelf, Is.False);
    }
}
