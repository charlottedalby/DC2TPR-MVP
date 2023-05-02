using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;



public class GameController : MonoBehaviour
{
    public static int PlayerStartHealth;
    public static bool checkDeckRequired;
    public static List<Card> StartingDeck;
    public static string gameMapState;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStartHealth = 100;
        checkDeckRequired = false;
        StartingDeck = new List<Card>();
        gameMapState = null;   
    }

    
}
