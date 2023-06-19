using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class: ViewCardsUI
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. cards: List of Cards in Players  Deck 

    Methods: 

    a. Start()
    b. setUpCards

*/

public class ViewCardsUI : MonoBehaviour
{

    public List<Card> cards = new List<Card>();
    
    /*
	    Method: Start()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Run setUpCards()
    */

    public void Start()
    {
        setUpCards();
    }

    /*
	    Method: setUpCards()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Iterate through GameController playerStartingDeck
        b. Create new Card currentCard and assign GameController playerStartingDeck [i] to it 
        c. cards [i] attributes equal to currentCard Attributes
    */

    public void setUpCards()
    {
        for(int i = 0; i < GameController.playerStartingDeck.Count; i++) 
        {
            Card currentCard = GameController.playerStartingDeck[i];
            cards[i].name = currentCard.name;
            cards[i].damage = currentCard.damage;
            cards[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            cards[i].handIndex = currentCard.handIndex;
            cards[i].armour = currentCard.armour;
            cards[i].healing = currentCard.healing;
            cards[i].damageMult = currentCard.damageMult;
            cards[i].assignCardUI();
        }
    }
}
