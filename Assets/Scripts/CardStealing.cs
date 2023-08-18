using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Class: CardStealing
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. cards: List of Cards in Players  Deck 

    Methods: 

    a. Start()
    b. AssignEnemyCards()

*/

public class CardStealing : MonoBehaviour
{
    
    public List<Card> cards = new List<Card>();

    /*
	    Method: Start()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Run AssignEnemyCards()
    */

    public void Start()
    {
        AssignEnemyCards();
    }

    /*
	    Method: AssignEnemyCards()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Iterate through GameController Enemy Starting Deck
        b. Create new Card currentCard and assign GameController Enemy Starting Deck [i] to it 
        c. cards [i] attributes equal to currentCard Attributes
    */

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
            cards[i].ignoreArmour = currentCard.ignoreArmour;
            cards[i].hitChance = currentCard.hitChance;
            cards[i].endOfTurnValue = currentCard.endOfTurnValue;
        }
    }
}
