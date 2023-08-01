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
    k. ignoreArmor: Boolean operator to signify if the card will ignore armor 
    l. hitChance: Chance of the card hitting the opponent
    m. transformPo: position of card in scene ]
    n. yes: true or false variable checking if card needs hovering over

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
    public int armour;
    public int healing;
    public int damageMult;
    public string name;
    public bool ignoreArmour;
    public int hitChance;
    public int endOfTurnValue;
    public Vector3 tranformPos;
    bool yes;
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
        yes = false;
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        assignCardUI();
        tranformPos = transform.position;
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
    int hitChance,
    int endOfTurnValue)

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
        this.endOfTurnValue = endOfTurnValue;
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
            hasBeenPlayed = true;
            gameManager.player.attackEnemy(damage, ignoreArmour, hitChance);
            gameManager.player.raiseArmor(armour);
            gameManager.player.healPlayer(healing);
            gameManager.player.powerUp(damageMult);
            gameManager.player.endTurnMechanics(endOfTurnValue);

            transform.position = player.playerCardDisplay.position;
            Cursor.lockState = CursorLockMode.Locked;

            gameManager.player.availableCardSlots[handIndex] = true;
            gameManager.player.Invoke("discardHand", 2f);
            gameManager.enemy.Invoke("attackPlayer", 2f);
        }
    }

    void OnMouseEnter()
    {
        tranformPos = transform.position;
        if(!yes)
        {
            transform.position += Vector3.up * 1;
            yes = true;
        }
    }

    void OnMouseExit()
    {
        if(hasBeenPlayed == false)
        {
            transform.position = tranformPos;
        }
        yes = false;
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
            
            {"Curl Up (Ant)", "Curl Up (Ant)"},
            {"Exoskeleton (Ant)", "Exoskeleton (Ant)"},
            {"Pincer (Ant)", "Pincer (Ant)"},
            {"Team Attack (Ant)", "Team Attack (Ant)"},

            {"Attempt Flight (Cockroach)", "Attempt Flight (Cockroach)"},
            {"Curl Up (Cockroach)", "Curl Up (Cockroach)"},
            {"Pincer (Cockroach)", "Pincer (Cockroach)"},
            {"Scramble (Cockroach)", "Scramble (Cockroach)"},
            
            {"Bare Teeth (Dog)", "Bare Teeth (Dog)"},
            {"Bite (Dog)", "Bite (Dog)"},
            {"Hound (Dog)", "Hound (Dog)"},
            {"Pounce (Dog)", "Pounce (Dog)"},

            {"Bite (Lizard)", "Bite (Lizard)"},
            {"Camouflage (Lizard)", "Camouflage (Lizard)"},
            {"Shed Tail (Lizard)", "Shed Tail (Lizard)"},
            {"Tail Lash (Lizard)", "Tail Lash (Lizard)"},

            {"Gouge (Monkey)", "Gouge (Monkey)"},
            {"Pummel (Monkey)", "Pummel (Monkey)"},
            {"Swing High (Monkey)", "Swing High (Monkey)"},
            {"User Tools (Monkey)", "User Tools (Monkey)"},

            {"Clamp Down (Mouse)", "Clamp Down (Mouse)"},
            {"Gnaw (Mouse)", "Gnaw (Mouse)"},
            {"Scurry (Mouse)", "Scurry (Mouse)"},
            {"Tail Strike (Mouse)", "Tail Strike (Mouse)"},

            {"Roll Around (Pig)", "Roll Around (Pig)"},
            {"Sniff Out (Pig)", "Sniff Out (Pig)"},
            {"Thick Skin (Pig)", "Thick Skin (Pig)"},
            {"Trample (Pig)", "Trample (Pig)"},

            {"Home In (Pigeon)", "Home In (Pigeon)"},
            {"Peck (Pigeon)", "Peck (Pigeon)"},
            {"Roost (Pigeon)", "Roost (Pigeon)"},
            {"Wing Defence (Pigeon)", "Wing Defence (Pigeon)"},

            {"Gnaw (Rabbit)", "Gnaw (Rabbit)"},
            {"Keen Sense (Rabbit)", "Keen Sense (Rabbit)"},
            {"Rear Kick (Rabbit)", "Rear Kick (Rabbit)"},
            {"Run Away (Rabbit)", "Run Away (Rabbit)"},

            {"Clamp Down (Rat)", "Clamp Down (Rat)"},
            {"Gnaw (Rat)", "Gnaw (Rat)"},
            {"Scurry (Rat)", "Scurry (Rat)"},
            {"Tail Strike (Rat)", "Tail Strike (Rat)"},

            {"Feather Dance (Rooster)", "Feather Dance (Rooster)"},
            {"Flock Attack (Rooster)", "Flock Attack (Rooster)"},
            {"Intimidate (Rooster)", "Intimidate (Rooster)"},
            {"Peck (Rooster)", "Peck (Rooster)"},

            {"Clamp (Scorpion)", "Clamp (Scorpion)"},
            {"Evnvenom (Scorpion)", "Evnvenom (Scorpion)"},
            {"Exoskeleton (Scorpion)", "Exoskeleton (Scorpion)"},
            {"Tail Lash (Scorpion)", "Tail Lash (Scorpion)"},

            {"Spin Web (Tarantula)", "Spin Web (Tarantula)"},
            {"Envenom (Tarantula)", "Envenom (Tarantula)"},
            {"Fang Strike (Tarantula)", "Fang Strike (Tarantula)"},
            {"Pin Down (Tarantula)", "Pin Down (Tarantula)"},

            {"Shell Armor (Turtle)", "Shell Armor (Turtle)"},
            {"Shell Attack (Turtle)", "Shell Attack (Turtle)"},
            {"Slow Start (Turtle)", "Slow Start (Turtle)"},
            {"Snap (Turtle)", "Snap (Turtle)"},


            {"Wrap (Jellyfish)", "Wrap (Jellyfish)"},
            {"Sting (Jellyfish)", "Sting (Jellyfish)"},
            {"Float Away (Jellyfish)", "Float Away (Jellyfish)"},
            {"Compound Poison (Jellyfish)", "Compound Poison (Jellyfish)"},

            {"Talon Grab (Eagle)", "Talon Grab (Eagle)"},
            {"Wing Strike (Eagle)", "Wing Strike (Eagle)"},
            {"Tear Away (Eagle)", "Tear Away (Eagle)"},
            {"Glide (Eagle)", "Glide (Eagle)"},

            {"Ram (Goat)", "Ram (Goat)"},
            {"Horn (Goat)", "Horn (Goat)"},
            {"Rear Kick (Goat)", "Rear Kick (Goat)"},
            {"Bite (Goat)", "Bite (Goat)"},

            {"Poison Sting (Hornet)", "Poison Sting (Hornet)"},
            {"Buzz Around (Hornet)", "Buzz Around (Hornet)"},
            {"Swarm (Hornet)", "Swarm (Hornet)"},
            {"Sharp Poison (Hornet)", "Sharp Poison (Hornet)"},

            {"Gallop (Horse)", "Gallop (Horse)"},
            {"Trample (Horse)", "Trample (Horse)"},
            {"Rear Kick (Horse)", "Rear Kick (Horse)"},
            {"Run Away (Horse)", "Run Away (Horse)"},

            {"Grab and Tear (Hyena)", "Grab and Tear (Hyena)"},
            {"Bite (Hyena)", "Bite (Hyena)"},
            {"Pack Tactics (Hyena)", "Pack Tactics (Hyena)"},
            {"Hunt Down (Hyena)", "Hunt Down (Hyena)"},

            {"Roar (Tiger)", "Roar (Tiger)"},
            {"Pounce (Tiger)", "Pounce (Tiger)"},
            {"Claw Swipe (Tiger)", "Claw Swipe (Tiger)"},
            {"Crunch (Tiger)", "Crunch (Tiger)"},

        };

        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        Debug.Log("Number of cards found: " + cards.Length);
        
        foreach (GameObject card in cards)
        {
            Card currentCard = card.GetComponent<Card>();
            if(currentCard.name != null && cardSpriteMap.ContainsKey(currentCard.name))
            {
                //Debug.Log("You are in");
                Image cardImage = currentCard.GetComponent<Image>();
                Sprite newSprite = GameObject.Find(cardSpriteMap[currentCard.name]).GetComponent<Image>().sprite;
                cardImage.sprite = newSprite;
            }
        }
    }
}
