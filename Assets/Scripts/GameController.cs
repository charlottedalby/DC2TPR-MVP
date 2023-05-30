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

    // Start is called before the first frame update
    void Start()
    {
        PlayerStartHealth = 100;
        PlayerStartArmor = 0;
        StartingDeck = new List<Card>();
        gameMapState = null;
        PlayerStartNode = null;
        assignStartingCards();
        assignStartingEnemyCards(Random.Range(0, 13));
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

    void assignStartingEnemyCards(int enemyId)
    {
        enemyStartingDeck.Clear();
        switch(enemyId) 
        {
            //Stage 1 Enemies
            case 0:
                // Ant Enemy
                //Curl Up Card (unfinished)
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 1));
                //Team Attack Card (unfinished)
                enemyStartingDeck.Add(new Card(8, null, false, 0, 0, 0, 1));
                //Pincer Card
                enemyStartingDeck.Add(new Card(9, null, false, 0, 0, 0, 1));
                //Scramble Card 
                enemyStartingDeck.Add(new Card(0, null, false, 0, 7, 0, 1));
                break;
            case 1:
                //Cockroach Enemy
                //Curl Up Card (unfinished)
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 1));
                //Attempt flight Card 
                enemyStartingDeck.Add(new Card(0, null, false, 0, 7, 0, 1));
                //Pincer Card
                enemyStartingDeck.Add(new Card(7, null, false, 0, 0, 0, 1));
                //Scramble Card 
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 1));
                break;
            case 2:
                //Mouse Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card(7, null, false, 0, 0, 0, 1));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card(4, null, false, 0, 0, 0, 1));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 1));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card(8, null, false, 0, 0, 0, 1));
                break;
            case 3:
                //Pigeon Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card(7, null, false, 0, 0, 0, 1));
                //Home In Card (unfinished) 
                enemyStartingDeck.Add(new Card(5, null, false, 0, 0, 0, 1));
                //Roost Card 
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 6, 1));
                //Wing Defence Card 
                enemyStartingDeck.Add(new Card(0, null, false, 0, 8, 0, 1));
                break;
            case 4:
                //Rabbit Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card(9, null, false, 0, 0, 0, 1));
                //Rear kick Card 
                enemyStartingDeck.Add(new Card(11, null, false, 0, 0, 0, 1));
                //Run Away Card (unfinished)
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 1));
                //Keen Sense Card 
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 2));
                break;
            case 5:
                //Rat Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card(9, null, false, 0, 0, 0, 1));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card(5, null, false, 0, 0, 0, 1));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 1));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card(10, null, false, 0, 0, 0, 1));
                break;
            case 6:
                //Rooster Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card(10, null, false, 0, 0, 0, 1));
                //Intimidate Card (unfinished)
                enemyStartingDeck.Add(new Card(0, null, false, 0, 5, 0, 1));
                //Feather Dance Card 
                enemyStartingDeck.Add(new Card(5, null, false, 0, 0, 5, 1));
                //Flock Attack Card (unfinished)
                enemyStartingDeck.Add(new Card(12, null, false, 0, 0, 0, 1));
                break;
            //Stage 2 Enemies
            case 7:
                //Dog Enemy
                //Hound Card (unfinished)
                enemyStartingDeck.Add(new Card(5, null, false, 0, 0, 0, 1));
                //Bite Card
                enemyStartingDeck.Add(new Card(12, null, false, 0, 0, 0, 1));
                //Pounce Card 
                enemyStartingDeck.Add(new Card(7, null, false, 0, 0, 0, 1));
                //Bare Teeth Card
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 2));
                break;
            case 8:
                //Lizard Enemy
                //Camouflage Card (unfinished)
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 1));
                //Tail Lash Card
                enemyStartingDeck.Add(new Card(10, null, false, 0, 0, 0, 1));
                //Shed Tail Card 
                enemyStartingDeck.Add(new Card(15, null, false, 0, 0, -5, 1));
                //Bite Card
                enemyStartingDeck.Add(new Card(8, null, false, 0, 0, 0, 1));
                break;
            case 9:
                //Monkey Enemy
                //Use Tools Card 
                enemyStartingDeck.Add(new Card(7, null, false, 0, 7, 0, 1));
                //Gouge Card
                enemyStartingDeck.Add(new Card(15, null, false, 0, 0, 0, 1));
                //Swing High Card (unfinished)
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 1));
                //Pummel Card (unfinished)
                enemyStartingDeck.Add(new Card(8, null, false, 0, 0, 0, 1));
                break;
            case 10:
                //Pig Enemy
                //Thick Skin Card
                enemyStartingDeck.Add(new Card(12, null, false, 0, 0, 0, 1));
                //Trample Card (unfinished)
                enemyStartingDeck.Add(new Card(10, null, false, 0, 0, 0, 1));
                //Roll Around Card 
                enemyStartingDeck.Add(new Card(4, null, false, 0, 7, 0, 1));
                //Sniff Out Card
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 2));
                break;
            case 11:
                //Scorpion Enemy
                //Clamp Card
                enemyStartingDeck.Add(new Card(5, null, false, 0, 5, 0, 1));
                //Tail Lash Card 
                enemyStartingDeck.Add(new Card(5, null, false, 0, 0, -1, 1));
                //Exoskeleton Card 
                enemyStartingDeck.Add(new Card(0, null, false, 0, 10, 0, 1));
                //Envenom Card
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, -2, 1));
                break;
            case 12:
                //Tarantula Enemy
                //Spin Web Card
                enemyStartingDeck.Add(new Card(0, null, false, 0, 8, 0, 1));
                //Envenom Card 
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, -2, 1));
                //Fang Strike Card 
                enemyStartingDeck.Add(new Card(12, null, false, 0, 0, 0, 1));
                //Pin down Card
                enemyStartingDeck.Add(new Card(5, null, false, 0, 5, 0, 1));
                break;
            case 13:
                //Turtle Enemy
                //Snap Card
                enemyStartingDeck.Add(new Card(10, null, false, 0, 0, 0, 1));
                //Slow Start Card 
                enemyStartingDeck.Add(new Card(0, null, false, 0, 0, 0, 1));
                //Shell Attack Card 
                enemyStartingDeck.Add(new Card(6, null, false, 0, 6, 0, 1));
                //Shell Armour Card
                enemyStartingDeck.Add(new Card(0, null, false, 0, 12, 0, 1));
                break;
            default:
                //In case of case failure
                //Punch Card
                enemyStartingDeck.Add(new Card(5, null, false, 0, 0, 0, 1));
                //Punch Card 
                enemyStartingDeck.Add(new Card(7, null, false, 0, 0, 0, 1));
                //Kick Card 
                enemyStartingDeck.Add(new Card(8, null, false, 0, 0, 0, 1));
                //Kick Card 
                enemyStartingDeck.Add(new Card(15, null, false, 0, 0, 0, 1));
                break;
        }
    }
}
