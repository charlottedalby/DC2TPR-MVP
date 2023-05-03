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

    public void Start(){
        enemy = FindObjectOfType<Enemy>();
        player = FindObjectOfType<Player>();
        player.playerHealth = GameController.PlayerStartHealth;
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
            //Call GameOver method
            Invoke("GameOver", 2f);
        }
        //Else if player is not dead, update their health text
        else if(player.playerHealth > 0){
            playerHealthText.text = player.playerHealth.ToString();
        }
    }

    public void GameOver(){
        Cursor.lockState = CursorLockMode.None;
        player.discardDeck();
        //Fix for the discard pile duplication bug
        player.deck.Clear();

        //Goes to You Win screen if enemy health reaches 0
        if(enemy.health <= 0){
            GameController.PlayerStartHealth = player.playerHealth;
            player.storeStartingDeck();
            GameController.checkDeckRequired = true;
            SceneManager.LoadScene("YouWin");
        }
        //Goes to Game Over screen if player health reaches 0
        else if(player.playerHealth <= 0){
            SceneManager.LoadScene("GameOver");
        }

        else if (GameController.checkDeckRequired != true){
            GameController.StartingDeck.Clear();
        }
    }

    
}
