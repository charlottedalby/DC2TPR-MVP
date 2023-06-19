using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Class: Enemy
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. enemyCards: List of enemy Cards
    b. enemyCardDisplay: Position of enemy Cards in Scene 
    c. health: Enemy Health
    d. armour: Enemy armor
    e. healthText: Enemy HealthText
    f. gameManager: GameManager Instance
    g. armorText: Enemy armor text
    h. difficulty: Enemy difficulty 
    i. name: Enemy name
    j. stage: Enemy Stage 

    Methods: 

    a. Enemy
    b. Start()
    c. attackPlayer()
    d. Update()
    e. getEnemyStartingCards()

*/

public class Enemy : MonoBehaviour
{
    public List<Card> enemyCards = new List<Card>();
    public Transform enemyCardDisplay;
    public int health;
    public int armour;
    public Text healthText;
    private GameManager gameManager;
    public Text armorText;
    public int difficulty;
    public string name;
    public int stage;

    /*
	    Method: Enemy()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Assign Enemy Attributes 
    */
    public Enemy(string name, List<Card> enemyCards, int health, int armour, int difficulty, int stage)
    {
        this.name = name;
        this.enemyCards = enemyCards;
        this.health = health;
        this.armour = armour;
        this.difficulty = difficulty;
        this.stage = stage;
    }

    /*
	    Method: Start()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Find GameManager in Scene 
        b. Run getEnemyStartingCards() 
    */

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        getEnemyStartingCards();
    }
    
    /*
	    Method: attackPlayer()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Randomly select a card from enemyCards 
        b. If Player Armor is greater than 0
        c. If Card Damage is greater than player armor 
        d. Then Card Damage is reduced by Player Armor amount 
        e. Player Armor equals 0 
        f. Player Health is reduced by new Card Damage 
        g. Else then Player Armor is reduced by Card Damage 
        h. Else then player health is reduced by Card Damage 
        i. Health is increased by Card healing 
        j. Armor is increased by Card Armor 
        k. Enemy Card is Displayed for 2 seconds
        l. Enemy Card is removed from Scene 

    */

    public void attackPlayer(){
        
        Card selectedCard = enemyCards[Random.Range(0, enemyCards.Count)];

        if (gameManager.player.playerArmor > 0)
        {

            if (selectedCard.damage > gameManager.player.playerArmor)
            {
                selectedCard.damage -= gameManager.player.playerArmor;
                gameManager.player.playerArmor = 0;
                gameManager.player.playerHealth -= selectedCard.damage;
            }

            else
            {
                gameManager.player.playerArmor -= selectedCard.damage;
            }
        }

        else
        {
            gameManager.player.playerHealth -= selectedCard.damage;
        }

        health += selectedCard.healing;
        armour += selectedCard.armour;
        
        Vector3 initialPosition = selectedCard.transform.position;
        selectedCard.transform.position = enemyCardDisplay.position;
        selectedCard.gameObject.SetActive(true);
        StartCoroutine(MoveAfterWait(selectedCard, initialPosition));
    }

    /*
	    Method: Update()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. If Enemy Health is less than or equal to 0 
        b. Then Health and Armor Text = "0" 
        c. GameOver Sequence Begins 
        d. Else Health and Armor Text equals current Enemy Health and Armor 

    */

    public void Update()
    {
        if(health <= 0)
        {
            healthText.text = "0";
            armorText.text = "0";
            gameManager.Invoke("GameOver", 1);
        }

        else
        {
            healthText.text = health.ToString();
            armorText.text = armour.ToString();
        }      
    }

    /*
        Method: MoveAfterWait()
        Visibility: Public 
        Output: IEnumerator
        Purpose: 

        a. Creates a Wait of 2 Seconds
        b. Moves Card back to Initial Position 

    */

    public IEnumerator MoveAfterWait(Card card, Vector3 position)
    {
        yield return new WaitForSeconds(2f);
        card.transform.position = position;
    }

    /*
        Method: getEnemyStartingCards()
        Visibility: Public 
        Output: IEnumerator
        Purpose: 

        a. Iterates through GameController enemyStartingDeck
        b. Creates a variable currentCard and assigns GameController enemyStartingDeck [i] to it 
        c. enemyCards[i] attributes are set to GameController enemyStartingDeck [i] attributes 

    */

    public void getEnemyStartingCards() {
        
        for(int i = 0; i < GameController.enemyStartingDeck.Count; i++) 
        {
            Card currentCard = GameController.enemyStartingDeck[i];
            enemyCards[i].name = currentCard.name;
            enemyCards[i].damage = currentCard.damage;
            enemyCards[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            enemyCards[i].handIndex = currentCard.handIndex;
            enemyCards[i].armour = currentCard.armour;
            enemyCards[i].healing = currentCard.healing;
            enemyCards[i].damageMult = currentCard.damageMult;
        }
    }
}
