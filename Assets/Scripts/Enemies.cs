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
        stageEnemies.Add(new Enemy("Turtle", assignStartingEnemyCards(12), 35, 0, 1, 2));

        stageEnemies.Add(new Enemy("Box Jellyfish", assignStartingEnemyCards(13), 30, 0, 1, 3));
        stageEnemies.Add(new Enemy("Eagle", assignStartingEnemyCards(14), 30, 0, 1, 3));
        stageEnemies.Add(new Enemy("Goat", assignStartingEnemyCards(15), 50, 0, 2, 3));
        stageEnemies.Add(new Enemy("Hornet", assignStartingEnemyCards(16), 25, 0, 1, 3)); 
        stageEnemies.Add(new Enemy("Horse", assignStartingEnemyCards(17), 55, 0, 2, 3));
        stageEnemies.Add(new Enemy("Hyena", assignStartingEnemyCards(18), 30, 0, 1, 3));
        stageEnemies.Add(new Enemy("Tiger", assignStartingEnemyCards(19), 60, 0, 1, 3));

        //Placeholder Stage 4 Enemies
        stageEnemies.Add(new Enemy("Dog", assignStartingEnemyCards(19), 45, 0, 2, 4));
        stageEnemies.Add(new Enemy("Lizard", assignStartingEnemyCards(20), 30, 0, 1, 4));
        stageEnemies.Add(new Enemy("Monkey", assignStartingEnemyCards(21), 60, 0, 3, 4));
        stageEnemies.Add(new Enemy("Pig", assignStartingEnemyCards(22), 50, 0, 2, 4)); 
        stageEnemies.Add(new Enemy("Scorpion", assignStartingEnemyCards(23), 25, 0, 1, 4));
        stageEnemies.Add(new Enemy("Turtle", assignStartingEnemyCards(24), 35, 0, 1, 4));

        // Tutorial Enemies
        stageEnemies.Add(new Enemy("Ant", assignStartingEnemyCards(25), 8, 0, 1, 0));
        stageEnemies.Add(new Enemy("Pigeon", assignStartingEnemyCards(26), 15, 0, 2, 0));
        stageEnemies.Add(new Enemy("Rooster", assignStartingEnemyCards(27), 30, 0, 3, 0));
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
            enemyIndex = Random.Range(0, 28);
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
                //Curl Up Card
                enemyStartingDeck.Add(new Card("Curl Up (Ant)", 0, false, 0, 0, 0, 1, false, 50));
                //Team Attack Card
                enemyStartingDeck.Add(new Card("Team Attack (Ant)", 8, false, 0, 0, 0, 1, false, 0));
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer (Ant)", 9, false, 0, 0, 0, 1, false, 0));
                //Exoskeleton
                enemyStartingDeck.Add(new Card("Exoskeleton (Ant)", 0, false, 0, 7, 0, 1, false, 0));
                return enemyStartingDeck;
            case 1:
                //Cockroach Enemy
                //Curl Up Card
                enemyStartingDeck.Add(new Card("Curl Up (Cockroach)", 0, false, 0, 0, 0, 1, false, 50));
                //Attempt flight Card 
                enemyStartingDeck.Add(new Card("Attempt Flight (Cockroach)", 0, false, 0, 7, 0, 1, false, 0));
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer (Cockroach)", 9, false, 0, 0, 0, 1, false, 0));
                //Scramble Card 
                enemyStartingDeck.Add(new Card("Scramble (Cockroach)", 0, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 2:
                //Mouse Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw (Mouse)", 9, false, 0, 0, 0, 1, false, 0));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card("Clamp Down (Mouse)", 5, false, 0, 0, 0, 1, false, 0));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card("Scurry (Mouse)", 0, false, 0, 0, 0, 1, false, 50));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card("Tail Strike (Mouse)", 8, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 3:
                //Pigeon Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck (Pigeon)", 7, false, 0, 0, 0, 1, false, 0));
                //Home In Card (unfinished) 
                enemyStartingDeck.Add(new Card("Home In (Pigeon)", 6, false, 0, 0, 0, 1, true, 0));
                //Roost Card 
                enemyStartingDeck.Add(new Card("Roost (Pigeon)", 0, false, 0, 0, 6, 1, false, 0));
                //Wing Defence Card 
                enemyStartingDeck.Add(new Card("Wing Defence (Pigeon)", 0, false, 0, 7, 0, 1, false, 0));
                return enemyStartingDeck;
            case 4:
                //Rabbit Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw (Rabbit)", 9, false, 0, 0, 0, 1, false, 0));
                //Rear kick Card 
                enemyStartingDeck.Add(new Card("Rear Kick (Rabbit)", 11, false, 0, 0, 0, 1, false, 0));
                //Run Away Card (unfinished)
                enemyStartingDeck.Add(new Card("Run Away (Rabbit)", 0, false, 0, 0, 0, 1, false, 75));
                //Keen Sense Card 
                enemyStartingDeck.Add(new Card("Keen Sense (Rabbit)", 0, false, 0, 0, 0, 2, false, 0));
                return enemyStartingDeck;
            case 5:
                //Rat Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw (Rat)", 9, false, 0, 0, 0, 1, false, 0));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card("Clamp Down (Rat)", 5, false, 0, 0, 0, 1, false, 0));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card("Scurry (Rat)", 0, false, 0, 0, 0, 1, false, 0));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card("Tail Strike (Rat)", 10, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 6:
                //Rooster Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck (Rooster)", 13, false, 0, 0, 0, 1, false, 0));
                //Intimidate Card (unfinished)
                enemyStartingDeck.Add(new Card("Intimidate (Rooster)", 0, false, 0, 10, 0, 1, false, 0));
                //Feather Dance Card 
                enemyStartingDeck.Add(new Card("Feather Dance (Rooster)", 6, false, 0, 0, 6, 1, false, 0));
                //Flock Attack Card (unfinished)
                enemyStartingDeck.Add(new Card("Flock Attack (Rooster)", 15, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            
            //Stage 2 Enemies
            case 7:
                //Dog Enemy
                //Hound Card (unfinished)
                enemyStartingDeck.Add(new Card("Hound (Dog)", 5, false, 0, 0, 0, 1, false, 0));
                //Bite Card
                enemyStartingDeck.Add(new Card("Bite (Dog)", 12, false, 0, 0, 0, 1, false, 0));
                //Pounce Card 
                enemyStartingDeck.Add(new Card("Pounce (Dog)", 7, false, 0, 0, 0, 1, false, 0));
                //Bare Teeth Card
                enemyStartingDeck.Add(new Card("Bare Teeth (Dog)", 0, false, 0, 0, 0, 2, false, 0));
                return enemyStartingDeck;
            case 8:
                //Lizard Enemy
                //Camouflage Card (unfinished)
                enemyStartingDeck.Add(new Card("Camouflage (Lizard)", 0, false, 0, 0, 0, 1, false, 100));
                //Tail Lash Card
                enemyStartingDeck.Add(new Card("Tail Lash (Lizard)", 10, false, 0, 0, 0, 1, false, 0));
                //Shed Tail Card 
                enemyStartingDeck.Add(new Card("Shed Tail (Lizard)", 15, false, 0, 0, -5, 1, false, 0));
                //Bite Card
                enemyStartingDeck.Add(new Card("Bite (Lizard)", 8, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 9:
                //Monkey Enemy
                //Use Tools Card 
                enemyStartingDeck.Add(new Card("User Tools (Monkey)", 7, false, 0, 7, 0, 1, false, 0));
                //Gouge Card
                enemyStartingDeck.Add(new Card("Gouge (Monkey)", 15, false, 0, 0, 0, 1, false, 0));
                //Swing High Card (unfinished)
                enemyStartingDeck.Add(new Card("Swing High (Monkey)", 0, false, 0, 0, 0, 1, false, 100));
                //Pummel Card (unfinished)
                enemyStartingDeck.Add(new Card("Pummel (Monkey)", 8, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 10:
                //Pig Enemy
                //Thick Skin Card
                enemyStartingDeck.Add(new Card("Thick Skin (Pig)", 0, false, 0, 12, 0, 1, false, 0));
                //Trample Card (unfinished)
                enemyStartingDeck.Add(new Card("Trample (Pig)", 10, false, 0, 0, 0, 1, false, 0));
                //Roll Around Card 
                enemyStartingDeck.Add(new Card("Roll Around (Pig)", 4, false, 0, 7, 0, 1, false, 0));
                //Sniff Out Card
                enemyStartingDeck.Add(new Card("Sniff Out (Pig)", 0, false, 0, 0, 0, 2, false, 0));
                return enemyStartingDeck;
            case 11:
                //Scorpion Enemy
                //Clamp Card
                enemyStartingDeck.Add(new Card("Clamp (Scorpion)", 5, false, 0, 5, 0, 1, false, 0));
                //Tail Lash Card 
                enemyStartingDeck.Add(new Card("Tail Lash (Scorpion)", 5, false, 0, 0, -1, 1, false, 0));
                //Exoskeleton Card 
                enemyStartingDeck.Add(new Card("Exoskeleton (Scorpion)", 0, false, 0, 10, 0, 1, false, 0));
                //Envenom Card
                enemyStartingDeck.Add(new Card("Evnvenom (Scorpion)", 0, false, 0, 0, -2, 1, false, 0));
                return enemyStartingDeck;
            case 12:
                //Turtle Enemy
                //Snap Card
                enemyStartingDeck.Add(new Card("Snap (Turtle)", 10, false, 0, 0, 0, 1, false, 0));
                //Slow Start Card 
                enemyStartingDeck.Add(new Card("Slow Start (Turtle)", 0, false, 0, 0, 0, 1, false, 0));
                //Shell Attack Card 
                enemyStartingDeck.Add(new Card("Shell Attack (Turtle)", 6, false, 0, 6, 0, 1, false, 0));
                //Shell Armour Card
                enemyStartingDeck.Add(new Card("Shell Armor (Turtle)", 0, false, 0, 12, 0, 1, false, 0));
                return enemyStartingDeck;
            
            //Stage 3 Enemies
            case 13:
                //Box Jellfish
                //Wrap
                enemyStartingDeck.Add(new Card("Wrap (Jellyfish)", 8, false, 0, 4, 0, 1, false, 0));
                //Sting
                enemyStartingDeck.Add(new Card("Sting (Jellyfish)", 4, false, 0, 0, 0, 1, false, 0));
                //Float Away 
                enemyStartingDeck.Add(new Card("Float Away (Jellyfish)", 0, false, 0, 0, 0, 1, false, 0));
                //Compund Position
                enemyStartingDeck.Add(new Card("Compound Poison (Jellyfish)", 18, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 14:
                //Eagle Enemy
                //Talon Grab 
                enemyStartingDeck.Add(new Card("Talon Grab (Eagle)", 6, false, 0, 6, 0, 1, false, 0));
                //Wing StrikE Card
                enemyStartingDeck.Add(new Card("Wing Strike (Eagle)", 12, false, 0, 0, 0, 1, false, 0));
                //Tear Away Card 
                enemyStartingDeck.Add(new Card("Tear Away (Eagle)", 20, false, 0, 0, -5, 1, false, 0));
                //Glide Card
                enemyStartingDeck.Add(new Card("Glide (Eagle)", 0, false, 0, 5, 0, 2, false, 0));
                return enemyStartingDeck;
            case 15:
                //Goat Enemy
                //Ram
                enemyStartingDeck.Add(new Card("Ram (Goat)", 18, false, 0, 0, 0, 1, false, 0));
                //Horn Card
                enemyStartingDeck.Add(new Card("Horn (Goat)", 8, false, 0, 2, 0, 1, false, 0));
                //Rear Kick 
                enemyStartingDeck.Add(new Card("Rear Kick (Goat)", 10, false, 0, 0, 0, 1, false, 0));
                //Bite
                enemyStartingDeck.Add(new Card("Bite", 10, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 16:
                //Hornet Enemy
                //Poison Sting
                enemyStartingDeck.Add(new Card("Poison Sting (Hornet)", 5, false, 0, 0, 0, 1, false, 0));
                //Buzz Around 
                enemyStartingDeck.Add(new Card("Buzz Around (Hornet)", 0, false, 0, 0, 0, 1, false, 0));
                //Swarm
                enemyStartingDeck.Add(new Card("Swarm (Hornet)", 10, false, 0, 0, 0, 1, false, 0));
                //Sharp Poison
                enemyStartingDeck.Add(new Card("Sharp Poison (Hornet)", 7, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 17:
                //Horse Enemy
                //Gallop
                enemyStartingDeck.Add(new Card("Gallop (Horse)", 0, false, 0, 18, 0, 1, false, 0));
                //Trample 
                enemyStartingDeck.Add(new Card("Trample (Horse)", 12, false, 0, 0, 0, 1, false, 0));
                //Rear Kick
                enemyStartingDeck.Add(new Card("Rear Kick (Horse)", 6, false, 0, 6, 0, 1, false, 0));
                //Run Away
                enemyStartingDeck.Add(new Card("Run Away (Horse)", 5, false, 0, 0, 5, 1, false, 0));
                return enemyStartingDeck;
            case 18:
                //Hyena Enemy
                //Grab and Tear
                enemyStartingDeck.Add(new Card("Grab and Tear (Hyena)", 16, false, 0, 0, 0, 1, false, 0));
                //Bite
                enemyStartingDeck.Add(new Card("Bite (Hyena)", 10, false, 0, 0, 0, 1, false, 0));
                //Pack Tactics
                enemyStartingDeck.Add(new Card("Pack Tactics (Hyena)", 12, false, 0, 0, 0, 1, false, 0));
                //Hunt Down
                enemyStartingDeck.Add(new Card("Hunt Down (Hyena)", 0, false, 0, 12, 0, 2, false, 0));
                return enemyStartingDeck;
            case 19:
                //Tiger Enemy
                //Roar
                enemyStartingDeck.Add(new Card("Roar (Tiger)", 5, false, 0, 0, 0, 2, false, 0));
                //Bite Card
                enemyStartingDeck.Add(new Card("Pounce (Tiger)", 7, false, 0, 7, 0, 1, false, 0));
                //Claw Swipe
                enemyStartingDeck.Add(new Card("Claw Swipe (Tiger)", 13, false, 0, 0, 0, 1, false, 0));
                //Crunch
                enemyStartingDeck.Add(new Card("Crunch (Tiger)", 20, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            
            //Placeholder cases for Stage 4 Cards
            case 20:
                //Lizard Enemy
                //Camouflage Card (unfinished)
                enemyStartingDeck.Add(new Card("Camouflage (Lizard)", 0, false, 0, 0, 0, 1, false, 100));
                //Tail Lash Card
                enemyStartingDeck.Add(new Card("Tail Lash (Lizard)", 10, false, 0, 0, 0, 1, false, 0));
                //Shed Tail Card 
                enemyStartingDeck.Add(new Card("Shed Tail (Lizard)", 15, false, 0, 0, -5, 1, false, 0));
                //Bite Card
                enemyStartingDeck.Add(new Card("Bite (Lizard)", 8, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 21:
                //Monkey Enemy
                //Use Tools Card 
                enemyStartingDeck.Add(new Card("User Tools (Monkey)", 7, false, 0, 7, 0, 1, false, 0));
                //Gouge Card
                enemyStartingDeck.Add(new Card("Gouge (Monkey)", 15, false, 0, 0, 0, 1, false, 0));
                //Swing High Card (unfinished)
                enemyStartingDeck.Add(new Card("Swing High (Monkey)", 0, false, 0, 0, 0, 1, false, 100));
                //Pummel Card (unfinished)
                enemyStartingDeck.Add(new Card("Pummel (Monkey)", 8, false, 0, 0, 0, 1, false, 0));
                return enemyStartingDeck;
            case 22:
                //Pig Enemy
                //Thick Skin Card
                enemyStartingDeck.Add(new Card("Thick Skin (Pig)", 0, false, 0, 12, 0, 1, false, 0));
                //Trample Card (unfinished)
                enemyStartingDeck.Add(new Card("Trample (Pig)", 10, false, 0, 0, 0, 1, false, 0));
                //Roll Around Card 
                enemyStartingDeck.Add(new Card("Roll Around (Pig)", 4, false, 0, 7, 0, 1, false, 0));
                //Sniff Out Card
                enemyStartingDeck.Add(new Card("Sniff Out (Pig)", 0, false, 0, 0, 0, 2, false, 0));
                return enemyStartingDeck;
            case 23:
                //Scorpion Enemy
                //Clamp Card
                enemyStartingDeck.Add(new Card("Clamp (Scorpion)", 5, false, 0, 5, 0, 1, false, 0));
                //Tail Lash Card 
                enemyStartingDeck.Add(new Card("Tail Lash (Scorpion)", 5, false, 0, 0, -1, 1, false, 0));
                //Exoskeleton Card 
                enemyStartingDeck.Add(new Card("Exoskeleton (Scorpion)", 0, false, 0, 10, 0, 1, false, 0));
                //Envenom Card
                enemyStartingDeck.Add(new Card("Evnvenom (Scorpion)", 0, false, 0, 0, -2, 1, false, 0));
                return enemyStartingDeck;
            case 24:
                //Turtle Enemy
                //Snap Card
                enemyStartingDeck.Add(new Card("Snap (Turtle)", 10, false, 0, 0, 0, 1, false, 0));
                //Slow Start Card 
                enemyStartingDeck.Add(new Card("Slow Start (Turtle)", 0, false, 0, 0, 0, 1, false, 0));
                //Shell Attack Card 
                enemyStartingDeck.Add(new Card("Shell Attack (Turtle)", 6, false, 0, 6, 0, 1, false, 0));
                //Shell Armour Card
                enemyStartingDeck.Add(new Card("Shell Armor (Turtle)", 0, false, 0, 12, 0, 1, false, 0));
                return enemyStartingDeck;
            //Tutorial Enemies
            case 25:
                // Ant Enemy
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer (Ant)", 9, false, 0, 0, 0, 1, false, 0));
                //Curl Up Card
                enemyStartingDeck.Add(new Card("Curl Up (Ant)", 0, false, 0, 0, 0, 1, false, 50));
                //Team Attack Card
                enemyStartingDeck.Add(new Card("Team Attack (Ant)", 8, false, 0, 0, 0, 1, false, 0));
                //Exoskeleton
                enemyStartingDeck.Add(new Card("Exoskeleton (Ant)", 0, false, 0, 7, 0, 1, false, 0));
                return enemyStartingDeck;
            case 26:
                //Pigeon Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck (Pigeon)", 7, false, 0, 0, 0, 1, false, 0));
                //Home In Card (unfinished) 
                enemyStartingDeck.Add(new Card("Home In (Pigeon)", 6, false, 0, 0, 0, 1, true, 0));
                //Roost Card 
                enemyStartingDeck.Add(new Card("Roost (Pigeon)", 0, false, 0, 0, 6, 1, false, 0));
                //Wing Defence Card 
                enemyStartingDeck.Add(new Card("Wing Defence (Pigeon)", 0, false, 0, 7, 0, 1, false, 0));
                return enemyStartingDeck;
            case 27:
                //Rooster Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck (Rooster)", 13, false, 0, 0, 0, 1, false, 0));
                //Intimidate Card (unfinished)
                enemyStartingDeck.Add(new Card("Intimidate (Rooster)", 0, false, 0, 10, 0, 1, false, 0));
                //Feather Dance Card 
                enemyStartingDeck.Add(new Card("Feather Dance (Rooster)", 6, false, 0, 0, 6, 1, false, 0));
                //Flock Attack Card (unfinished)
                enemyStartingDeck.Add(new Card("Flock Attack (Rooster)", 15, false, 0, 0, 0, 1, false, 0));
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
