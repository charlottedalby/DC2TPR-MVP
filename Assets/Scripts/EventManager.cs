using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    Class: EventManager
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. Events: List of events for Game
    b. bossEnemy: Instance of Enemy
    c. enemies: Instance of Enemies 
    d. eventText: UI Event Text showcasing the event taking place
    e. skip: boolean operator deciding if a user can skip the event 
    f. eventNumber: The number identifier of the event happening

    Methods: 

    a. Start()
    b. generateEvents()
    c. runEvents()
    d. displayEvent()
    e. proceedToEvent()
    f. skipEvent()

*/

public class EventManager : MonoBehaviour
{
    public List <Event> Events = new List <Event>();
    public Enemy bossEnemy;
    public Enemies enemies;
    public Text eventText;
    public bool skip;
    int eventNumber;

    List<int> Event1;
    List<int> Event2;
    List<int> Event3;
    List<int> Event4;
    List<int> Event5;
    List<int> Event6;
    List<int> Event7;
    List<int> Event8;
    List<int> Event9;

    /*
        Method: Start()
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Sets Skip to false
        b. Generates All Events for Game
        c. Creates each event Stages list: A list that shows which event can appear in which stage 
        d. Createa a new Instance of Enemies 
        e. Runs the displayEvent() function which returns int
    */

    void Start()
    {
        skip = false;
        generateEvents();
        Events[0].Stages = Event1 = new List<int> {1, 3, 4};
        Events[1].Stages = Event2 = new List<int> {2, 3, 4};
        Events[2].Stages = Event3 = new List<int> {1, 3, 4};
        Events[3].Stages = Event4 = new List<int> {1, 3};
        Events[4].Stages = Event5 = new List<int> {1, 2};
        Events[5].Stages = Event6 = new List<int> {1, 2, 4};
        Events[6].Stages = Event7 = new List<int> {2, 3, 4};
        Events[7].Stages = Event8 = new List<int> {1, 2, 4};
        Events[8].Stages = Event9 = new List<int> {2, 3, 4};
        
        enemies = new Enemies();
        eventNumber = displayEvent();
    }

    /*
        Method: generateEvents()
        Visibility: public 
        Output: N/A
        Purpose: 

        a. Creates each event, each one is based off events outlined in Events document
    */

    public void generateEvents()
    {
        Events.Add(new Event(0, "Inn - Heal 20% of missing health", Event1, false));
        
        Events.Add(new Event(1, "Ambush - Take 5% of current Health", Event2, false));

        Events.Add(new Event(2, "Potion Master - Either Heal 10 Health or Take 10 Damage", Event3, false));

        Events.Add(new Event(3, "Merchant Boss - Swap Card out for a card from the boss stage", Event4, false));

        Events.Add(new Event(4, "Merchant Lucky Dip  - Swap of enemy worst card or best card of enemy", Event5, false));

        Events.Add(new Event(5, "Ambush - Take 15% current health damage but steal a card (Easy Enemy)", Event6, false));

        Events.Add(new Event(6, "Cleric - Full Heal", Event7, false));

        Events.Add(new Event(7, "Scout – Skip or reduce health by 20% and take a Hard Enemy Card ", Event8, true));

        Events.Add(new Event(8, "Boss Battle Fight Boss from previous stage", Event9, false));

    }

    /*
        Method: runEvents()
        Visibility: public 
        Output: N/A
        Purpose: 

        a. This completes a process based on what event was run. 
        b. See Event document for details
    */

    public void runEvents(int EventNumber)
    {
        
        if(EventNumber == 0)
        {
            int health = GameController.PlayerStartHealth;
            float newHealth = health * 1.2f;

            if(newHealth > 100.0f)
            {
                newHealth = 100.0f;
            }

            GameController.PlayerStartHealth = (int)Math.Round(newHealth);
            SceneManager.LoadScene("OverworldScreen");
        }

        else if(EventNumber == 1)
        {
            int health = GameController.PlayerStartHealth;
            float newHealth = health * 0.95f;

            if(newHealth <= 0.0f)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                GameController.PlayerStartHealth = (int)Math.Round(newHealth);
                SceneManager.LoadScene("OverworldScreen");
            }
        }

