using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;

    public Text healthText;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            healthText.text = "DEFEATED";
            gameManager.GameOver();
        }
        else{
            healthText.text = health.ToString();
        }

        
    }
}
