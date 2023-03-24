using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int playerHealth;
    public Text playerHealthText;
    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();    
    public bool[] availableCardSlots;
    public Text deckSizeText;
    public Text discardSizeText;
    public Transform[] cardSlots;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

     void Update()
    {
        //Update all the text elements on the screen
        deckSizeText.text = deck.Count.ToString();
        discardSizeText.text = discardPile.Count.ToString();

        //Check player health every frame to see if they have lost all health
        if(playerHealth <= 0){
            playerHealthText.text = "0";
            //Call GameOver method
            gameManager.Invoke("GameOver", 2f);
        }
        //Else if player is not dead, update their health text
        else if(playerHealth > 0){
            playerHealthText.text = playerHealth.ToString();
        } 
    }

    public void DrawCard(){
        //Randomly assign Cards to gameObjects in deck
        if(deck.Count >= 1){
            Card randCard = deck[Random.Range(0, deck.Count)];

            //Check the card slots on screen
            for(int i = 0; i < availableCardSlots.Length; i++){
                //If the slot is available (no card displayed there), then move the card to the slot and remove it from the deck
                if(availableCardSlots[i] == true){
                    randCard.hasBeenPlayed = false;
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex = i;
                    randCard.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }

    public void Shuffle(){
        //If there's at least one card in the discardPile, move all cards in the discardPile back into the deck
        if(discardPile.Count >= 1){
            foreach(Card card in discardPile){
                deck.Add(card);
            }
            discardPile.Clear();
        }
    }

    public void attackEnemy(int damage){
        //Reduce enemy health by the playerCard's damage value
        gameManager.enemy.health -= damage;
    }
}