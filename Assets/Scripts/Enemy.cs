using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public List<Card> enemyCards = new List<Card>();
    public Transform enemyCardDisplay;
    public int health;
    public int armour;
    public Text healthText;
    private GameManager gameManager;
    public Text armorText;

    //Enemy Constructor 
    public Enemy(List<Card> enemyCards, int health, int armour)
    {
        this.enemyCards = enemyCards;
        this.health = health;
        this.armour = armour;
    }

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        getEnemyStartingCards();
        Debug.Log(enemyCards[0].damage);
    }

    public void attackPlayer(){
        //Randomly select a card from enemyCards
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
            //Reduce player health by the card's damage value
            gameManager.player.playerHealth -= selectedCard.damage;
        }

        health += selectedCard.healing;
        armour += selectedCard.armour;
        

        //Display the enemy's card on the screen for 2 seconds
        Vector3 initialPosition = selectedCard.transform.position;
        selectedCard.transform.position = enemyCardDisplay.position;
        selectedCard.gameObject.SetActive(true);
        //Move the card back off the screen
        StartCoroutine(MoveAfterWait(selectedCard, initialPosition));
        //selectedCard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0){
            healthText.text = "0";
            armorText.text = "0";
            //gameManager.GameOver();

            //Delaying by a second so we can still see the enemy being defeated
            gameManager.Invoke("GameOver", 1);

            //Note to self - to use if we have a better solution to the menu buttons
            //gameManager.Restart();
        }
        else{
            //If enemy is not defeated, update text to display current health
            healthText.text = health.ToString();
            armorText.text = armour.ToString();
        }      
    }

      public IEnumerator MoveAfterWait(Card card, Vector3 position){
        //Create a wait of 2 seconds
        yield return new WaitForSeconds(2f);
        //Move the card back to its initial position (off the screen)
        card.transform.position = position;
    }

    public void getEnemyStartingCards() {
        //GameController.assignStartingEnemyCards(enemyId);
        for(int i = 0; i < GameController.enemyStartingDeck.Count; i++) 
        {
            Card currentCard = GameController.enemyStartingDeck[i];
            enemyCards[i].damage = currentCard.damage;
            //Instance.deck[i].damageText = currentCard.damageText;
            enemyCards[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            enemyCards[i].handIndex = currentCard.handIndex;
            enemyCards[i].armour = currentCard.armour;
            //new addition
            enemyCards[i].healing = currentCard.healing;
            enemyCards[i].damageMult = currentCard.damageMult;
            if (enemyCards[i].damageText != null) 
            {
                enemyCards[i].damageText.text = "D" + currentCard.damage.ToString() + " A" + currentCard.armour.ToString() + " H" + currentCard.healing.ToString();
            }
        }

        //Set up enemy cards
        /*
        foreach(Card enemyCard in enemyCards){
            enemyCard.gameObject.SetActive(true);
        }
        */
    }
}
