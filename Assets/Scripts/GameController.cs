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
    // Start is called before the first frame update
    void Start()
    {
        PlayerStartHealth = 100;
        PlayerStartArmor = 0;
        StartingDeck = new List<Card>();
        gameMapState = null;
        PlayerStartNode = null;
        assignStartingCards();
    }

    // new addition, changed
    void assignStartingCards()
    {
        //Punch Card 
        playerStartingDeck.Add(new Card(5, null, false, 0, 0, 0, 1));
        //Punch Card 
        playerStartingDeck.Add(new Card(5, null, false, 0, 0, 0, 1));
        //Kick Card 
        playerStartingDeck.Add(new Card(7, null, false, 0, 0, 0, 1));
        //Kick Card 
        playerStartingDeck.Add(new Card(7, null, false, 0, 0, 0, 1));
        //Jump Kick Card 
        playerStartingDeck.Add(new Card(8, null, false, 0, 0, 0, 1));
        //Jump Kick Card 
        playerStartingDeck.Add(new Card(8, null, false, 0, 0, 0, 1));
        //Throw Card 
        playerStartingDeck.Add(new Card(5, null, false, 0, 3, 0, 1));
        //Throw Card 
        playerStartingDeck.Add(new Card(5, null, false, 0, 3, 0, 1));
        //Grapple Card 
        playerStartingDeck.Add(new Card(4, null, false, 0, 4, 0, 1));
        //Grapple Card 
        playerStartingDeck.Add(new Card(4, null, false, 0, 4, 0, 1));
        //Meditate Card 
        playerStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 2));
        //Meditate Card 
        playerStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 2));  
    }
}
