using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldPlayerHealth : MonoBehaviour
{
    public Text playerHealthText;
    
    void Update()
    {
        playerHealthText.text = GameController.PlayerStartHealth.ToString();
    }
}
