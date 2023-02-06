using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    public Text deckSizeText;
    public Text discardSizeText;

    public Enemy enemy;

    void Start(){
        enemy = FindObjectOfType<Enemy>();
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
    }

    public void attackEnemy(int damage){
        enemy.health -= damage;
    }

    public void GameOver(){
        for(int i = 0; i < deck.Count; i++){
            deck[i].MoveToDiscardPile();
            deck[i].gameObject.SetActive(false);
        }
        /*
        for(int i = 0; i < availableCardSlots.GetLength; i++){
            availableCardSlots[i].
        }
        */
    }
}
