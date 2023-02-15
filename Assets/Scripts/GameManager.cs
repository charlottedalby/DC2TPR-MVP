using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerHealth;
    public Text playerHealthText;
    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public List<Card> enemyCards = new List<Card>();
    public Transform[] cardSlots;
    public Transform enemyCardDisplay;
    public bool[] availableCardSlots;
    public Text deckSizeText;
    public Text discardSizeText;

    public Enemy enemy;

    //Testing Purposes Only 
    public void Initialize()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    //End of Testing Purpose


    void Start(){
        enemy = FindObjectOfType<Enemy>();
        
        foreach(Card enemyCard in enemyCards){
            enemyCard.gameObject.SetActive(true);
        }

    }
    
    public void DrawCard(){
        if(deck.Count >= 1){
            Card randCard = deck[Random.Range(0, deck.Count)];

            for(int i = 0; i < availableCardSlots.Length; i++){
                if(availableCardSlots[i] == true){
                    randCard.hasBeenPlayed = false;
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex = i;
                    randCard.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }

    public void Shuffle(){
        if(discardPile.Count >= 1){
            foreach(Card card in discardPile){
                deck.Add(card);
            }
            discardPile.Clear();
        }
    }
    void Update()
    {
        deckSizeText.text = deck.Count.ToString();
        discardSizeText.text = discardPile.Count.ToString();
        playerHealthText.text = playerHealth.ToString();
    }

    public void attackEnemy(int damage){
        enemy.health -= damage;
    }

    public void attackPlayer(){
        Card selectedCard = enemyCards[Random.Range(0, enemyCards.Count)];
        playerHealth -= selectedCard.damage;
        Vector3 initialPosition = selectedCard.transform.position;
        selectedCard.transform.position = enemyCardDisplay.position;
        StartCoroutine(MoveAfterWait(selectedCard, initialPosition));
        Debug.Log("Enemy Card Damage " + selectedCard.damage);
    }

    public IEnumerator MoveAfterWait(Card card, Vector3 position){
        
        yield return new WaitForSeconds(2f);
        Debug.Log("Reached wait");
        card.transform.position = position;
    }

    public void GameOver(){
        for(int i = 0; i < deck.Count; i++){
            deck[i].MoveToDiscardPile();
            deck[i].gameObject.SetActive(false);
        }

        //Fix for the discard pile duplication bug
        deck.Clear();

        //Goes to the Winning Screen
        SceneManager.LoadScene("YouWin");

        /*
        for(int i = 0; i < availableCardSlots.GetLength; i++){
            availableCardSlots[i].
        }
        */
    }

    /*
    public void Restart(){
        SceneManager.LoadScene("BattleScreen");
    }
    */
}
