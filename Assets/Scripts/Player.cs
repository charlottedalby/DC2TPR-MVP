using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Class: ArmorBar
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. Instance: Instance of Player
    b. playerHealth: Players Health
    c. playerArmor: Players Armor
    d. playerDamageMult: Players Damage Multiplier 
    e. deck: Players Deck
    f. discardPile: Players Discard Pile
    g. hand: Players hand 
    h. avalibleCardSlots: Card Slots avalible on Screen
    i. cardSlots: List of Card Slots
    j. gameManager: Instance of GameManager 
    k. avoidAttack: allows the player to avoid enemy attack 
    l. playerCardDisplay: where the card will go when a player selects a card

    Methods: 

    a. Awake()
    b. Start()
    c. DrawCard()
    d. discardHand()
    e. enableHand()
    f. Shuffle()
    g. attackEnemy()
    h. raiseArmor()
    i. healPlayer()
    j. powerUp()
    k. getStartingCards()
*/

public class Player : MonoBehaviour
{
    
    public int playerHealth;
    public int playerArmor;
    public int playerDamageMult;

    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public List<Card> hand = new List<Card>();    
    public bool[] availableCardSlots;
    public Transform[] cardSlots;
    public GameManager gameManager;
    public bool avoidAttack;
    public int endOfTurnDamage;
    public Transform playerCardDisplay;

    /*
        Method: Awake()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Check if an instance of the script already exists:
        b. If it exists, destroy the current game object and return.
        c. Set the Instance variable to reference the current script.
        d. Prevent the game object from being destroyed when loading new scenes.
        e. If Instance is still null:
        f. Set the Instance variable to reference the current script.
        g. If Instance is not null and it is not the current script:
        h. Set the Instance variable to reference the current script.
    */
    /*
    public void Awake()
    { 
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        

        if (Instance == null) 
        {
            Instance = this;
        } 

        else if (Instance != this) 
        {
            Instance = this;
        }
    }*/

