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
        for(int i = 0; i < GameController.playerStartingDeck.Count; i++) 
        {
            Card currentCard = GameController.playerStartingDeck[i];
            Debug.Log(currentCard);
            cards[i] = currentCard;
            cards[i].name = currentCard.name;
            cards[i].damage = currentCard.damage;
            cards[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            cards[i].handIndex = currentCard.handIndex;
            cards[i].armour = currentCard.armour;
            //new addition
            cards[i].healing = currentCard.healing;
            cards[i].damageMult = currentCard.damageMult;
        }
    }
}
