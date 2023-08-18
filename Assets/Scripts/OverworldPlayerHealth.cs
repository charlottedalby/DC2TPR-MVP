using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    Class: Overworld Player Health 
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. N/A

    Purpose: 

    a. Controller for Overworld Player Health Display 
*/
public class OverworldPlayerHealth : MonoBehaviour
{
    public Text playerHealthText;
    
    public void Update()
    {
        playerHealthText.text = GameController.PlayerStartHealth.ToString();
    }
}
