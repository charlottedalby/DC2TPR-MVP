using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class: Enemies
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. stageEnemies: List of all Enemies in Game

    Methods: 

    a. createStageEnemies() 
    b. selectEnemy()
    c. asignStartingEnemyCards()

*/

public class Enemies : MonoBehaviour
{
    public List<Enemy> stageEnemies = new List<Enemy>();

    /*
	    Method: createStageEnemies()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Creates Enemies for each Stage 
        b. Stage 1: 
            i. Ant
            ii. Cockroach
            iii. Mouse
            iv. Pigeon
            v. Rabbit
            vi. Rat
            vii. Rooster
        c. Stage 2: 
            i. Dog
            ii. Lizzard
            iii. Pig
            iv. Scorpion
            v. Tarantula 
            vi. Turtle
    */

    public void createStageEnemies()
    {
        stageEnemies.Add(new Enemy("Ant", assignStartingEnemyCards(0), 15, 0, 1, 1));
        stageEnemies.Add(new Enemy("Cockroach", assignStartingEnemyCards(1), 20, 0, 1, 1));
        stageEnemies.Add(new Enemy("Mouse", assignStartingEnemyCards(2), 20, 0, 1, 1));
        stageEnemies.Add(new Enemy("Pigeon", assignStartingEnemyCards(3), 15, 0, 1, 1));
        stageEnemies.Add(new Enemy("Rabbit", assignStartingEnemyCards(4), 40, 0, 2, 1));
        stageEnemies.Add(new Enemy("Rat", assignStartingEnemyCards(5), 35, 0, 2, 1));
        stageEnemies.Add(new Enemy("Rooster", assignStartingEnemyCards(6), 50, 0, 3, 1));
        
        stageEnemies.Add(new Enemy("Dog", assignStartingEnemyCards(7), 45, 0, 2, 2));
        stageEnemies.Add(new Enemy("Lizard", assignStartingEnemyCards(8), 30, 0, 1, 2));
        stageEnemies.Add(new Enemy("Monkey", assignStartingEnemyCards(9), 60, 0, 3, 2));
        stageEnemies.Add(new Enemy("Pig", assignStartingEnemyCards(10), 50, 0, 2, 2)); 
        stageEnemies.Add(new Enemy("Scorpion", assignStartingEnemyCards(11), 25, 0, 1, 2));
        stageEnemies.Add(new Enemy("Tarantula", assignStartingEnemyCards(12), 25, 0, 1, 2));
        stageEnemies.Add(new Enemy("Turtle", assignStartingEnemyCards(13), 35, 0, 1, 2));
    }

    /*
	    Method: selectEnemy()
        Visibility: Public 
        Output: Enemy
        Purpose: 

        a. Runs Function createStageEnemies()
        b. Creates variable isEnemyChosen and sets it to false
        c. Creates variable enemyIndex and sets it to 0
        d. While enemy has not been chosen 
        e. Enemy index is set to random range between 0 and 13
        f. If enemy in list stageEnemies difficulty is equal to chose difficulty 
        g. If enemy in list stageEnemies stage is equal to player current stage 
        h. isEnemyChosen set to true 
        i. Returns chosen enemy from stageEnemies 
        j. Returns Null if above is false
    */

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

    /*
	    Method: assignStartingEnemyCards()
        Visibility: Public 
        Output: List<Card>
        Purpose: 

        a. Create enemyStartingDeck List
        b. Runs Case depending on functions inputted integer 
        c. assigns enemy cards 
    */

