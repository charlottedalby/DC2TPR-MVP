using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    
    public Text deckSizeText;
    public Text discardSizeText;
    public Text playerHealthText;
    public Text playerArmorText;
    public HealthBar healthBar;
    public ArmorBar armorBar;
    public Enemies enemies;
    public Enemy currentEnemy;

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
            //new addition
            enemy.enemyCards[i].healing = currentCard.healing;
            enemy.enemyCards[i].damageMult = currentCard.damageMult;
        }

        player = FindObjectOfType<Player>();
        player.playerHealth = GameController.PlayerStartHealth;
        player.playerArmor = GameController.PlayerStartArmor;
        healthBar.setMaxValue(GameController.PlayerStartHealth);
        player.Invoke("DrawCard", 2f);
    }

    void Update()
    {
        //Update all the text elements on the screen
        deckSizeText.text = player.deck.Count.ToString();
        discardSizeText.text = player.discardPile.Count.ToString();
        //Check player health every frame to see if they have lost all health
        if(player.playerHealth <= 0){
            playerHealthText.text = "0";
            playerArmorText.text = "0";
            //Call GameOver method
            Invoke("GameOver", 2f);
        }
        //Else if player is not dead, update their health text
        else if(player.playerHealth > 0){
            healthBar.setHealth(player.playerHealth);
            armorBar.setArmor(player.playerArmor);
            playerHealthText.text = player.playerHealth.ToString();
            playerArmorText.text = player.playerArmor.ToString();
        }
    }

    public void GameOver(){
        Cursor.lockState = CursorLockMode.None;
        //Fix for the discard pile duplication bug
        player.deck.Clear();

        //Goes to You Win screen if enemy health reaches 0
        if(enemy.health <= 0){
            GameController.PlayerStartHealth = player.playerHealth;
            SceneManager.LoadScene("YouWin");
        }
        //Goes to Game Over screen if player health reaches 0
        else if(player.playerHealth <= 0){
            SceneManager.LoadScene("GameOver");
        }
    }

    
}
