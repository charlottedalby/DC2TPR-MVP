using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;



public class GameController : MonoBehaviour
{
    public static int PlayerStartHealth;
    public static List<Card> StartingDeck;
    public static string gameMapState;
    public static int PlayerStartColumn;
    public static Node PlayerStartNode;
    public static List <int> PlayerMapPos = new List<int>();
    public static List<Card> playerStartingDeck = new List <Card>();
    public static int PlayerStartArmor;
    public static List<Card> enemyStartingDeck = new List <Card>();
    public static Card SwappedCard;
    public static List<Card> dupStartDeck = new List <Card>();
    public static List<int> stage1Difficulty;
    public static int stage;
    public static int battleDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStartHealth = 100;
        PlayerStartArmor = 0;
        StartingDeck = new List<Card>();
        gameMapState = null;
        PlayerStartNode = null;
        PlayerMapPos.Clear();
        SwappedCard = null;
        stage1Difficulty = new List <int>();
        stage = 1;
        assignStartingCards();
    }

    // new addition, changed
    void assignStartingCards()
    {
        playerStartingDeck.Clear();
        //Punch Card 
        playerStartingDeck.Add(new Card("Punch", 5, false, 0, 0, 0, 1));
        //Punch Card 
        playerStartingDeck.Add(new Card("Punch", 5, false, 0, 0, 0, 1));
        //Kick Card 
        playerStartingDeck.Add(new Card("Kick", 7, false, 0, 0, 0, 1));
        //Kick Card 
        playerStartingDeck.Add(new Card("Kick", 7, false, 0, 0, 0, 1));
        //Jump Kick Card 
        playerStartingDeck.Add(new Card("Jump Kick", 8, false, 0, 0, 0, 1));
        //Jump Kick Card 
        playerStartingDeck.Add(new Card("Jump Kick", 8, false, 0, 0, 0, 1));
        //Throw Card 
        playerStartingDeck.Add(new Card("Throw", 5, false, 0, 3, 0, 1));
        //Throw Card 
        playerStartingDeck.Add(new Card("Throw", 5, false, 0, 3, 0, 1));
        //Grapple Card 
        playerStartingDeck.Add(new Card("Grapple", 4, false, 0, 4, 0, 1));
        //Grapple Card 
        playerStartingDeck.Add(new Card("Grapple", 4, false, 0, 4, 0, 1));
        //Meditate Card 
        playerStartingDeck.Add(new Card("Meditate", 0, false, 0, 0, 0, 2));
        //Meditate Card 
        playerStartingDeck.Add(new Card("Meditate", 0, false, 0, 0, 0, 2));  
    }

    
}