        else if(EventNumber == 2)
        {
            int chance = UnityEngine.Random.Range(1, 2);

            if (chance == 1)
            {
                if(GameController.PlayerStartHealth > 90)
                {
                    GameController.PlayerStartHealth = 100;
                }
                else
                {
                    GameController.PlayerStartHealth += 10;
                }
                SceneManager.LoadScene("OverworldScreen");
            }
            else
            {
                GameController.PlayerStartHealth -= 10;

                if(GameController.PlayerStartHealth <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                SceneManager.LoadScene("OverworldScreen");
            }
        }

        else if (EventNumber == 3)
        {
            bossEnemy = enemies.selectEnemy(3, GameController.stage);
            GameController.enemyStartingDeck = bossEnemy.enemyCards;
            SceneManager.LoadScene("CardStealing");
        }

        else if(EventNumber == 4)
        {
            int chance = UnityEngine.Random.Range(1,2);
            
            if(chance == 1)
            {
                bossEnemy = enemies.selectEnemy(1, GameController.stage);
                GameController.enemyStartingDeck = bossEnemy.enemyCards;
            }

            else 
            {
                bossEnemy = enemies.selectEnemy(2, GameController.stage);
                GameController.enemyStartingDeck = bossEnemy.enemyCards;
            }
            SceneManager.LoadScene("CardStealing");
        }

        else if (EventNumber == 5)
        {
            int health = GameController.PlayerStartHealth;
            float newHealth = health * 0.85f;

            if(newHealth <= 0.0f)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                GameController.PlayerStartHealth = (int)Math.Round(newHealth);
            }
            bossEnemy = enemies.selectEnemy(1, GameController.stage);
            GameController.enemyStartingDeck = bossEnemy.enemyCards;
            SceneManager.LoadScene("CardStealing");
        }

        else if (EventNumber == 6)
        {
            GameController.PlayerStartHealth = 100;
            SceneManager.LoadScene("OverworldScreen");
        }

        else if (EventNumber == 7)
        {
            int health = GameController.PlayerStartHealth;
            float newHealth = health * 0.80f;

            if(newHealth <= 0.0f)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                GameController.PlayerStartHealth = (int)Math.Round(newHealth);
            }
            bossEnemy = enemies.selectEnemy(2, GameController.stage);
            GameController.enemyStartingDeck = bossEnemy.enemyCards;
            SceneManager.LoadScene("CardStealing");
        }

        else if (EventNumber == 8)
        {
            GameController.PlayerStartNode.battleStrength = 3;
            SceneManager.LoadScene("BattleScreen");
        }
    }

    /*
        Method: displayEvent()
        Visibility: public 
        Output: int: eventNumber, which will signify what event will be run 
        Purpose: 

        a. Generates a Random Number while Event chosen is not eligible for this stage
        b. Once an eligible event is found 
        c. eventText is set to that event description 
        d. if event number is 7, the player is able to skip 
        e. eventNumber is then returned 
    */

    public int displayEvent()
    {
        int eventNumber = 0;
        do
        {
            eventNumber = UnityEngine.Random.Range(0,Events.Count);
        }
        while(!Events[eventNumber].Stages.Contains(GameController.stage));
        
        eventText.text = Events[eventNumber].Description;
        if(Events[eventNumber].Skipable == true)
        {
            skip = true;
        }
        return eventNumber;
    }

    /*
        Method: proceedToEvent()
        Visibility: public 
        Output: n/a
        Purpose: 

        a. Runs the runEvents proceedure with eventNumber passed through it 
    */

    public void proceedToEvent()
    {
        runEvents(eventNumber);
    }

    /*
        Method: skipEvent()
        Visibility: public 
        Output: n/a
        Purpose: 

        a. if the boolean operator skip is true then...
        b. Loads Overworld Scene and proceeds with the game
    */

    public void skipEvent()
    {
        if(skip == true)
        {
            SceneManager.LoadScene("OverworldScreen");
        }
    }

}
