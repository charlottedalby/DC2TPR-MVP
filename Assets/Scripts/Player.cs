using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int playerHealth;
    public int playerArmor;
    public int playerDamageMult;
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
        getStartingCards();
        
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

    public void enableHand(bool enable){
        if(enable == false){
            foreach (Card x in hand){
                x.gameObject.SetActive(false);
            }
        }
        else if(enable == true){
            foreach (Card y in hand)
            {
                y.gameObject.SetActive(true);
            }
        }
        
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

        //Instance.gameManager.enemy.health -= damage;

        damage = damage * Instance.gameManager.player.playerDamageMult;

        if (Instance.gameManager.enemy.armour > 0)
        {
            if (damage > Instance.gameManager.enemy.armour)
            {
                damage -= Instance.gameManager.enemy.armour;
                Instance.gameManager.enemy.armour = 0;
                Instance.gameManager.enemy.health -= damage;
                //healthBar.setHealth(gameManager.player.playerHealth);
            }
            else
            {
                Instance.gameManager.enemy.armour -= damage;
                //healthBar.setHealth(gameManager.player.playerHealth);
            }
        }
        else
        {
            //Reduce player health by the card's damage value
            Instance.gameManager.enemy.health -= damage;
            //healthBar.setHealth(gameManager.player.playerHealth);
        }
        // reset temporary damage multiplier
        Instance.gameManager.player.playerDamageMult = 1;
    }

    // new addition
    public void raiseArmor(int protection) {
        Instance.gameManager.player.playerArmor += protection;
        if(Instance.gameManager.player.playerArmor > 5){
            Instance.gameManager.player.playerArmor = 5;
            Instance.gameManager.armorBar.setArmor(Instance.gameManager.player.playerArmor);
        }
        Instance.gameManager.armorBar.setArmor(Instance.gameManager.player.playerArmor);
    }

    // new addition
    public void healPlayer(int healing) {
        Instance.gameManager.player.playerHealth += healing;
    }

    // new addition
    public void powerUp(int damageMult) {
        Instance.gameManager.player.playerDamageMult = damageMult;
    }

    public void getStartingCards()
    {
        for(int i = 0; i < GameController.playerStartingDeck.Count; i++) 
        {
            Card currentCard = GameController.playerStartingDeck[i];
            Instance.deck[i].name = currentCard.name;
            Instance.deck[i].damage = currentCard.damage;
            Instance.deck[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            Instance.deck[i].handIndex = currentCard.handIndex;
            Instance.deck[i].armour = currentCard.armour;
            //new addition
            Instance.deck[i].healing = currentCard.healing;
            Instance.deck[i].damageMult = currentCard.damageMult;
        }
    }
}
