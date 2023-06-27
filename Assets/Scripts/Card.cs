using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Class: Card
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. damage: Card Damage
    b. hasBeenPlayed: Indicator showing if card has been played
    c. handIndex: Position of Card in Deck
    d. gameManager: Game Manager Instance 
    e. player: Player Instance
    f. Instance: card Instance
    g. armour: Card Armor
    h. healing: Card Healing 
    i. damageMult: Card Damage Multiplier 
    j. name: Card Name

    Methods: 

    a. Awake()
    b. Start()
    c. Card()
    d. OnMouseDown()
    e. MoveToDiscardPile()
    f. assignCardUI()
*/

public class Card : MonoBehaviour
{
    
    public int damage;
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gameManager;
    public Player player;
    public static Card Instance;
    public int armour;
    public int healing;
    public int damageMult;
    public string name;
    public bool ignoreArmour;
    public int hitChance;

    /*
        Method: Awake()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Create Instance of Card
        b. Set this equal to Instance
        c. If this is not equal to Instance then Instance equals this 
        d. Keep GameObject when Scene is loaded 
    */

    public void Awake(){
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
 
        } 
        else if (Instance != this) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /*
        Method: Start()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Find Player in Scene
        b. Find Game Manager in Scene
        c. Import Card UI's
    */

    public void Start()
    { 
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        assignCardUI();
    }

    /*
        Method: Card ()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Card Constructor 
        b. Sets all attributes for Card
    */

    public Card (string name, 
    int damage, 
    bool hasBeenPlayed, 
    int handIndex, 
    int armour, 
    int healing, 
    int damageMult,
    bool ignoreArmour,
    int hitChance)

    {
        this.name = name;
        this.damage = damage;
        this.hasBeenPlayed = hasBeenPlayed;
        this.handIndex = handIndex;
        this.armour = armour;
        this.healing = healing;
        this.damageMult = damageMult;
        this.ignoreArmour = ignoreArmour;
        this.hitChance = hitChance;
    }

    /*
        Method: OnMouseDown()
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. If the Card has been clicked on and hasn't been played yet
        b. Attack Enemy with Damage of Card
        c. Raise player's armor with Card Armor 
        d. Heal Player with Card Healing 
        e. Raise Damage Multiplier with Card Damage Multiplier 
        f. Move Card to New Position, indicating Card being played
        g. Lock Cursor so Player cannot player another card
        h. Set Card hasBeenPlayed indicator to true
        i. Make played card slot avalible to new cards from deck
        j. Dicard Players Hand to discard pile
        k. Start Enemy Attack sequence 
    */

    void OnMouseDown(){
        if(hasBeenPlayed == false)
        {
        gameManager.player.attackEnemy(damage, ignoreArmour, hitChance);
        gameManager.player.raiseArmor(armour);
        gameManager.player.healPlayer(healing);
        gameManager.player.powerUp(damageMult);
        
        transform.position += Vector3.up * 5;
        Cursor.lockState = CursorLockMode.Locked;
        hasBeenPlayed = true;

        gameManager.player.availableCardSlots[handIndex] = true;
        gameManager.player.Invoke("discardHand", 2f);
        gameManager.enemy.Invoke("attackPlayer", 2f);
        }
    }

    /*
        Method: MoveToDiscardPile()
        Visibility: Public  
        Output: N/A
        Purpose: 

        a. If Players Discard Pile is Less than Size 12
        b. If Game Manager is null, find Game Manager in Scene 
        c. Add Card to Discard Pile 
        d. Start Enemy Attack sequence 
    */

    public void MoveToDiscardPile()
    {
        if (gameManager.player.discardPile.Count < 12)
        {
            if (gameManager == null) 
            {
                this.gameManager = FindObjectOfType<GameManager>();
            }
            gameManager.player.discardPile.Add(this);
            gameManager.enemy.Invoke("attackPlayer", 2f);
        }
    }
    
    /*
        Method: assignCardUI()
        Visibility: Public  
        Output: N/A
        Purpose: 

        a. Create Card Dictionary 
        b. Populate Card Dictionary with Card Name and CardUI Name
        c. Add all cards in current Scene to an Array 
        d. Iterate through Cards in Scene 
        e. Get Card attributes of each card
        f. If Card name is not null and Card dictionary contains Card Name
        g. Current Card Image equals New Card Image 
    */

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

        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        
        foreach (GameObject card in cards)
        {
            Card currentCard = card.GetComponent<Card>();
            if(currentCard.name != null && cardSpriteMap.ContainsKey(currentCard.name))
            {
                Image cardImage = currentCard.GetComponent<Image>();
                Sprite newSprite = GameObject.Find(cardSpriteMap[currentCard.name]).GetComponent<Image>().sprite;
                cardImage.sprite = newSprite;
            }
        }
    }
}
