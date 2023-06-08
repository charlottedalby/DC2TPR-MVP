using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCardsUI : MonoBehaviour
{

    public List<Card> cards = new List<Card>();
    
    public void Start()
    {
        setUpCards();
    }

    

    public void setUpCards()
    {
        Debug.Log(GameController.playerStartingDeck.Count);
        for(int i = 0; i < GameController.playerStartingDeck.Count; i++) 
        {
            Card currentCard = GameController.playerStartingDeck[i];
            cards[i].name = currentCard.name;
            Debug.Log(cards[i].name);
            cards[i].damage = currentCard.damage;
            cards[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            cards[i].handIndex = currentCard.handIndex;
            cards[i].armour = currentCard.armour;
            //new addition
            cards[i].healing = currentCard.healing;
            cards[i].damageMult = currentCard.damageMult;
            cards[i].assignCardUI();
        }
    }
}
