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
    public bool avoidAttack;
    public int endOfTurnDamage;

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
        k. Enemy Card is faded into Scene
        l. Enemy Card is Displayed for 2 seconds
        m. Enemy Card is removed from Scene 

    */

    public void attackPlayer(){
        
        Card selectedCard = enemyCards[Random.Range(0, enemyCards.Count)];

        //Tutorial code
        if (stage == 0 && difficulty != 3) {
            selectedCard = enemyCards[0];
        }

        if (gameManager.player.playerArmor > 0 && selectedCard.ignoreArmour != true && gameManager.player.avoidAttack != true)
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

        else if(gameManager.player.avoidAttack != true)
        {
            gameManager.player.playerHealth -= selectedCard.damage;
        }
        else{
            gameManager.player.avoidAttack = false;
        }

        health += selectedCard.healing;
        armour += selectedCard.armour;
    
        if(selectedCard.hitChance > 0){
            int x = Random.Range(0, 100);
            
            if(x <= selectedCard.hitChance){
                avoidAttack = true;
            }
        }

        endTurnMechanics(selectedCard.endOfTurnValue);

        Vector3 initialPosition = selectedCard.transform.position;
        selectedCard.transform.position = enemyCardDisplay.position;
        selectedCard.gameObject.SetActive(true);
        
        Image image = selectedCard.GetComponent<Image>();
        image.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(FadeImage(image, 0.5f, 0f, 1f));

        StartCoroutine(MoveAfterWait(selectedCard, initialPosition));
    }

    public void endTurnMechanics(int endTurnOption){
        switch(endTurnOption){
            case 0:
                Debug.Log("Player: " + gameManager.player.playerHealth + " - " + endOfTurnDamage);
                if(endOfTurnDamage > 0){
                    gameManager.player.playerHealth -= endOfTurnDamage;
                }
                Debug.Log("Player: " + gameManager.player.playerHealth + " - " + endOfTurnDamage);
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
                    gameManager.player.playerHealth -= 18;
                }
                break;
            case 5:
                if(gameManager.player.playerHealth <= 20){
                    gameManager.player.playerHealth -= 20;
                }
                break;
            case 6:
                if(armour > 0){
                    gameManager.player.playerHealth -= 18;
                }
                break;
            case 7:
                if(endOfTurnDamage > 0){
                    gameManager.player.playerHealth -= (endOfTurnDamage + 7);
                }
                break;
            case 8:
                if(health > 50 ){
                    health += 18;
                }
                break;
            case 9:
                if(gameManager.player.playerArmor > 0){
                    gameManager.player.playerHealth -= 16;
                }
                break;
            case 10:
                if(gameManager.player.playerHealth > 50 ){
                    gameManager.player.playerHealth -= 20;
                }
                break;
            default:
                if(endOfTurnDamage > 0){
                    gameManager.player.playerHealth -= endOfTurnDamage;
                }
                break;
        }
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
        b. Fades Card Out of Scene 

    */

    public IEnumerator MoveAfterWait(Card card, Vector3 position)
    {
        yield return new WaitForSeconds(2f);
        Image image = card.GetComponent<Image>();
        StartCoroutine(FadeImage(image, 0.5f, 1f, 0f));
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

    public void getEnemyStartingCards() 
    {
        
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
            enemyCards[i].ignoreArmour = currentCard.ignoreArmour;
            enemyCards[i].hitChance = currentCard.hitChance;
            enemyCards[i].endOfTurnValue = currentCard.endOfTurnValue;
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
}
