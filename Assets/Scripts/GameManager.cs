using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    Class: GameManager
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. enemy: Enemy Instance 
    b. player: Player Instance
    c. deckSizeText: Deck Size
    d. discardSizeText: Discard Pile Size
    e. playerHealthText: Player Health
    f. playerArmorText: Player Armor
    g. enemyText: Enemy Name
    h. healthBar: Player Health Bar
    i. armorBar: Player Armor Bar
    j. enemies: List of Enemies 
    k. currentEnemy: Enemy Chosen to Battle

    Methods: 

    a. Start()
    b. Update()
    c. GameOver()
    d. displayEnemy()

*/

public class GameManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public Text deckSizeText;
    public Text discardSizeText;
    public Text playerHealthText;
    public Text playerArmorText;
    public Text enemyText;
    public HealthBar healthBar;
    public ArmorBar armorBar;
    public Enemies enemies;
    public Enemy currentEnemy;
    public Card card;

    /*
	    Method: Start()
        Visibility: Public  
        Output: N/A
        Purpose: 

        a. Finds Instance of Enemy in Scene 
        b. Sets currentEnemy to Random enemy in enemies 
        c. Sets Enemy Attributes 
        d. Iterate through Enemy Cards
        e. Set Enemy Card attributes 
        f. Finds Instance of Player in Scene 
        g. Sets Player Health to GameController playerStartHealth
        h. Sets Player Armor to GameController PlayerStartArmor
        i. Runs Player HealthBar setMaxValue with GameController playerStartHealth
        j. Runs displayEnemy()
        k. Draws Card for Player 

    */

    public void Start(){
        
        enemy = FindObjectOfType<Enemy>();
        currentEnemy = enemies.selectEnemy(GameController.PlayerStartNode.battleStrength, GameController.stage);
        enemy.name = currentEnemy.name;
        enemy.health = currentEnemy.health;
        enemy.difficulty = currentEnemy.difficulty;
        enemy.stage = currentEnemy.stage;

        GameController.enemyStartingDeck = currentEnemy.enemyCards;
        
        for (int i = 0; i < currentEnemy.enemyCards.Count; i++)
        {
            Card currentCard = currentEnemy.enemyCards[i];

            enemy.enemyCards[i].name = currentCard.name;
            enemy.enemyCards[i].damage = currentCard.damage;
            enemy.enemyCards[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            enemy.enemyCards[i].handIndex = currentCard.handIndex;
            enemy.enemyCards[i].armour = currentCard.armour;
            enemy.enemyCards[i].healing = currentCard.healing;
            enemy.enemyCards[i].damageMult = currentCard.damageMult;
            enemy.enemyCards[i].ignoreArmour = currentCard.ignoreArmour;
            enemy.enemyCards[i].hitChance = currentCard.hitChance;
        }
        
        player = FindObjectOfType<Player>();
        player.playerHealth = GameController.PlayerStartHealth;
        player.playerArmor = GameController.PlayerStartArmor;
        healthBar.setMaxValue(GameController.PlayerStartHealth);

        displayEnemy();
        player.Invoke("DrawCard", 2f);
    }

    /*
	    Method: Update()
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Updates DeckSize Text
        b. Updates Discard Pile Text 
        c. If Player Health is less than or equal to 0
        d. Then Player Health Text  = "0"
        e. Player Armor Text = "0"
        f. Load GameOver Sequence 
        g. Else if Player Health is greater than 0
        h. Player Health Bar runs setHealth to player health
        i. Player Armor Bar runs setArmor to player armor 
        j. Player Health and Armor is set to current player armor and health 

    */

    void Update()
    {
        deckSizeText.text = player.deck.Count.ToString();
        discardSizeText.text = player.discardPile.Count.ToString();

        if(player.playerHealth <= 0)
        {
            playerHealthText.text = "0";
            playerArmorText.text = "0";
            Invoke("GameOver", 2f);
        }
        else if(player.playerHealth > 0)
        {
            healthBar.setHealth(player.playerHealth);
            armorBar.setArmor(player.playerArmor);
            playerHealthText.text = player.playerHealth.ToString();
            playerArmorText.text = player.playerArmor.ToString();
        }
    }

    /*
	    Method: GameOver()
        Visibility: Public  
        Output: N/A
        Purpose: 

        a. Unlock Player Cursor 
        b. Clear Player Deck
        c. If Enemy Health is less than or equal to 0
        d. Then GameController playerStartHealth equals Player Health
        e. If GameController PlayerStartNode forward connections amount equals 0
        f. Then Load Stage Complete Scene 
        g. Else Load You Win Scene
        h. Else if Player Health is less than or equal to 0 
        i. Then Load You Win Scene 

    */

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        player.deck.Clear();

        if(enemy.health <= 0)
        {
            GameController.PlayerStartHealth = player.playerHealth;

            if(GameController.PlayerStartNode.forwardConnections.Count == 0)
            {
                GameController.PlayerStartHealth = 100;
                GameController.gameMapState = null;
                GameController.PlayerStartNode = null;
                GameController.PlayerMapPos.Clear();
                GameController.stage1Difficulty = new List <int>();
                GameController.PlayerStartColumn = 0;
                SceneManager.LoadScene("StageComplete");
            }
            else
            {
                SceneManager.LoadScene("YouWin");
            }
        }
        else if(player.playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    /*
	    Method: displayEnemy()
        Visibility: Public  
        Output: N/A
        Purpose: 

        a. Declare List of Enemy GameObjects 
        b. List contents equals All GameObjects in Scene with Tag Enemy 
        c. Iterate through List 
        d. Declare currentEnemy which is each enemy in list 
        e. If currentEnemy name is not null 
        g. Set Enemy Image based off name. 

    */

    public void displayEnemy()
    {
        GameObject[] Enemiess;
        Enemiess = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in Enemiess)
        {
            Enemy currentEnemy = enemy.GetComponent<Enemy>();
            
            if(currentEnemy.name != null)
            {
                Image enemyImage = currentEnemy.GetComponent<Image>();
                Sprite newSprite = GameObject.Find(currentEnemy.name).GetComponent<Image>().sprite;
                enemyImage.sprite = newSprite;
                enemyText.text = currentEnemy.name;
            }
        }
    }
}
