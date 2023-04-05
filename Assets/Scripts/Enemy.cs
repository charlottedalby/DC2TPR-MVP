using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public List<Card> enemyCards = new List<Card>();
    public Transform enemyCardDisplay;
    public int health;
    public Text healthText;
    private GameManager gameManager;


    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        //Set up enemy cards
        foreach(Card enemyCard in enemyCards){
            enemyCard.gameObject.SetActive(true);
        }
    }

    public void attackPlayer(){
        //Randomly select a card from enemyCards
        Card selectedCard = enemyCards[Random.Range(0, enemyCards.Count)];
        //Reduce player health by the card's damage value
        gameManager.player.playerHealth -= selectedCard.damage;
        //Display the enemy's card on the screen for 2 seconds
        Vector3 initialPosition = selectedCard.transform.position;
        selectedCard.transform.position = enemyCardDisplay.position;
        //Move the card back off the screen
        StartCoroutine(MoveAfterWait(selectedCard, initialPosition));
        Debug.Log("Enemy Card Damage " + selectedCard.damage);
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0){
            healthText.text = "0";
            //gameManager.GameOver();

            //Delaying by a second so we can still see the enemy being defeated
            gameManager.Invoke("GameOver", 1);

            //Note to self - to use if we have a better solution to the menu buttons
            //gameManager.Restart();
        }
        else{
            //If enemy is not defeated, update text to display current health
            healthText.text = health.ToString();
        }

        
    }

      public IEnumerator MoveAfterWait(Card card, Vector3 position){
        //Create a wait of 2 seconds
        yield return new WaitForSeconds(2f);
        Debug.Log("Reached wait");
        //Move the card back to its initial position (off the screen)
        card.transform.position = position;
    }
}