    /*
        Method: Start()
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Set the GameManager component in Instance to the GameManager object found in the scene.
        b. Call the getStartingCards() method.
    */

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        getStartingCards();
        
    }

    /*
        Method: DrawCard()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Unlock the cursor.
        b. Iterate over the availableCardSlots array:
        c. If the deck has at least one card:
        d. Then Select a random card from the deck.
        e. Iterate over the availableCardSlots array:
        f. If the current slot is available:
        g. Then Reset the played state of the random card.
        h. Activate the random card's GameObject.
        i. Set the random card's handIndex to the current slot index.
        j. Get the Image of the Card and set the Alpha to 0 (Invisible)
        k. Move the random card to the position of the corresponding card slot.
        l. Mark the current slot as unavailable.
        m. Add the random card to the hand.
        n. Remove the random card from the deck.
        o. Start Routine to Fade in Card
        p. Break the loop.
    */

    public void DrawCard()
    {
        Cursor.lockState = CursorLockMode.None;

        for(int j = 0; j < availableCardSlots.Length; j++)
        {
            if(deck.Count >= 1)
            {
                Card randCard = deck[Random.Range(0, deck.Count)];
                if (GameController.stage == 0 && gameManager.enemy.difficulty == 1) {
                    randCard = deck[0];
                }
                if (GameController.stage == 0 && gameManager.enemy.difficulty == 2) {
                    if (deck.Count > 3) {
                        randCard = deck[3];
                    }
                    if (deck.Count > 6) {
                        randCard = deck[6];
                    }
                }

                for(int i = 0; i < availableCardSlots.Length; i++)
                {
                    if(availableCardSlots[i] == true)
                    {
                        randCard.hasBeenPlayed = false;
                        randCard.gameObject.SetActive(true);
                        randCard.handIndex = i;
                        
                        Image image = randCard.GetComponent<Image>();
                        image.color = new Color(1f, 1f, 1f, 0f);
                        randCard.gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
                        randCard.transform.position = cardSlots[i].position;
                        availableCardSlots[i] = false;
                        hand.Add(randCard);
                        deck.Remove(randCard);

                        StartCoroutine(FadeImage(image, 0.5f, 0f, 1f));
                        break;
                    }
                }
            }
        }
    }

    /*
        Method: discardHand()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Iterate over the availableCardSlots array:
        b. Get the current card from the hand.
        c. Add the current card to the discardPile.
        d. Move and shrink card to discard pile
        e. Mark the current slot as available.
        f. Clear the hand list.
        g. If the deck is empty:
        h. Then Call the Shuffle() method.
        i. Delay the execution of the DrawCard() method by 2 seconds using Invoke().
    */

    public void discardHand()
    {
        for(int i = 0; i < availableCardSlots.Length; i++)
        {
            Card currentCard = hand[i];
            discardPile.Add(currentCard);
            availableCardSlots[i] = true;
            Vector3 originalScale = currentCard.gameObject.transform.localScale;
            StartCoroutine(MoveAndShrinkCard(currentCard));
            currentCard.gameObject.SetActive(true);
            currentCard.gameObject.transform.localScale = originalScale;
        }

        hand.Clear();

        if(deck.Count <= 0)
        {
            Shuffle();
        }

        Invoke("DrawCard", 2f);
    }

    /*
        Method: enableHand()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. If enable is false:
        b. Then Deactivate all cards in the hand.
        c. If enable is true:
        d. Then Activate all cards in the hand.
    */

    public void enableHand(bool enable)
    {
        if(enable == false)
        {
            foreach (Card x in hand)
            {
                x.gameObject.SetActive(false);
            }
        }

        else if(enable == true)
        {
            foreach (Card y in hand)
            {
                y.gameObject.SetActive(true);
            }
        }
        
    }
    
    /*
        Method: Shuffle()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. If the discardPile has at least one card:
        b. Then Move all cards from the discardPile to the deck.
        c. Clear the discardPile.
    */

    public void Shuffle()
    {

        if(discardPile.Count >= 1)
        {
            foreach(Card card in discardPile)
            {
                deck.Add(card);
            }

            discardPile.Clear();
        }
    }

    /*
        Method: attackEnemy()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Adjust the damage value based on the player's damage multiplier.
        b. If the enemy has armor:
        c. If the damage is greater than the enemy's armor:
        d. Then Subtract the armor from the damage and reduce the enemy's health by the remaining damage.
        e. Otherwise, subtract the damage from the enemy's armor.
        f. If the enemy has no armor, reduce the enemy's health by the damage.
        g. Then Reset the player's damage multiplier to 1.
    */

    public void attackEnemy(int damage, bool ignoreArmour, int hitChance)
    {
        damage = damage * gameManager.player.playerDamageMult;

        if (gameManager.enemy.armour > 0 && ignoreArmour != true && gameManager.enemy.avoidAttack != true)
        {
            if (damage > gameManager.enemy.armour)
            {
                damage -= gameManager.enemy.armour;
                gameManager.enemy.armour = 0;
                gameManager.enemy.health -= damage;
            }

            else
            {
                gameManager.enemy.armour -= damage;
            }
        }
        
        else if(gameManager.enemy.avoidAttack != true)
        {
            gameManager.enemy.health -= damage;
        }
        else{
            gameManager.enemy.avoidAttack = false;
        }

        gameManager.player.playerDamageMult = 1;

        if(hitChance > 0){
            int x = Random.Range(0, 100);
            
            if(x <= hitChance){
                avoidAttack = true;
            }
        }
    }

    public void endTurnMechanics(int endTurnOption){
        switch(endTurnOption){
            case 0:
                Debug.Log("Enemy: " + gameManager.enemy.health + " - " + endOfTurnDamage);
                if(endOfTurnDamage > 0){
                    attackEnemy(endOfTurnDamage, false, 0);
                }
                Debug.Log("Enemy: " + gameManager.enemy.health + " - " + endOfTurnDamage);
                break;
            case 1:
                endOfTurnDamage = 1;
                break;
            case 2:
                endOfTurnDamage = 2;
                break;
            case 3:
                endOfTurnDamage = 4;
                break;
            case 4:
                if(endOfTurnDamage > 0){
                    attackEnemy(18, false, 0);
                }
                break;
            case 5:
                if(gameManager.enemy.health <= 20){
                    attackEnemy(20, false, 0);
                }
                break;
            case 6:
                if(gameManager.player.playerArmor > 0){
                    attackEnemy(18, false, 0);
                }
                break;
            case 7:
                if(endOfTurnDamage > 0){
                    attackEnemy(endOfTurnDamage + 7, false, 0);
                }
                break;
            case 8:
                if(gameManager.player.playerHealth > 50 ){
                    healPlayer(18);
                }
                break;
            case 9:
                if(gameManager.enemy.armour > 0){
                    attackEnemy(16, false, 0);
                }
                break;
            case 10:
                if(gameManager.enemy.health > 50 ){
                    attackEnemy(20, false, 0);
                }
                break;
            case 11:
                endOfTurnDamage = 3;
            case 12:
                attackEnemy(gameManager.enemy.armour, false, 0);
            case 13:
                gameManager.enemy.armour = 0;
                attackEnemy(6, false, 0);
            case 14:
                if(endOfTurnDamage > 0){
                    attackEnemy(endOfTurnDamage * 2);
                }
            default:
                if(endOfTurnDamage > 0){
                    attackEnemy(endOfTurnDamage, false, 0);
                }
                break;
        }
    }


    /*
        Method: raiseArmor()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Increase the player's armor by the specified protection value.
        b. Update the armor value displayed in the armorBar.
    */

    public void raiseArmor(int protection) 
    {
        gameManager.player.playerArmor += protection;
        gameManager.armorBar.setArmor(gameManager.player.playerArmor);
    }

    /*
        Method: healPlayer()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Increase the player's health by the specified healing value.
        b. If the player's health exceeds 100, set it to 100.
    */


    public void healPlayer(int healing) 
    {
        gameManager.player.playerHealth += healing;
        
        if (gameManager.player.playerHealth > 100) 
        {
            gameManager.player.playerHealth = 100;
        }
    }

    /*
        Method: powerUp()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Set the player's damage multiplier to the specified damageMult value.
    */

    public void powerUp(int damageMult) 
    {
        gameManager.player.playerDamageMult = damageMult;
    }

    /*
    Method: getStartingCards()
    Visibility: Public 
    Output: N/A
    Purpose: 

    a. Iterate over the playerStartingDeck list:
    b. Get the current card from the GameController's playerStartingDeck.
    c. Assign the properties of the current card to the corresponding properties of the cards in Instance's deck.
*/

    public void getStartingCards()
    {
        for(int i = 0; i < GameController.playerStartingDeck.Count; i++) 
        {
            Card currentCard = GameController.playerStartingDeck[i];
            deck[i].name = currentCard.name;
            deck[i].damage = currentCard.damage;
            deck[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            deck[i].handIndex = currentCard.handIndex;
            deck[i].armour = currentCard.armour;
            //new addition
            deck[i].healing = currentCard.healing;
            deck[i].damageMult = currentCard.damageMult;
            deck[i].ignoreArmour = currentCard.ignoreArmour;
            deck[i].hitChance = currentCard.hitChance;
            deck[i].endOfTurnValue = currentCard.endOfTurnValue;
        }
    }

    /*
        Method: FadeImage()
        Visibility: private 
        Output: null
        Purpose: 

        a. Gets starting Image Color
        b. Gets target Image Color
        c. Creates a time variable
        d. While the time is less than duration 
        e. time variable add real time value 
        f. create a new time variable which contains amount of time passed 
        g. image color now set to a value between start color and end color 
        h. Keep on looping until time = duration
        i. set color to target color 
    */

    private IEnumerator FadeImage(Image image, float duration, float startAlpha, float targetAlpha)
    {
        Color startColor = image.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime/duration);
            image.color = Color.Lerp(startColor,targetColor,t);
            yield return null;
        }
        image.color = targetColor;
    }

    /*
        Method: MoveAndShrinkCard()
        Visibility: private 
        Output: null
        Purpose: 

        a. Duration of Shrink
        b. Gets target position that cards want to end up at 
        c. gets original current scale of cards
        d. gets card target scale i.e 0
        e. gets elapsed time 
        f. While elpased time is less than duration (2 seconds)
        g. move position between starting and ending position 
        h. Shrink card between start scale and end scale (0)
        i. add time taken to elapsed time 
        j. return null to break out of while and start again
        k. set card position to target position 
        l. set card scale to target scale 
    */

    private IEnumerator MoveAndShrinkCard(Card card)
    {
        float duration = 2f;
        Vector3 targetPosition = new Vector3 (-8f, -4.2f, 0.0f);
        Vector3 originalScale = card.gameObject.transform.localScale;
        Vector3 targetScale = Vector3.zero;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            card.gameObject.transform.position = Vector3.Lerp(card.gameObject.transform.position, targetPosition, elapsedTime/duration);
            card.gameObject.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
