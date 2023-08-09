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

        //Placeholder Stage 3 enemies
        stageEnemies.Add(new Enemy("Box Jellyfish", assignStartingEnemyCards(14), 30, 0, 1, 3));
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
        stageEnemies.Add(new Enemy("Grizzly Bear", assignStartingEnemyCards(24), 40, 0, 1, 4)); 
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
            //Stage 1 Enemies
            case 0:
                // Ant Enemy
                //Curl Up Card
                enemyStartingDeck.Add(new Card("Curl Up (Ant)", 0, false, 0, 0, 0, 1, false, 50, 0));
                //Team Attack Card
                enemyStartingDeck.Add(new Card("Team Attack (Ant)", 8, false, 0, 0, 0, 1, false, 0, 0));
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer (Ant)", 9, false, 0, 0, 0, 1, false, 0, 0));
                //Exoskeleton
                enemyStartingDeck.Add(new Card("Exoskeleton (Ant)", 0, false, 0, 7, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 1:
                //Cockroach Enemy
                //Curl Up Card
                enemyStartingDeck.Add(new Card("Curl Up (Cockroach)", 0, false, 0, 0, 0, 1, false, 50, 0));
                //Attempt flight Card 
                enemyStartingDeck.Add(new Card("Attempt Flight (Cockroach)", 0, false, 0, 7, 0, 1, false, 0, 0));
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer (Cockroach)", 7, false, 0, 0, 0, 1, false, 0, 0));
                //Scramble Card 
                enemyStartingDeck.Add(new Card("Scramble (Cockroach)", 0, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 2:
                //Mouse Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw (Mouse)", 7, false, 0, 0, 0, 1, false, 0, 0));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card("Clamp Down (Mouse)", 4, false, 0, 0, 0, 1, false, 0, 16));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card("Scurry (Mouse)", 0, false, 0, 0, 0, 1, false, 50, 0));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card("Tail Strike (Mouse)", 8, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 3:
                //Pigeon Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck (Pigeon)", 7, false, 0, 0, 0, 1, false, 0, 0));
                //Home In Card (unfinished) 
                enemyStartingDeck.Add(new Card("Home In (Pigeon)", 6, false, 0, 0, 0, 1, true, 0, 0));
                //Roost Card 
                enemyStartingDeck.Add(new Card("Roost (Pigeon)", 0, false, 0, 0, 6, 1, false, 0, 0));
                //Wing Defence Card 
                enemyStartingDeck.Add(new Card("Wing Defence (Pigeon)", 0, false, 0, 7, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 4:
                //Rabbit Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw (Rabbit)", 9, false, 0, 0, 0, 1, false, 0, 0));
                //Rear kick Card 
                enemyStartingDeck.Add(new Card("Rear Kick (Rabbit)", 11, false, 0, 0, 0, 1, false, 0, 0));
                //Run Away Card (unfinished)
                enemyStartingDeck.Add(new Card("Run Away (Rabbit)", 0, false, 0, 0, 0, 1, false, 75, 0));
                //Keen Sense Card 
                enemyStartingDeck.Add(new Card("Keen Sense (Rabbit)", 0, false, 0, 0, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 5:
                //Rat Enemy
                //Gnaw Card
                enemyStartingDeck.Add(new Card("Gnaw (Rat)", 9, false, 0, 0, 0, 1, false, 0, 0));
                //Clamp Down (unfinished) 
                enemyStartingDeck.Add(new Card("Clamp Down (Rat)", 5, false, 0, 0, 0, 1, false, 0, 15));
                //Scurry Card (unfinished)
                enemyStartingDeck.Add(new Card("Scurry (Rat)", 0, false, 0, 0, 0, 1, false, 75, 0));
                //Tail Strike Card 
                enemyStartingDeck.Add(new Card("Tail Strike (Rat)", 10, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 6:
                //Rooster Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck (Rooster)", 13, false, 0, 0, 0, 1, false, 0, 0));
                //Intimidate Card (unfinished)
                enemyStartingDeck.Add(new Card("Intimidate (Rooster)", 0, false, 0, 10, 0, 1, false, 0, 0));
                //Feather Dance Card 
                enemyStartingDeck.Add(new Card("Feather Dance (Rooster)", 6, false, 0, 0, 6, 1, false, 0, 0));
                //Flock Attack Card (unfinished)
                enemyStartingDeck.Add(new Card("Flock Attack (Rooster)", 15, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            
            //Stage 2 Enemies
            case 7:
                //Dog Enemy
                //Hound Card (unfinished)
                enemyStartingDeck.Add(new Card("Hound (Dog)", 5, false, 0, 0, 0, 1, false, 0, 15));
                //Bite Card
                enemyStartingDeck.Add(new Card("Bite (Dog)", 12, false, 0, 0, 0, 1, false, 0, 0));
                //Pounce Card 
                enemyStartingDeck.Add(new Card("Pounce (Dog)", 7, false, 0, 0, 0, 1, false, 0, 0));
                //Bare Teeth Card
                enemyStartingDeck.Add(new Card("Bare Teeth (Dog)", 0, false, 0, 0, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 8:
                //Lizard Enemy
                //Camouflage Card (unfinished)
                enemyStartingDeck.Add(new Card("Camouflage (Lizard)", 0, false, 0, 0, 0, 1, false, 100, 0));
                //Tail Lash Card
                enemyStartingDeck.Add(new Card("Tail Lash (Lizard)", 10, false, 0, 0, 0, 1, false, 0, 0));
                //Shed Tail Card 
                enemyStartingDeck.Add(new Card("Shed Tail (Lizard)", 15, false, 0, 0, -5, 1, false, 0, 0));
                //Bite Card
                enemyStartingDeck.Add(new Card("Bite (Lizard)", 8, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 9:
                //Monkey Enemy
                //Use Tools Card 
                enemyStartingDeck.Add(new Card("User Tools (Monkey)", 7, false, 0, 7, 0, 1, false, 0, 0));
                //Gouge Card
                enemyStartingDeck.Add(new Card("Gouge (Monkey)", 15, false, 0, 0, 0, 1, false, 0, 0));
                //Swing High Card (unfinished)
                enemyStartingDeck.Add(new Card("Swing High (Monkey)", 0, false, 0, 0, 0, 1, false, 100, 0));
                //Pummel Card (unfinished)
                enemyStartingDeck.Add(new Card("Pummel (Monkey)", 16, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 10:
                //Pig Enemy
                //Thick Skin Card
                enemyStartingDeck.Add(new Card("Thick Skin (Pig)", 0, false, 0, 12, 0, 1, false, 0, 0));
                //Trample Card (unfinished)
                enemyStartingDeck.Add(new Card("Trample (Pig)", 10, false, 0, 0, 0, 1, false, 0, 0));
                //Roll Around Card 
                enemyStartingDeck.Add(new Card("Roll Around (Pig)", 4, false, 0, 7, 0, 1, false, 0, 0));
                //Sniff Out Card
                enemyStartingDeck.Add(new Card("Sniff Out (Pig)", 0, false, 0, 0, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 11:
                //Scorpion Enemy
                //Clamp Card
                enemyStartingDeck.Add(new Card("Clamp (Scorpion)", 5, false, 0, 5, 0, 1, false, 0, 0));
                //Tail Lash Card 
                enemyStartingDeck.Add(new Card("Tail Lash (Scorpion)", 5, false, 0, 0, 0, 1, false, 0, 1));
                //Exoskeleton Card 
                enemyStartingDeck.Add(new Card("Exoskeleton (Scorpion)", 0, false, 0, 10, 0, 1, false, 0, 0));
                //Envenom Card
                enemyStartingDeck.Add(new Card("Evnvenom (Scorpion)", 0, false, 0, 0, 0, 1, false, 0, 2));
                return enemyStartingDeck;
            case 12:
                //Tarantula Enemy
                //Spin Web Card
                enemyStartingDeck.Add(new Card("Spin Web (Tarantula)", 0, false, 0, 8, 0, 1, false, 0, 0));
                //Envenom Card
                enemyStartingDeck.Add(new Card("Envenom (Tarantula)", 0, false, 0, 0, 0, 1, false, 0, 2));
                //Fang Strike Card
                enemyStartingDeck.Add(new Card("Fang Strike (Tarantula)", 12, false, 0, 0, 0, 1, false, 0, 0));
                //Pin Down Card
                enemyStartingDeck.Add(new Card("Pin Down (Tarantula)", 5, false, 0, 5, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 13:
                //Turtle Enemy
                //Snap Card
                enemyStartingDeck.Add(new Card("Snap (Turtle)", 10, false, 0, 0, 0, 1, false, 0, 0));
                //Slow Start Card 
                enemyStartingDeck.Add(new Card("Slow Start (Turtle)", 0, false, 0, 0, 0, 1, false, 0, 0));
                //Shell Attack Card 
                enemyStartingDeck.Add(new Card("Shell Attack (Turtle)", 6, false, 0, 6, 0, 1, false, 0, 0));
                //Shell Armour Card
                enemyStartingDeck.Add(new Card("Shell Armor (Turtle)", 0, false, 0, 12, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            
            //Stage 3 Enemies
            case 14:
                //Box Jellfish
                //Wrap
                enemyStartingDeck.Add(new Card("Wrap (Jellyfish)", 8, false, 0, 4, 0, 1, false, 0, 0));
                //Sting
                enemyStartingDeck.Add(new Card("Sting (Jellyfish)", 0, false, 0, 0, 0, 1, false, 0, 3));
                //Float Away 
                enemyStartingDeck.Add(new Card("Float Away (Jellyfish)", 0, false, 0, 0, 0, 1, false, 0, 0));
                //Compund Position
                enemyStartingDeck.Add(new Card("Compound Poison (Jellyfish)", 0, false, 0, 0, 0, 1, false, 0, 4));
                return enemyStartingDeck;
            case 15:
                //Eagle Enemy
                //Talon Grab 
                enemyStartingDeck.Add(new Card("Talon Grab (Eagle)", 6, false, 0, 6, 0, 1, false, 0, 0));
                //Wing StrikE Card
                enemyStartingDeck.Add(new Card("Wing Strike (Eagle)", 12, false, 0, 0, 0, 1, false, 0, 0));
                //Tear Away Card 
                enemyStartingDeck.Add(new Card("Tear Away (Eagle)", 0, false, 0, 0, -5, 1, false, 0, 5));
                //Glide Card
                enemyStartingDeck.Add(new Card("Glide (Eagle)", 0, false, 0, 5, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 16:
                //Goat Enemy
                //Ram
                enemyStartingDeck.Add(new Card("Ram (Goat)", 0, false, 0, 0, 0, 1, false, 0, 6));
                //Horn Card
                enemyStartingDeck.Add(new Card("Horn (Goat)", 8, false, 0, 2, 0, 1, false, 0, 0));
                //Rear Kick 
                enemyStartingDeck.Add(new Card("Rear Kick (Goat)", 10, false, 0, 0, 0, 1, false, 0, 0));
                //Bite
                enemyStartingDeck.Add(new Card("Bite (Goat)", 10, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 17:
                //Hornet Enemy
                //Poison Sting
                enemyStartingDeck.Add(new Card("Poison Sting (Hornet)", 5, false, 0, 0, 0, 1, false, 0, 2));
                //Buzz Around 
                enemyStartingDeck.Add(new Card("Buzz Around (Hornet)", 0, false, 0, 0, 0, 1, false, 0, 0));
                //Swarm
                enemyStartingDeck.Add(new Card("Swarm (Hornet)", 10, false, 0, 0, 0, 1, false, 0, 0));
                //Sharp Poison
                enemyStartingDeck.Add(new Card("Sharp Poison (Hornet)", 0, false, 0, 0, 0, 1, false, 0, 7));
                return enemyStartingDeck;
            case 18:
                //Horse Enemy
                //Gallop
                enemyStartingDeck.Add(new Card("Gallop (Horse)", 0, false, 0, 18, 0, 1, false, 0, 8));
                //Trample 
                enemyStartingDeck.Add(new Card("Trample (Horse)", 12, false, 0, 0, 0, 1, false, 0, 0));
                //Rear Kick
                enemyStartingDeck.Add(new Card("Rear Kick (Horse)", 6, false, 0, 6, 0, 1, false, 0, 0));
                //Run Away
                enemyStartingDeck.Add(new Card("Run Away (Horse)", 5, false, 0, 0, 5, 1, false, 0, 0));
                return enemyStartingDeck;
            case 19:
                //Hyena Enemy
                //Grab and Tear
                enemyStartingDeck.Add(new Card("Grab and Tear (Hyena)", 0, false, 0, 0, 0, 1, false, 0, 9));
                //Bite
                enemyStartingDeck.Add(new Card("Bite (Hyena)", 10, false, 0, 0, 0, 1, false, 0, 0));
                //Pack Tactics
                enemyStartingDeck.Add(new Card("Pack Tactics (Hyena)", 12, false, 0, 0, 0, 1, false, 0, 0));
                //Hunt Down
                enemyStartingDeck.Add(new Card("Hunt Down (Hyena)", 0, false, 0, 12, 0, 2, false, 0, 0));
                return enemyStartingDeck;
            case 20:
                //Tiger Enemy
                //Roar
                enemyStartingDeck.Add(new Card("Roar (Tiger)", 5, false, 0, 0, 0, 2, false, 0, 0));
                //Bite Card
                enemyStartingDeck.Add(new Card("Pounce (Tiger)", 7, false, 0, 7, 0, 1, false, 0, 0));
                //Claw Swipe
                enemyStartingDeck.Add(new Card("Claw Swipe (Tiger)", 13, false, 0, 0, 0, 1, false, 0, 0));
                //Crunch
                enemyStartingDeck.Add(new Card("Crunch (Tiger)", 0, false, 0, 0, 0, 1, false, 0, 10));
                return enemyStartingDeck;
            
            //Stage 4 Cards
            case 21:
                // Shark
                enemyStartingDeck.Add(new Card("Sense Blood (Shark)", 0, false, 5, 5, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Bite (Shark)", 6, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Crunch (Shark)", 11, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Rough Skin (Shark)", 0, false, 0, 0, 0, 1, false, 0, 11));
                return enemyStartingDeck;
            case 22:
                //Ox Enemy
                enemyStartingDeck.Add(new Card("Ram (Ox)", 0, false, 0, 0, 0, 1, false, 0, 12));
                enemyStartingDeck.Add(new Card("Gore (Ox)", 0, false, 5, 0, 0, 1, false, 0, 13));
                enemyStartingDeck.Add(new Card("Stampede (Ox)", 10, false, 0, 0, 0, 1, false, 100, 0));
                enemyStartingDeck.Add(new Card("Stomp (Ox)", 3, false, 9, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 23:
                //Lion 
                enemyStartingDeck.Add(new Card("Roar (Lion)", 0, false, 3, 0, 0, 2, false, 0, 0));
                enemyStartingDeck.Add(new Card("Crunch (Lion)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Pounce (Lion)", 5, false, 6, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Tear Apart (Lion)", 8, false, 0, 0, 0, 0, false, 0, 0));
                return enemyStartingDeck;
            case 24:
                //Grizzly Bear 
                enemyStartingDeck.Add(new Card("Maul (Bear)", 8, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Bite (Bear)", 7, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Chase Down (Bear)", 0, false, 5, 0, 0, 1, false, 0, 15));
                enemyStartingDeck.Add(new Card("Knock Down (Bear)", 6, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 25:
            //Elephant
                enemyStartingDeck.Add(new Card("Tusk Spear (Elephant)", 10, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Stomp (Elephant)", 3, false, 8, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Throw Weight (Elephant)", 0, false, 0, 0, 0, 1, false, 0, 12));
                enemyStartingDeck.Add(new Card("Trunk Slam (Elephant)", 2, false, 10, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;

            case 26:
            //Dragon
                enemyStartingDeck.Add(new Card("Ascent (Dragon)", 10, false, 0, 0, 0, 1, true, 0, 0));
                enemyStartingDeck.Add(new Card("Tail Strike (Dragon)", 13, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Gather Energy (Dragon)", 0, false, 10, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Zodiac Blast (Dragon)", 4, false, 4, 4, 0, 1, false, 0, 3));
                return enemyStartingDeck;

            case 27:
            //Snake
                enemyStartingDeck.Add(new Card("Envenom (Snake)", 0, false, 0, 0, 0, 1, false, 0, 3));
                enemyStartingDeck.Add(new Card("Wrap (Snake)", 7, false, 7, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Bite (Snake)", 9, false, 0, 0, 0, 1, false, 0, 0));
                enemyStartingDeck.Add(new Card("Spit Poison (Snake)", 0, false, 0, 0, 0, 1, false, 0, 14));
                return enemyStartingDeck;

            //Tutorial Enemies
            case 28:
                // Ant Enemy
                //Pincer Card
                enemyStartingDeck.Add(new Card("Pincer (Ant)", 9, false, 0, 0, 0, 1, false, 0, 0));
                //Curl Up Card
                enemyStartingDeck.Add(new Card("Curl Up (Ant)", 0, false, 0, 0, 0, 1, false, 50, 0));
                //Team Attack Card
                enemyStartingDeck.Add(new Card("Team Attack (Ant)", 8, false, 0, 0, 0, 1, false, 0, 0));
                //Exoskeleton
                enemyStartingDeck.Add(new Card("Exoskeleton (Ant)", 0, false, 0, 7, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 29:
                //Pigeon Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck (Pigeon)", 7, false, 0, 0, 0, 1, false, 0, 0));
                //Home In Card (unfinished) 
                enemyStartingDeck.Add(new Card("Home In (Pigeon)", 6, false, 0, 0, 0, 1, true, 0, 0));
                //Roost Card 
                enemyStartingDeck.Add(new Card("Roost (Pigeon)", 0, false, 0, 0, 6, 1, false, 0, 0));
                //Wing Defence Card 
                enemyStartingDeck.Add(new Card("Wing Defence (Pigeon)", 0, false, 0, 7, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            case 30:
                //Rooster Enemy
                //Peck Card
                enemyStartingDeck.Add(new Card("Peck (Rooster)", 13, false, 0, 0, 0, 1, false, 0, 0));
                //Intimidate Card (unfinished)
                enemyStartingDeck.Add(new Card("Intimidate (Rooster)", 0, false, 0, 10, 0, 1, false, 0, 0));
                //Feather Dance Card 
                enemyStartingDeck.Add(new Card("Feather Dance (Rooster)", 6, false, 0, 0, 6, 1, false, 0, 0));
                //Flock Attack Card (unfinished)
                enemyStartingDeck.Add(new Card("Flock Attack (Rooster)", 15, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
            default:
                //In case of case failure
                //Punch Card
                enemyStartingDeck.Add(new Card("Punch", 5, false, 0, 0, 0, 1, false, 0, 0));
                //Punch Card 
                enemyStartingDeck.Add(new Card("Punch", 7, false, 0, 0, 0, 1, false, 0, 0));
                //Kick Card 
                enemyStartingDeck.Add(new Card("Kick", 8, false, 0, 0, 0, 1, false, 0, 0));
                //Kick Card 
                enemyStartingDeck.Add(new Card("Kick", 15, false, 0, 0, 0, 1, false, 0, 0));
                return enemyStartingDeck;
        }
    }
}
