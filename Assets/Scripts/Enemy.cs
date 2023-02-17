using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;

    public Text healthText;

    private GameManager gameManager;


    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0){
            healthText.text = "DEFEATED";
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
}
