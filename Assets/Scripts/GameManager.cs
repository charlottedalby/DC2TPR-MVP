using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;

    public void Start(){
        enemy = FindObjectOfType<Enemy>();
        player = FindObjectOfType<Player>();

        player.Invoke("DrawCard", 2f);
    }


    public void GameOver(){
        Cursor.lockState = CursorLockMode.None;
        //Move all cards in the deck to the discardPile and make the gameObjects to be inactive
        for(int i = 0; i < player.deck.Count; i++){
            player.deck[i].MoveToDiscardPile();
            player.deck[i].gameObject.SetActive(false);
        }

        //Fix for the discard pile duplication bug
        player.deck.Clear();

        //Goes to You Win screen if enemy health reaches 0
        if(enemy.health <= 0){
            SceneManager.LoadScene("YouWin");
        }
        //Goes to Game Over screen if player health reaches 0
        else if(player.playerHealth <= 0){
            SceneManager.LoadScene("GameOver");
        }
    }
}
