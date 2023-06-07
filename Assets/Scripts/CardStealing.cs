using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStealing : MonoBehaviour
{
    
    public List<Card> cards = new List<Card>();
    public bool cardSwap;
    public Card card;
    // Start is called before the first frame update
    void Start()
    {
        cardSwap = false;
        AssignEnemyCards();
    }

    public void AssignEnemyCards()
    {
        for(int i = 0; i < GameController.enemyStartingDeck.Count; i++) 
        {
            Card currentCard = GameController.enemyStartingDeck[i];
            cards[i].name = currentCard.name;
            cards[i].damage = currentCard.damage;
            cards[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            cards[i].handIndex = currentCard.handIndex;
            cards[i].armour = currentCard.armour;
            //new addition
            cards[i].healing = currentCard.healing;
            cards[i].damageMult = currentCard.damageMult;
            //cards[i].assignCardUI();
        }
    }
}
