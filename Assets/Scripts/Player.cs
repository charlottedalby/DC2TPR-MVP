using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int playerHealth;
    public int playerArmour;
    //public Text playerHealthText;
    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    //New to MVP - separate hand variable
    public List<Card> hand = new List<Card>();    
    public bool[] availableCardSlots;
    //public Text deckSizeText;
    //public Text discardSizeText;
    public Transform[] cardSlots;

    public GameManager gameManager;

    public void Awake(){
        
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        

        if (Instance == null) {
            //First run, set the instance
            Instance = this;
            //DontDestroyOnLoad(gameObject);
 
        } else if (Instance != this) {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            //Destroy(Instance.gameObject);
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Instance.gameManager = FindObjectOfType<GameManager>();
        playerArmour = 0;
    }

     void Update()
    {
    }

    public void DrawCard(){
        Cursor.lockState = CursorLockMode.None;
        //Note: new for MVP - draw 3 cards at start of turn
        for(int j = 0; j < availableCardSlots.Length; j++){
            //Randomly assign Cards to gameObjects in deck
            if(Instance.deck.Count >= 1){
                Card randCard = Instance.deck[Random.Range(0, deck.Count)];
                //Check the card slots on screen
                for(int i = 0; i < Instance.availableCardSlots.Length; i++){
                    //If the slot is available (no card displayed there), then move the card to the slot and remove it from the deck
                    if(Instance.availableCardSlots[i] == true){
                        randCard.hasBeenPlayed = false;
                        randCard.gameObject.SetActive(true);
                        randCard.handIndex = i;
                        randCard.transform.position = cardSlots[i].position;
                        Instance.availableCardSlots[i] = false;
                        Instance.hand.Add(randCard);
                        Instance.deck.Remove(randCard);
                        break;
                    }
                }
            }
        }
    }

    //New for MVP - discarding all cards at the end of turn
    public void discardHand(){
        for(int i = 0; i < Instance.availableCardSlots.Length; i++){
            Card currentCard = Instance.hand[i];
            Instance.discardPile.Add(currentCard);
            currentCard.gameObject.transform.position += Vector3.up * 25;
            Instance.availableCardSlots[i] = true;
        }
        Instance.hand.Clear();

        //Once hand is discarded, draw more cards - if deck is empty, shuffle first
        if(Instance.deck.Count <= 0){
            Shuffle();
        }
        Invoke("DrawCard", 2f);
        
        
    }

    public void Shuffle(){
        //If there's at least one card in the discardPile, move all cards in the discardPile back into the deck
        if(Instance.discardPile.Count >= 1){
            foreach(Card card in Instance.discardPile){
                Instance.deck.Add(card);
            }
            Instance.discardPile.Clear();
        }
    }

    public void attackEnemy(int damage){
        //Reduce enemy health by the playerCard's damage value
        Instance.gameManager.enemy.health -= damage;
    }

    public void discardDeck(){
        //Discards Deck and Hand to Discard Pile
        //Move all cards in the deck to the discardPile and make the gameObjects to be inactive
        while (Instance.discardPile.Count < 12){
            foreach(Card card in Instance.deck){
                Instance.discardPile.Add(card);
            }
        
            foreach(Card hcard in Instance.hand){
                Instance.discardPile.Add(hcard);
            }
        } 
    }

    public void storeStartingDeck(){
        //Stored players starting deck 
        if (Instance.discardPile.Count == 12){
            //Store damages in GameController.StartingDeck
            foreach(Card cards in Instance.discardPile){
                GameController.StartingDeck.Add(cards);
            }
        }
    }
}
