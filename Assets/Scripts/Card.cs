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

    public void Start()
    {
        //Randomly assign damage value to Card when initialised
        damage = Random.Range(1,6);
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
            //Set hasBeenPlayed to true
            hasBeenPlayed = true;
            //Make the slot the card was in available again
            gameManager.player.availableCardSlots[handIndex] = true;
            //Move the card to the discardPile
            Invoke("MoveToDiscardPile", 2f);
        }
    }

    public void MoveToDiscardPile(){
        //Fix for the nullReference errors
        Debug.Log(gameManager);
        if (gameManager == null) {
            this.gameManager = FindObjectOfType<GameManager>();
        }
        Debug.Log(this);
        //Add the Card to the discardPile and set the card to inactive
        gameManager.player.discardPile.Add(this);
        gameObject.SetActive(false);
        //Invoke the enemy to attack the player
        gameManager.enemy.Invoke("attackPlayer", 2f);
        Debug.Log("Discard pile: " +gameManager.player.discardPile.Count);
    }

}
