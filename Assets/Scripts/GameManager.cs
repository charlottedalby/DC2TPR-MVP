using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerHealth;
    public Text playerHealthText;
    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public List<Card> enemyCards = new List<Card>();
    public Transform[] cardSlots;
    public Transform enemyCardDisplay;
    public bool[] availableCardSlots;
    public Text deckSizeText;
    public Text discardSizeText;

    public Enemy enemy;


    public void Start(){
        enemy = FindObjectOfType<Enemy>();
        
        //Set up enemy cards
        foreach(Card enemyCard in enemyCards){
            enemyCard.gameObject.SetActive(true);
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
    void Update()
    {
        //Update all the text elements on the screen
        deckSizeText.text = deck.Count.ToString();
        discardSizeText.text = discardPile.Count.ToString();
        playerHealthText.text = playerHealth.ToString();

        //Check player health every frame to see if they have lost all health
        if(playerHealth <= 0){
            GameOver();
        }
    }

    public void attackEnemy(int damage){
        //Reduce enemy health by the playerCard's damage value
        enemy.health -= damage;
    }

    public void attackPlayer(){
        //Randomly select a card from enemyCards
        Card selectedCard = enemyCards[Random.Range(0, enemyCards.Count)];
        //Reduce player health by the card's damage value
        playerHealth -= selectedCard.damage;
        //Display the enemy's card on the screen for 2 seconds
        Vector3 initialPosition = selectedCard.transform.position;
        selectedCard.transform.position = enemyCardDisplay.position;
        //Move the card back off the screen
        StartCoroutine(MoveAfterWait(selectedCard, initialPosition));
        Debug.Log("Enemy Card Damage " + selectedCard.damage);
    }

    public IEnumerator MoveAfterWait(Card card, Vector3 position){
        //Create a wait of 2 seconds
        yield return new WaitForSeconds(2f);
        Debug.Log("Reached wait");
        //Move the card back to its initial position (off the screen)
        card.transform.position = position;
    }

    public void GameOver(){
        //Move all cards in the deck to the discardPile and make the gameObjects to be inactive
        for(int i = 0; i < deck.Count; i++){
            deck[i].MoveToDiscardPile();
            deck[i].gameObject.SetActive(false);
        }

        //Fix for the discard pile duplication bug
        deck.Clear();

        //Goes to You Win screen if enemy health reaches 0
        if(enemy.health <= 0){
            SceneManager.LoadScene("YouWin");
        }
        //Goes to Game Over screen if player health reaches 0
        else if(playerHealth <= 0){
            SceneManager.LoadScene("GameOver");
        }
    }
}
