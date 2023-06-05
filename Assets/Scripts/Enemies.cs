using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public List<Enemy> stageEnemies = new List<Enemy>();
    public List<Enemy> stageBosses = new List<Enemy>();

    public void Start()
    {
        createStageEnemies();
    }

    public void createStageEnemies()
    {
        //Stage 1
        //Ant Enemy 
        stageEnemies.Add(new Enemy("Ant", assignStartingEnemyCards(0), 15, 0, 1, 1));
        //CockRoach Enemy
        stageEnemies.Add(new Enemy("Cockroach", assignStartingEnemyCards(1), 20, 0, 1, 1));
        //Mouse Enemy 
        stageEnemies.Add(new Enemy("Mouse", assignStartingEnemyCards(2), 20, 0, 1, 1));
        //Pigeon Enemy 
        stageEnemies.Add(new Enemy("Pigeon", assignStartingEnemyCards(3), 15, 0, 1, 1));
        //Rabbit Enemy  
        stageEnemies.Add(new Enemy("Rabbit", assignStartingEnemyCards(4), 40, 0, 2, 1));
        //Rat
        stageEnemies.Add(new Enemy("Rat", assignStartingEnemyCards(5), 35, 0, 2, 1));
        //Rooster Enemy (Boss)
        stageBosses.Add(new Enemy("Rooster", assignStartingEnemyCards(6), 50, 0, 3, 1));
    }

    public List<Card> assignStartingEnemyCards(int enemyId)
    {
        List<Card> enemyStartingDeck = new List <Card>() ;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
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
                return enemyStartingDeck;
        }
    }
}
