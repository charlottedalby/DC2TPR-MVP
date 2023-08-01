using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;

/*
    Class: GameController
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. PlayerStartHealth: Players Starting Health
    b. gameMapState: Overworld Map
    c. PlayerStartNode: Players previous or start node
    d. PlayerMapPos: Contains list of battles they have chosen on Overworld Map
    e. playerStartingDeck: Players Starting Deck
    f. PlayerStartArmor: Players Starting Armor 
    g. enemyStartingDeck: Enemy Starting Deck
    h. SwappedCard: Enemy Card that will be Swapped for Player Card
    i. stage1Difficulty: List of Stage 1 Difficulties on Overworld Map
    j. stage: Players current stage
    k. battleDifficulty: The difficulty of battle a player is undertaking 

    Methods: 

    a. Start()
    b. assignStartingCards()

*/

public class GameController : MonoBehaviour
{
    public static int PlayerStartHealth;
    public static string gameMapState;
    public static int PlayerStartColumn;
    public static Node PlayerStartNode;
    public static List <int> PlayerMapPos = new List<int>();
    public static List<Card> playerStartingDeck = new List <Card>();
    public static int PlayerStartArmor;
    public static List<Card> enemyStartingDeck = new List <Card>();
    public static List<int> enemyStartDeck = new List <int>(4);
    public static Card SwappedCard;
    public static List<int> stage1Difficulty;
    public static List<int> tutorial;
    public static int stage;
    public static int battleDifficulty;

    /*
	    Method: Start()
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Sets PlayerStartingHealth to 100
        b. Sets PlayerStartingArmor to 0
        c. Sets gameMapState to null
        d. Sets PlayerStartNode to null
        e. Removes all from PlayerMapPos
        f. Sets SwappedCard to null
        g. Initilizes stage1Difficulty 
        h. Sets stage to 1
        i. Runs assignStartingCards()
    */

    public void Start()
    {
        PlayerStartHealth = 100;
        PlayerStartArmor = 0;
        gameMapState = null;
        PlayerStartNode = null;
        PlayerMapPos.Clear();
        SwappedCard = null;
        stage1Difficulty = new List <int>();
        tutorial = new List <int>();
        stage = 2;
        assignStartingCards();
    }

    /*
	    Method: assignStartingCards()
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Clears all from playerStartingDeck
        b. Adds 12 new cards to playerStartingDeck
            i. Punch 
            ii. Punch
            iii. Kick
            iv. Kick
            v. Jump Kick
            vi. Jump Kick
            vii. Throw
            viii. throw
            ix. Grapple
            x. Grapple 
            xi. Meditate
            xii. Meditate

    */

    public void assignStartingCards()
    {
        playerStartingDeck.Clear();

        playerStartingDeck.Add(new Card("Punch", 5, false, 0, 0, 0, 1, false, 0, 0));
        playerStartingDeck.Add(new Card("Punch", 5, false, 0, 0, 0, 1, false, 0, 0));

        playerStartingDeck.Add(new Card("Kick", 7, false, 0, 0, 0, 1, false, 0, 0));
        playerStartingDeck.Add(new Card("Kick", 7, false, 0, 0, 0, 1, false, 0, 0));

        playerStartingDeck.Add(new Card("Jump Kick", 8, false, 0, 0, 0, 1, false, 0, 0));
        playerStartingDeck.Add(new Card("Jump Kick", 8, false, 0, 0, 0, 1, false, 0, 0));

        playerStartingDeck.Add(new Card("Throw", 5, false, 0, 3, 0, 1, false, 0, 0));
        playerStartingDeck.Add(new Card("Throw", 5, false, 0, 3, 0, 1, false, 0, 0));

        playerStartingDeck.Add(new Card("Grapple", 4, false, 0, 4, 0, 1, false, 0, 0));
        playerStartingDeck.Add(new Card("Grapple", 4, false, 0, 4, 0, 1, false, 0, 0));

        playerStartingDeck.Add(new Card("Meditate", 0, false, 0, 0, 0, 2, false, 0, 0)); 
        playerStartingDeck.Add(new Card("Meditate", 0, false, 0, 0, 0, 2, false, 0, 0));  
    }

    
}
