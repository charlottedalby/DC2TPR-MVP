using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public List<Enemy> stageEnemies = new List<Enemy>();
    public List<Enemy> stageBosses = new List<Enemy>();

    public void Start()
    {
    
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
        stageEnemies.Add(new Enemy("Rooster", assignStartingEnemyCards(6), 50, 0, 3, 1));

        //Stage 2 (WIP)
        //Dog Enemy 
        stageEnemies.Add(new Enemy("Dog", assignStartingEnemyCards(7), 45, 0, 2, 2));
        //Lizard Enemy
        stageEnemies.Add(new Enemy("Lizard", assignStartingEnemyCards(8), 30, 0, 1, 2));
        //Monkey Enemy  (Boss)
        stageEnemies.Add(new Enemy("Monkey", assignStartingEnemyCards(9), 60, 0, 3, 2));
        //Pig Enemy 
        stageEnemies.Add(new Enemy("Pig", assignStartingEnemyCards(10), 50, 0, 2, 2));
        //Scorpion Enemy  
        stageEnemies.Add(new Enemy("Scorpion", assignStartingEnemyCards(11), 25, 0, 1, 2));
        //Tarantula Enemy
        stageEnemies.Add(new Enemy("Tarantula", assignStartingEnemyCards(12), 25, 0, 1, 2));
        //Turtle Enemy (Boss)
        stageEnemies.Add(new Enemy("Turtle", assignStartingEnemyCards(13), 35, 0, 1, 2));
    }

    
    public Enemy selectEnemy(int battleDifficulty, int currentStage) {
        createStageEnemies();
        bool isEnemyChosen = false;
        int enemyIndex = 0;
        while (!isEnemyChosen) {
            enemyIndex = Random.Range(0, 13);
            if (stageEnemies[enemyIndex].difficulty == battleDifficulty) {
                if (stageEnemies[enemyIndex].stage == currentStage) {
                    isEnemyChosen = true;                 
                    return stageEnemies[enemyIndex];
                }
            }
        }
        return null;
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
                enemyStartingDeck.Add(new Card("Curl Up", 0, false, 0, 0, 0, 1));
                //Team Attack Card (unfinished)
                enemyStartingDeck.Add(new Card("Team Attack", 8, false, 0, 0, 0, 1));
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer", 9, false, 0, 0, 0, 1));
                //Scramble Card 
                enemyStartingDeck.Add(new Card("Scramble", 0, false, 0, 0, 0, 1));
                return enemyStartingDeck;
            case 1:
                //Cockroach Enemy
                //Curl Up Card (unfinished)
                enemyStartingDeck.Add(new Card("Curl Up", 0, false, 0, 0, 0, 1));
                //Attempt flight Card 
                enemyStartingDeck.Add(new Card("Attempt Flight", 0, false, 0, 7, 0, 1));
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer", 7, false, 0, 0, 0, 1));
                //Scramble Card 
                enemyStartingDeck.Add(new Card("Scramble", 0, false, 0, 0, 0, 1));
                return enemyStartingDeck;
            case 2:
                //Mouse Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw", 7, false, 0, 0, 0, 1));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card("Clamp Down", 4, false, 0, 0, 0, 1));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card("Scurry", 0, false, 0, 0, 0, 1));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card("Tail Strike", 8, false, 0, 0, 0, 1));
                return enemyStartingDeck;
            case 3:
                //Pigeon Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck", 7, false, 0, 0, 0, 1));
                //Home In Card (unfinished) 
                enemyStartingDeck.Add(new Card("Home In", 6, false, 0, 0, 0, 1));
                //Roost Card 
                enemyStartingDeck.Add(new Card("Roost", 0, false, 0, 0, 6, 1));
                //Wing Defence Card 
                enemyStartingDeck.Add(new Card("Wing Defence", 0, false, 0, 7, 0, 1));
                return enemyStartingDeck;
            case 4:
                //Rabbit Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw", 9, false, 0, 0, 0, 1));
                //Rear kick Card 
                enemyStartingDeck.Add(new Card("Rear kick", 11, false, 0, 0, 0, 1));
                //Run Away Card (unfinished)
                enemyStartingDeck.Add(new Card("Run Away", 0, false, 0, 0, 0, 1));
                //Keen Sense Card 
                enemyStartingDeck.Add(new Card("Keen Sense", 0, false, 0, 0, 0, 2));
                return enemyStartingDeck;
            case 5:
                //Rat Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw", 9, false, 0, 0, 0, 1));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card("Clamp Down", 5, false, 0, 0, 0, 1));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card("Scurry", 0, false, 0, 0, 0, 1));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card("Tail Strike", 10, false, 0, 0, 0, 1));
                return enemyStartingDeck;
            case 6:
                //Rooster Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck", 13, false, 0, 0, 0, 1));
                //Intimidate Card (unfinished)
                enemyStartingDeck.Add(new Card("Intimidate", 0, false, 0, 10, 0, 1));
                //Feather Dance Card 
                enemyStartingDeck.Add(new Card("Feather Dance", 6, false, 0, 0, 6, 1));
                //Flock Attack Card (unfinished)
                enemyStartingDeck.Add(new Card("Flock Attack", 15, false, 0, 0, 0, 1));
                return enemyStartingDeck;
            //Stage 2 Enemies
            case 7:
                //Dog Enemy
                //Hound Card (unfinished)
                enemyStartingDeck.Add(new Card("Hound", 5, false, 0, 0, 0, 1));
                //Bite Card
                enemyStartingDeck.Add(new Card("Bite", 12, false, 0, 0, 0, 1));
                //Pounce Card 
                enemyStartingDeck.Add(new Card("Pounce", 7, false, 0, 0, 0, 1));
                //Bare Teeth Card
                enemyStartingDeck.Add(new Card("Bare Teeth", 0, false, 0, 0, 0, 2));
                return enemyStartingDeck;
            case 8:
                //Lizard Enemy
                //Camouflage Card (unfinished)
                enemyStartingDeck.Add(new Card("Camouflage", 0, false, 0, 0, 0, 1));
                //Tail Lash Card
                enemyStartingDeck.Add(new Card("Tail Lash", 10, false, 0, 0, 0, 1));
                //Shed Tail Card 
                enemyStartingDeck.Add(new Card("Shed Tail", 15, false, 0, 0, -5, 1));
                //Bite Card
                enemyStartingDeck.Add(new Card("Bite", 8, false, 0, 0, 0, 1));
                return enemyStartingDeck;
            case 9:
                //Monkey Enemy
                //Use Tools Card 
                enemyStartingDeck.Add(new Card("Use Tools", 7, false, 0, 7, 0, 1));
                //Gouge Card
                enemyStartingDeck.Add(new Card("Gouge", 15, false, 0, 0, 0, 1));
                //Swing High Card (unfinished)
                enemyStartingDeck.Add(new Card("Swing High", 0, false, 0, 0, 0, 1));
                //Pummel Card (unfinished)
                enemyStartingDeck.Add(new Card("Pummel", 8, false, 0, 0, 0, 1));
                return enemyStartingDeck;
            case 10:
                //Pig Enemy
                //Thick Skin Card
                enemyStartingDeck.Add(new Card("Thick Skin", 12, false, 0, 0, 0, 1));
                //Trample Card (unfinished)
                enemyStartingDeck.Add(new Card("Trample", 10, false, 0, 0, 0, 1));
                //Roll Around Card 
                enemyStartingDeck.Add(new Card("Roll Around", 4, false, 0, 7, 0, 1));
                //Sniff Out Card
                enemyStartingDeck.Add(new Card("Sniff Out", 0, false, 0, 0, 0, 2));
                return enemyStartingDeck;
            case 11:
                //Scorpion Enemy
                //Clamp Card
                enemyStartingDeck.Add(new Card("Clamp", 5, false, 0, 5, 0, 1));
                //Tail Lash Card 
                enemyStartingDeck.Add(new Card("Tail Lash", 5, false, 0, 0, -1, 1));
                //Exoskeleton Card 
                enemyStartingDeck.Add(new Card("Exoskeleton", 0, false, 0, 10, 0, 1));
                //Envenom Card
                enemyStartingDeck.Add(new Card("Envenom", 0, false, 0, 0, -2, 1));
                return enemyStartingDeck;
            case 12:
                //Tarantula Enemy
                //Spin Web Card
                enemyStartingDeck.Add(new Card("Spin Web", 0, false, 0, 8, 0, 1));
                //Envenom Card 
                enemyStartingDeck.Add(new Card("Envenom", 0, false, 0, 0, -2, 1));
                //Fang Strike Card 
                enemyStartingDeck.Add(new Card("Fang Strike", 12, false, 0, 0, 0, 1));
                //Pin down Card
                enemyStartingDeck.Add(new Card("Pin down", 5, false, 0, 5, 0, 1));
                return enemyStartingDeck;
            case 13:
                //Turtle Enemy
                //Snap Card
                enemyStartingDeck.Add(new Card("Snap", 10, false, 0, 0, 0, 1));
                //Slow Start Card 
                enemyStartingDeck.Add(new Card("Slow Start", 0, false, 0, 0, 0, 1));
                //Shell Attack Card 
                enemyStartingDeck.Add(new Card("Shell Attack", 6, false, 0, 6, 0, 1));
                //Shell Armour Card
                enemyStartingDeck.Add(new Card("Shell Armour", 0, false, 0, 12, 0, 1));
                return enemyStartingDeck;
            default:
                //In case of case failure
                //Punch Card
                enemyStartingDeck.Add(new Card("Punch", 5, false, 0, 0, 0, 1));
                //Punch Card 
                enemyStartingDeck.Add(new Card("Punch", 7, false, 0, 0, 0, 1));
                //Kick Card 
                enemyStartingDeck.Add(new Card("Kick", 8, false, 0, 0, 0, 1));
                //Kick Card 
                enemyStartingDeck.Add(new Card("Kick", 15, false, 0, 0, 0, 1));
                return enemyStartingDeck;
        }
    }
}
