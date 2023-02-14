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
    
     //Testing Purposes Only 
    public void Initialize()
    {
        damage = Random.Range(1,6);
        damageText.text = damage.ToString();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PlayCard() {
    if (!gameManager)
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    OnMouseDown();
    Debug.Log("Deck: " + gameManager.deck.Count);
    //MoveToDiscardPile();
}
    //End of Testing Purpose

    void Start()
    {
        damage = Random.Range(1,6);
        damageText.text = damage.ToString();
        gameManager = FindObjectOfType<GameManager>();
        
    }

    void OnMouseDown(){
        if(hasBeenPlayed == false){
            gameManager.attackEnemy(damage);
            transform.position += Vector3.up * 5;
            hasBeenPlayed = true;
            gameManager.availableCardSlots[handIndex] = true;
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
        gameManager.discardPile.Add(this);
        gameObject.SetActive(false);
        gameManager.attackPlayer();
        Debug.Log("Discard pile: " +gameManager.discardPile.Count);
    }
}
