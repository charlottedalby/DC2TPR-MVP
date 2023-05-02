using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int damage;
    public Text damageText;
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gameManager;
    public Player player;
    public static Card Instance;
    public GameObject PLAYER;


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
        //Randomly assign damage value to Card when initialised
        if(damage <= 0){
            if(GameController.checkDeckRequired != true){
                damage = Random.Range(1,6);
            }
            else if(GameController.checkDeckRequired == true){
                int count = 0;
                foreach (Card cards in GameController.StartingDeck){
                    if(count < 12){
                        //player.deck[count] = cards;
                        count++;
                    }
                }
            }
            //Just for use, until card destroy is fixed
            damage = Random.Range(1,6);  
        }
        if (damageText != null) 
        {
            damageText.text = damage.ToString();
        }
        gameManager = FindObjectOfType<GameManager>();
        
    }

    void OnMouseDown(){
        //If the Card has been clicked on and hasn't been played yet
        if(hasBeenPlayed == false){
            //Attack the enemy
            gameManager.player.attackEnemy(damage);
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

    public void MoveToDiscardPile(){
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
}
