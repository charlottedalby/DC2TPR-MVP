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
            ii. Lizard
            iii. Pig
            iv. Scorpion
            v. Tarantula 
            vi. Turtle
        d. Stage 3: 
            i. Jellyfish
            ii. Eagle
            iii. Goat
            iv. Hornet
            v. Horse
            vi. Hyena
            vii. Tiger
        e. Stage 4:
            i. Shark
            ii. Ox
            iii. Lion
            iv. Bear
            v. Elephant
            vi. Dragon
            vii. Snake
        f. Tutorial
            i. Ant
            ii. Pigeon
            iii.Rooster
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

        //Placeholder Stage 3 enemies
        stageEnemies.Add(new Enemy("Jellyfish", assignStartingEnemyCards(14), 30, 0, 1, 3));
        stageEnemies.Add(new Enemy("Eagle", assignStartingEnemyCards(15), 30, 0, 1, 3));
        stageEnemies.Add(new Enemy("Goat", assignStartingEnemyCards(16), 60, 0, 2, 3));
        stageEnemies.Add(new Enemy("Hornet", assignStartingEnemyCards(17), 25, 0, 1, 3)); 
        stageEnemies.Add(new Enemy("Horse", assignStartingEnemyCards(18), 55, 0, 2, 3));
        stageEnemies.Add(new Enemy("Hyena", assignStartingEnemyCards(19), 30, 0, 1, 3));
        stageEnemies.Add(new Enemy("Tiger", assignStartingEnemyCards(20), 60, 0, 3, 3));

        //Placeholder Stage 4 Enemies
        stageEnemies.Add(new Enemy("Shark", assignStartingEnemyCards(21), 35, 0, 1, 4));
        stageEnemies.Add(new Enemy("Ox", assignStartingEnemyCards(22), 50, 0, 2, 4));
        stageEnemies.Add(new Enemy("Lion", assignStartingEnemyCards(23), 35, 0, 1, 4));
        stageEnemies.Add(new Enemy("Bear", assignStartingEnemyCards(24), 40, 0, 1, 4)); 
        stageEnemies.Add(new Enemy("Elephant", assignStartingEnemyCards(25), 50, 0, 1, 4));
        stageEnemies.Add(new Enemy("Dragon", assignStartingEnemyCards(26), 70, 0, 3, 4));
        stageEnemies.Add(new Enemy("Snake", assignStartingEnemyCards(27), 40, 0, 2, 4));

        // Tutorial Enemies
        stageEnemies.Add(new Enemy("Ant", assignStartingEnemyCards(28), 7, 0, 1, 0));
        stageEnemies.Add(new Enemy("Pigeon", assignStartingEnemyCards(29), 15, 0, 2, 0));
        stageEnemies.Add(new Enemy("Rooster", assignStartingEnemyCards(30), 30, 0, 3, 0));
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
            enemyIndex = Random.Range(0, 31);
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
            case 0:
                enemyStartingDeck.Add(new Card("Curl Up (Ant)", 0, false, 0, 0, 0, 1, false, 50, 0));
                enemyStartingDeck.Add(new Card("Team Attack (Ant)", 8, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Pincer (Ant)", 9, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Exoskeleton (Ant)", 0, false, 0, 7, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 1:
                enemyStartingDeck.Add(new Card("Curl Up (Cockroach)", 0, false, 0, 0, 0, 1, false, 50, 0));
                enemyStartingDeck.Add(new Card("Attempt Flight (Cockroach)", 0, false, 0, 7, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Pincer (Cockroach)", 7, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Scramble (Cockroach)", 0, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 2:
                enemyStartingDeck.Add(new Card("Gnaw (Mouse)", 7, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Clamp Down (Mouse)", 4, false, 0, 0, 0, 1, false, 0, 16));
                enemyStartingDeck.Add(new Card("Scurry (Mouse)", 0, false, 0, 0, 0, 1, false, 50, 0));
                enemyStartingDeck.Add(new Card("Tail Strike (Mouse)", 8, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 3:
                enemyStartingDeck.Add(new Card("Peck (Pigeon)", 7, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Home In (Pigeon)", 6, false, 0, 0, 0, 1, true, 0, 0));
                enemyStartingDeck.Add(new Card("Roost (Pigeon)", 0, false, 0, 0, 6, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Wing Defence (Pigeon)", 0, false, 0, 7, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 4:
                enemyStartingDeck.Add(new Card("Gnaw (Rabbit)", 9, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Rear Kick (Rabbit)", 11, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Run Away (Rabbit)", 0, false, 0, 0, 0, 1, false, 75, 0));
                enemyStartingDeck.Add(new Card("Keen Sense (Rabbit)", 0, false, 0, 0, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 5:
                enemyStartingDeck.Add(new Card("Gnaw (Rat)", 9, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Clamp Down (Rat)", 5, false, 0, 0, 0, 1, false, 0, 15));
                enemyStartingDeck.Add(new Card("Scurry (Rat)", 0, false, 0, 0, 0, 1, false, 75, 0));
                enemyStartingDeck.Add(new Card("Tail Strike (Rat)", 10, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 6:
                enemyStartingDeck.Add(new Card("Peck (Rooster)", 13, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Intimidate (Rooster)", 0, false, 0, 10, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Feather Dance (Rooster)", 6, false, 0, 0, 6, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Flock Attack (Rooster)", 15, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 7:
                enemyStartingDeck.Add(new Card("Hound (Dog)", 5, false, 0, 0, 0, 1, false, 0, 15));
                enemyStartingDeck.Add(new Card("Bite (Dog)", 12, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Pounce (Dog)", 7, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Bare Teeth (Dog)", 0, false, 0, 0, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 8:
                enemyStartingDeck.Add(new Card("Camouflage (Lizard)", 0, false, 0, 0, 0, 1, false, 100, 0));
                enemyStartingDeck.Add(new Card("Tail Lash (Lizard)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Shed Tail (Lizard)", 15, false, 0, 0, -5, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Bite (Lizard)", 8, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 9:
                enemyStartingDeck.Add(new Card("User Tools (Monkey)", 7, false, 0, 7, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Gouge (Monkey)", 15, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Swing High (Monkey)", 0, false, 0, 0, 0, 1, false, 100, 0));
                enemyStartingDeck.Add(new Card("Pummel (Monkey)", 16, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 10:
                enemyStartingDeck.Add(new Card("Thick Skin (Pig)", 0, false, 0, 12, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Trample (Pig)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Roll Around (Pig)", 4, false, 0, 7, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Sniff Out (Pig)", 0, false, 0, 0, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 11:
                enemyStartingDeck.Add(new Card("Clamp (Scorpion)", 5, false, 0, 5, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Tail Lash (Scorpion)", 5, false, 0, 0, 0, 1, false, 0, 1));
                enemyStartingDeck.Add(new Card("Exoskeleton (Scorpion)", 0, false, 0, 10, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Evnvenom (Scorpion)", 0, false, 0, 0, 0, 1, false, 0, 2));
                return enemyStartingDeck;
            case 12:
                enemyStartingDeck.Add(new Card("Spin Web (Tarantula)", 0, false, 0, 8, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Envenom (Tarantula)", 0, false, 0, 0, 0, 1, false, 0, 2));
                enemyStartingDeck.Add(new Card("Fang Strike (Tarantula)", 12, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Pin Down (Tarantula)", 5, false, 0, 5, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 13:
                enemyStartingDeck.Add(new Card("Snap (Turtle)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Slow Start (Turtle)", 0, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Shell Attack (Turtle)", 6, false, 0, 6, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Shell Armor (Turtle)", 0, false, 0, 12, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 14:
                enemyStartingDeck.Add(new Card("Wrap (Jellyfish)", 8, false, 0, 4, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Sting (Jellyfish)", 0, false, 0, 0, 0, 1, false, 0, 3));
                enemyStartingDeck.Add(new Card("Float Away (Jellyfish)", 0, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Compound Poison (Jellyfish)", 0, false, 0, 0, 0, 1, false, 0, 4));
                return enemyStartingDeck;
            case 15:
                enemyStartingDeck.Add(new Card("Talon Grab (Eagle)", 6, false, 0, 6, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Wing Strike (Eagle)", 12, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Tear Away (Eagle)", 0, false, 0, 0, -5, 1, false, 0, 5));
                enemyStartingDeck.Add(new Card("Glide (Eagle)", 0, false, 0, 5, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 16:
                enemyStartingDeck.Add(new Card("Ram (Goat)", 0, false, 0, 0, 0, 1, false, 0, 6));
                enemyStartingDeck.Add(new Card("Horn (Goat)", 8, false, 0, 2, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Rear Kick (Goat)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Bite (Goat)", 10, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 17:
                enemyStartingDeck.Add(new Card("Poison Sting (Hornet)", 5, false, 0, 0, 0, 1, false, 0, 2));
                enemyStartingDeck.Add(new Card("Buzz Around (Hornet)", 0, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Swarm (Hornet)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Sharp Poison (Hornet)", 0, false, 0, 0, 0, 1, false, 0, 7));
                return enemyStartingDeck;
            case 18:
                enemyStartingDeck.Add(new Card("Gallop (Horse)", 0, false, 0, 18, 0, 1, false, 0, 8));
                enemyStartingDeck.Add(new Card("Trample (Horse)", 12, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Rear Kick (Horse)", 6, false, 0, 6, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Run Away (Horse)", 5, false, 0, 0, 5, 1, false, 0, 0));
                return enemyStartingDeck;
            case 19:
                enemyStartingDeck.Add(new Card("Grab and Tear (Hyena)", 0, false, 0, 0, 0, 1, false, 0, 9));
                enemyStartingDeck.Add(new Card("Bite (Hyena)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Pack Tactics (Hyena)", 12, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Hunt Down (Hyena)", 0, false, 0, 12, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 20:
                enemyStartingDeck.Add(new Card("Roar (Tiger)", 5, false, 0, 0, 0, 2, false, 0, 0));
                enemyStartingDeck.Add(new Card("Pounce (Tiger)", 7, false, 0, 7, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Claw Swipe (Tiger)", 13, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Crunch (Tiger)", 0, false, 0, 0, 0, 1, false, 0, 10));
                return enemyStartingDeck;
            case 21:
                enemyStartingDeck.Add(new Card("Sense Blood (Shark)", 0, false, 0, 5, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Bite (Shark)", 6, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Crunch (Shark)", 11, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Rough Skin (Shark)", 0, false, 0, 0, 0, 1, false, 0, 11));
                return enemyStartingDeck;
            case 22:
                enemyStartingDeck.Add(new Card("Ram (Ox)", 0, false, 0, 0, 0, 1, false, 0, 12));
                enemyStartingDeck.Add(new Card("Gore (Ox)", 0, false, 0, 5, 0, 1, false, 0, 13));
                enemyStartingDeck.Add(new Card("Stampede (Ox)", 10, false, 0, 0, 0, 1, false, 100, 0));
                enemyStartingDeck.Add(new Card("Stomp (Ox)", 3, false, 0, 9, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 23:
                enemyStartingDeck.Add(new Card("Roar (Lion)", 0, false, 0, 3, 0, 2, false, 0, 0));
                enemyStartingDeck.Add(new Card("Crunch (Lion)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Pounce (Lion)", 5, false, 0, 6, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Tear Apart (Lion)", 8, false, 0, 0, 0, 0, false, 0, 0));
                return enemyStartingDeck;
            case 24:
                enemyStartingDeck.Add(new Card("Maul (Bear)", 8, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Bite (Bear)", 7, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Chase Down (Bear)", 0, false, 0, 5, 0, 1, false, 0, 15));
                enemyStartingDeck.Add(new Card("Knock Down (Bear)", 6, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 25:
                enemyStartingDeck.Add(new Card("Tusk Spear (Elephant)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Stomp (Elephant)", 3, false, 0, 8, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Throw Weight (Elephant)", 0, false, 0, 0, 0, 1, false, 0, 12));
                enemyStartingDeck.Add(new Card("Trunk Slam (Elephant)", 2, false, 0, 10, 0, 1, false, 0, 0));
                return enemyStartingDeck;

            case 26:
                enemyStartingDeck.Add(new Card("Ascent (Dragon)", 10, false, 0, 0, 0, 1, true, 0, 0));
                enemyStartingDeck.Add(new Card("Tail Strike (Dragon)", 13, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Gather Energy (Dragon)", 0, false, 0, 10, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Zodiac Blast (Dragon)", 4, false, 0, 4, 0, 1, false, 0, 3));
                return enemyStartingDeck;

            case 27:
                enemyStartingDeck.Add(new Card("Envenom (Snake)", 0, false, 0, 0, 0, 1, false, 0, 3));
                enemyStartingDeck.Add(new Card("Wrap (Snake)", 7, false, 0, 7, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Bite (Snake)", 9, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Spit Poison (Snake)", 0, false, 0, 0, 0, 1, false, 0, 14));
                return enemyStartingDeck;

            case 28:
                enemyStartingDeck.Add(new Card("Pincer (Ant)", 9, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Curl Up (Ant)", 0, false, 0, 0, 0, 1, false, 50, 0));
                enemyStartingDeck.Add(new Card("Team Attack (Ant)", 8, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Exoskeleton (Ant)", 0, false, 0, 7, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 29:
                enemyStartingDeck.Add(new Card("Peck (Pigeon)", 7, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Home In (Pigeon)", 6, false, 0, 0, 0, 1, true, 0, 0));
                enemyStartingDeck.Add(new Card("Roost (Pigeon)", 0, false, 0, 0, 6, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Wing Defence (Pigeon)", 0, false, 0, 7, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 30:
                enemyStartingDeck.Add(new Card("Peck (Rooster)", 13, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Intimidate (Rooster)", 0, false, 0, 10, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Feather Dance (Rooster)", 6, false, 0, 0, 6, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Flock Attack (Rooster)", 15, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            default:
                enemyStartingDeck.Add(new Card("Punch", 5, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Punch", 7, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Kick", 8, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Kick", 15, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
        }
    }
}