    public List<Card> assignStartingEnemyCards(int enemyId)
    {
        List<Card> enemyStartingDeck = new List <Card>();
        switch(enemyId)
        {
            //Stage 1 Enemies
            case 0:
                // Ant Enemy
                //Curl Up Card (unfinished)
                enemyStartingDeck.Add(new Card("Curl Up", 0, false, 0, 0, 0, 1, false, 50));
                //Team Attack Card (unfinished)
                enemyStartingDeck.Add(new Card("Team Attack", 8, false, 0, 0, 0, 1, false, 0));
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer", 9, false, 0, 0, 0, 1, false, 0));
                //Scramble Card 
                enemyStartingDeck.Add(new Card("Scramble", 0, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 1:
                //Cockroach Enemy
                //Curl Up Card (unfinished)
                enemyStartingDeck.Add(new Card("Curl Up", 0, false, 0, 0, 0, 1, false, 50));
                //Attempt flight Card 
                enemyStartingDeck.Add(new Card("Attempt Flight", 0, false, 0, 7, 0, 1, false, 0));
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer", 9, false, 0, 0, 0, 1, false, 0));
                //Scramble Card 
                enemyStartingDeck.Add(new Card("Scramble", 0, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 2:
                //Mouse Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw", 9, false, 0, 0, 0, 1, false, 0));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card("Clamp Down", 5, false, 0, 0, 0, 1, false, 0));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card("Scurry", 0, false, 0, 0, 0, 1, false, 50));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card("Tail Strike", 10, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 3:
                //Pigeon Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck", 13, false, 0, 0, 0, 1, false, 0));
                //Home In Card (unfinished) 
                enemyStartingDeck.Add(new Card("Home In", 6, false, 0, 0, 0, 1, true, 0));
                //Roost Card 
                enemyStartingDeck.Add(new Card("Roost", 0, false, 0, 0, 6, 1, false, 0));
                //Wing Defence Card 
                enemyStartingDeck.Add(new Card("Wing Defence", 0, false, 0, 7, 0, 1, false, 0));
                return enemyStartingDeck;
            case 4:
                //Rabbit Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw", 9, false, 0, 0, 0, 1, false, 0));
                //Rear kick Card 
                enemyStartingDeck.Add(new Card("Rear Kick", 11, false, 0, 0, 0, 1, false, 0));
                //Run Away Card (unfinished)
                enemyStartingDeck.Add(new Card("Run Away", 0, false, 0, 0, 0, 1, false, 75));
                //Keen Sense Card 
                enemyStartingDeck.Add(new Card("Keen Sense", 0, false, 0, 0, 0, 2, false, 0));
                return enemyStartingDeck;
            case 5:
                //Rat Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw", 9, false, 0, 0, 0, 1, false, 0));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card("Clamp Down", 5, false, 0, 0, 0, 1, false, 0));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card("Scurry", 0, false, 0, 0, 0, 1, false, 0));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card("Tail Strike", 10, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 6:
                //Rooster Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck", 13, false, 0, 0, 0, 1, false, 0));
                //Intimidate Card (unfinished)
                enemyStartingDeck.Add(new Card("Intimidate", 0, false, 0, 10, 0, 1, false, 0));
                //Feather Dance Card 
                enemyStartingDeck.Add(new Card("Feather Dance", 6, false, 0, 0, 6, 1, false, 0));
                //Flock Attack Card (unfinished)
                enemyStartingDeck.Add(new Card("Flock Attack", 15, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            //Stage 2 Enemies
            case 7:
                //Dog Enemy
                //Hound Card (unfinished)
                enemyStartingDeck.Add(new Card("Hound", 5, false, 0, 0, 0, 1, false, 0));
                //Bite Card
                enemyStartingDeck.Add(new Card("Bite", 12, false, 0, 0, 0, 1, false, 0));
                //Pounce Card 
                enemyStartingDeck.Add(new Card("Pounce", 7, false, 0, 0, 0, 1, false, 0));
                //Bare Teeth Card
                enemyStartingDeck.Add(new Card("Bare Teeth", 0, false, 0, 0, 0, 2, false, 0));
                return enemyStartingDeck;
            case 8:
                //Lizard Enemy
                //Camouflage Card (unfinished)
                enemyStartingDeck.Add(new Card("Camouflage", 0, false, 0, 0, 0, 1, false, 100));
                //Tail Lash Card
                enemyStartingDeck.Add(new Card("Tail Lash", 10, false, 0, 0, 0, 1, false, 0));
                //Shed Tail Card 
                enemyStartingDeck.Add(new Card("Shed Tail", 15, false, 0, 0, -5, 1, false, 0));
                //Bite Card
                enemyStartingDeck.Add(new Card("Bite", 8, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 9:
                //Monkey Enemy
                //Use Tools Card 
                enemyStartingDeck.Add(new Card("Use Tools", 7, false, 0, 7, 0, 1, false, 0));
                //Gouge Card
                enemyStartingDeck.Add(new Card("Gouge", 15, false, 0, 0, 0, 1, false, 0));
                //Swing High Card (unfinished)
                enemyStartingDeck.Add(new Card("Swing High", 0, false, 0, 0, 0, 1, false, 100));
                //Pummel Card (unfinished)
                enemyStartingDeck.Add(new Card("Pummel", 8, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 10:
                //Pig Enemy
                //Thick Skin Card
                enemyStartingDeck.Add(new Card("Thick Skin", 12, false, 0, 0, 0, 1, false, 0));
                //Trample Card (unfinished)
                enemyStartingDeck.Add(new Card("Trample", 10, false, 0, 0, 0, 1, false, 0));
                //Roll Around Card 
                enemyStartingDeck.Add(new Card("Roll Around", 4, false, 0, 7, 0, 1, false, 0));
                //Sniff Out Card
                enemyStartingDeck.Add(new Card("Sniff Out", 0, false, 0, 0, 0, 2, false, 0));
                return enemyStartingDeck;
            case 11:
                //Scorpion Enemy
                //Clamp Card
                enemyStartingDeck.Add(new Card("Clamp", 5, false, 0, 5, 0, 1, false, 0));
                //Tail Lash Card 
                enemyStartingDeck.Add(new Card("Tail Lash", 5, false, 0, 0, -1, 1, false, 0));
                //Exoskeleton Card 
                enemyStartingDeck.Add(new Card("Exoskeleton", 0, false, 0, 10, 0, 1, false, 0));
                //Envenom Card
                enemyStartingDeck.Add(new Card("Envenom", 0, false, 0, 0, -2, 1, false, 0));
                return enemyStartingDeck;
            case 12:
                //Tarantula Enemy
                //Spin Web Card
                enemyStartingDeck.Add(new Card("Spin Web", 0, false, 0, 8, 0, 1, false, 0));
                //Envenom Card 
                enemyStartingDeck.Add(new Card("Envenom", 0, false, 0, 0, -2, 1, false, 0));
                //Fang Strike Card 
                enemyStartingDeck.Add(new Card("Fang Strike", 12, false, 0, 0, 0, 1, false, 0));
                //Pin down Card
                enemyStartingDeck.Add(new Card("Pin down", 5, false, 0, 5, 0, 1, false, 0));
                return enemyStartingDeck;
            case 13:
                //Turtle Enemy
                //Snap Card
                enemyStartingDeck.Add(new Card("Snap", 10, false, 0, 0, 0, 1, false, 0));
                //Slow Start Card 
                enemyStartingDeck.Add(new Card("Slow Start", 0, false, 0, 0, 0, 1, false, 0));
                //Shell Attack Card 
                enemyStartingDeck.Add(new Card("Shell Attack", 6, false, 0, 6, 0, 1, false, 0));
                //Shell Armour Card
                enemyStartingDeck.Add(new Card("Shell Armour", 0, false, 0, 12, 0, 1, false, 0));
                return enemyStartingDeck;
            default:
                //In case of case failure
                //Punch Card
                enemyStartingDeck.Add(new Card("Punch", 5, false, 0, 0, 0, 1, false, 0));
                //Punch Card 
                enemyStartingDeck.Add(new Card("Punch", 7, false, 0, 0, 0, 1, false, 0));
                //Kick Card 
                enemyStartingDeck.Add(new Card("Kick", 8, false, 0, 0, 0, 1, false, 0));
                //Kick Card 
                enemyStartingDeck.Add(new Card("Kick", 15, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
        }
    }
}
