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
    public int armour;
    // new addition
    public int healing;
    public int damageMult;


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
        
        // recently commented out
        /*
        if(damage <= 0){
            //Just for use, until card destroy is fixed: ***************************************************************
            damage = Random.Range(1,6);  
        }
        */
        
        if (damageText != null) 
        {
            damageText.text = "D" + damage.ToString() + "A" + armour.ToString() + "H" + healing.ToString();
        }
        gameManager = FindObjectOfType<GameManager>();
        
    }

    public Card (int damage, Text damageText, bool hasBeenPlayed, int handIndex, int armour, int healing, int damageMult)
    {
        this.damage = damage;
        this.damageText = damageText;
        this.hasBeenPlayed = hasBeenPlayed;
        this.handIndex = handIndex;
        this.armour = armour;
        //new addition
        this.healing = healing;
        this.damageMult = damageMult;
    }

    void OnMouseDown(){
        //If the Card has been clicked on and hasn't been played yet
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
