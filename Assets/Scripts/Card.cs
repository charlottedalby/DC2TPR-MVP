using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int damage;
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gameManager;
    public Player player;
    public static Card Instance;
    public GameObject PLAYER;
    public int armour;
    // new addition
    public int healing;
    public int damageMult;
    public string name;

    public void Awake(){
        if (Instance == null) {
            //First run, set the instance
            Instance = this;
            DontDestroyOnLoad(gameObject);
 
        } else if (Instance != this) {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            //Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void Start()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        assignCardUI();
    }

    public Card (string name, int damage, bool hasBeenPlayed, int handIndex, int armour, int healing, int damageMult)
    {
        this.name = name;
        this.damage = damage;
        this.hasBeenPlayed = hasBeenPlayed;
        this.handIndex = handIndex;
        this.armour = armour;
        //new addition
        this.healing = healing;
        this.damageMult = damageMult;
    }

    void OnMouseDown(){
        //If the Card has been clicked on and hasn't been played yet
        //If the View Card Scene is not active
        if(hasBeenPlayed == false){
        //Attack the enemy
        gameManager.player.attackEnemy(damage);
        //New addition, raise player's armour
        gameManager.player.raiseArmor(armour);
        //New addition, heal player's health
        gameManager.player.healPlayer(healing);
        //New addition, changes damage multiplier
        gameManager.player.powerUp(damageMult);
        

        //Move the card up so we can see that it has been played
        transform.position += Vector3.up * 5;
        Cursor.lockState = CursorLockMode.Locked;
        //Set hasBeenPlayed to true
        hasBeenPlayed = true;
        //Make the slot the card was in available again
        gameManager.player.availableCardSlots[handIndex] = true;
        //Move the card to the discardPile
        gameManager.player.Invoke("discardHand", 2f);
        //Invoke("MoveToDiscardPile", 2f);
        gameManager.enemy.Invoke("attackPlayer", 2f);
        }
    }

    public void MoveToDiscardPile()
    {
        if (gameManager.player.discardPile.Count < 12){
            //Fix for the nullReference errors
            if (gameManager == null) {
                this.gameManager = FindObjectOfType<GameManager>();
            }
            //Add the Card to the discardPile and set the card to inactive
            gameManager.player.discardPile.Add(this);
            //gameObject.SetActive(false);
            //Invoke the enemy to attack the player
            gameManager.enemy.Invoke("attackPlayer", 2f);
        }
    }
    
    public void assignCardUI()
    {
        //Add Cards to Card Dictionary 
        Dictionary<string, string> cardSpriteMap = new Dictionary<string, string>()
        {
            { "Punch", "Punch" },
            { "Kick", "Kick" },
            { "Jump Kick", "Jump Kick" },
            { "Throw", "Throw" },
            { "Grapple", "Grapple" },
            { "Meditate", "Meditate" },
            { "Clamp Down", "Clamp Down" },
            { "Scurry", "Scurry" },
            { "Tail Strike", "Tail Strike" },
            { "Peck", "Peck" },
            { "Home In", "Home In" },
            { "Roost", "Roost" },
            { "Wing Defence", "Wing Defence" },
            { "Rear Kick", "Rear Kick" },
            { "Run Away", "Run Away" },
            { "Keen Sense", "Keen Sense" },
            { "Intimidate", "Intimidate" },
            { "Feather Dance", "Feather Dance" },
            { "Flock Attack", "Flock Attack" },
            { "Hound", "Hound" },
            { "Bite", "Bite" },
            { "Pounce", "Pounce" },
            { "Bare Teeth", "Bare Teeth" },
            { "Camouflage", "Camouflage" },
            { "Tail Lash", "Tail Lash" },
            { "Shed Tail", "Shed Tail" },
            { "Use Tools", "Use Tools" },
            { "Gouge", "Gouge" },
            { "Swing High", "Swing High" },
            { "Pummel", "Pummel" },
            { "Thick Skin", "Thick Skin" },
            { "Trample", "Trample" },
            { "Roll Around", "Roll Around" },
            { "Sniff Out", "Sniff Out" },
            { "Clamp", "Clamp" },
            { "Exoskeleton", "Exoskeleton" },
            { "Envenom", "Envenom" },
            { "Spin Web", "Spin Web" },
            { "Fang Strike", "Fang Strike" },
            { "Pin down", "Pin down" },
            { "Snap", "Snap" },
            { "Slow Start", "Slow Start" },
            { "Shell Attack", "Shell Attack" },
            { "Shell Armour", "Shell Armour" },
            { "Pincer", "Pincer" },
            { "Team Attack", "Team Attack" },
            { "Curl Up", "Curl Up" },
            { "Attempt Flight", "Attempt Flight" },
            { "Scramble", "Scramble" },
            { "Gnaw", "Gnaw" }
        };
        //Create an array of all cards present in scene 
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        //Iterate through array of cards 
        foreach (GameObject card in cards)
        {
            //Get Card Component of the game object
            Card currentCard = card.GetComponent<Card>();
            //If the card name is not null and the dictionary contains the card name 
            if(currentCard.name != null && cardSpriteMap.ContainsKey(currentCard.name))
            {
                //Get Current card image
                Image cardImage = currentCard.GetComponent<Image>();
                //Create new Card image from loaded cards, corresponding to card.name
                Sprite newSprite = GameObject.Find(cardSpriteMap[currentCard.name]).GetComponent<Image>().sprite;
                //Change image to new card image 
                cardImage.sprite = newSprite;
            }
        }
    }
}
