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
    MoveToDiscardPile();
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
        Debug.Log(this.gameManager);
        if (gameManager == null) {
            gameManager = FindObjectOfType<GameManager>();
        }
        gameManager.discardPile.Add(this);
        gameObject.SetActive(false);
    }
}
