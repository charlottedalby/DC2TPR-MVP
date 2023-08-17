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

    public List<int> Event1;
    public List<int> Event2;
    public List<int> Event3;
    public List<int> Event4;
    public List<int> Event5;
    public List<int> Event6;
    public List<int> Event7;
    public List<int> Event8;
    public List<int> Event9;

    public Image InnPage;
    public Image AmbushFlee;
    public Image PotionMaster;
    public Image BossBattle;
    public Image MerchantPage;
    public Image AmbushFight;
    public Image ClericPage;
    public Image ScoutPage;
    public Image CardTheif;
    public Image RoosterImage;
    public Image MonkeyImage;
    public Image TigerImage;
    public Image DragonImage;

    public HealthBar healthBar;
    public Text playerHealthText;
    public Menu menu;
    public int chance;

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

    public void Start()
    {
        
        GameObject menuObject = GameObject.Find("Canvas");
        menu = menuObject.GetComponent<Menu>();
        playerHealthText.text = GameController.PlayerStartHealth.ToString();
        healthBar.setHealth(GameController.PlayerStartHealth);
        skip = false;
        chance = 0;
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

        InnPage = GameObject.Find("Inn Page").GetComponent<Image>();
        AmbushFlee = GameObject.Find("Ambush Flee").GetComponent<Image>();
        PotionMaster = GameObject.Find("Potion Master").GetComponent<Image>();
        BossBattle = GameObject.Find("Boss Battle").GetComponent<Image>();
        MerchantPage = GameObject.Find("Merchant Page").GetComponent<Image>();
        AmbushFight = GameObject.Find("Ambush Fight").GetComponent<Image>();
        ClericPage = GameObject.Find("Cleric Page").GetComponent<Image>();
        ScoutPage = GameObject.Find("Scope Page").GetComponent<Image>();
        CardTheif = GameObject.Find("Card Thief").GetComponent<Image>();
        
        
        RoosterImage = GameObject.Find("Rooster").GetComponent<Image>();
        MonkeyImage = GameObject.Find("Monkey").GetComponent<Image>();
        TigerImage = GameObject.Find("Tiger").GetComponent<Image>();
        DragonImage = GameObject.Find("Dragon").GetComponent<Image>();
        setAllFalse();

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
            menu.loadOverworld();
        }

        else if(EventNumber == 1)
        {
            int health = GameController.PlayerStartHealth;
            float newHealth = health * 0.95f;
            GameController.PlayerStartHealth = (int)Math.Round(newHealth);
            menu.loadOverworld();
        }

        else if(EventNumber == 2)
        {
            chance = UnityEngine.Random.Range(1, 3);
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
                menu.loadOverworld();
            }
            else
            {
                GameController.PlayerStartHealth -= 10;

                if(GameController.PlayerStartHealth <= 0)
                {
                    menu.loadGameOver();
                }
                menu.loadOverworld();
            }
        }

        else if (EventNumber == 3)
        {
            bossEnemy = enemies.selectEnemy(3, GameController.stage);
            GameController.enemyStartingDeck = bossEnemy.enemyCards;
            menu.loadCardSteal();
        }

        else if(EventNumber == 4)
        {
            chance = UnityEngine.Random.Range(1,3);
            
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
            menu.loadCardSteal();
        }

        else if (EventNumber == 5)
        {
            int health = GameController.PlayerStartHealth;
            float newHealth = health * 0.85f;
            GameController.PlayerStartHealth = (int)Math.Round(newHealth);
            
            bossEnemy = enemies.selectEnemy(1, GameController.stage);
            GameController.enemyStartingDeck = bossEnemy.enemyCards;
            menu.loadCardSteal();
        }

        else if (EventNumber == 6)
        {
            GameController.PlayerStartHealth = 100;
            menu.loadOverworld();
        }

        else if (EventNumber == 7)
        {
            int health = GameController.PlayerStartHealth;
            float newHealth = health * 0.80f;

            GameController.PlayerStartHealth = (int)Math.Round(newHealth);
            bossEnemy = enemies.selectEnemy(2, GameController.stage);
            GameController.enemyStartingDeck = bossEnemy.enemyCards;
            menu.loadCardSteal();

        }

        else if (EventNumber == 8)
        {
            int tempStage = GameController.stage;
            if (GameController.stage > 1)
            {
                GameController.stage -= 1;
            }
            GameController.PlayerStartNode.battleStrength = 3;
            menu.NextBattle();
            GameController.stage = tempStage;
        }
        else
        {
            menu.loadOverworld();
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
            Debug.Log(eventNumber);
        }
        while(!Events[eventNumber].Stages.Contains(GameController.stage));
        if (eventNumber == 0)
        {
            InnPage.color = new Color32(255, 255, 255, 255);
        }
        else if (eventNumber == 1)
        {
            AmbushFlee.color = new Color32(255, 255, 255, 255);
        }
        else if (eventNumber == 2)
        {
            PotionMaster.color = new Color32(255, 255, 255, 255);
        }
        else if (eventNumber == 3)
        {
            CardTheif.color = new Color32(255, 255, 255, 255);
        }
        else if (eventNumber == 4)
        {
            MerchantPage.color = new Color32(255, 255, 255, 255);
        }
        else if (eventNumber == 5)
        {
            AmbushFight.color = new Color32(255, 255, 255, 255);
        }
        else if (eventNumber == 6)
        {
            ClericPage.color = new Color32(255, 255, 255, 255);
        }
        else if (eventNumber == 7)
        {
            ScoutPage.color = new Color32(255, 255, 255, 255);
        }
        else if (eventNumber == 8)
        {
            Debug.Log(GameController.stage-1);
            BossBattle.color = new Color32(255, 255, 255, 255);
            if(GameController.stage == 1)
            {
                RoosterImage.color = new Color32(255, 255, 255, 255);
            }
            else if(GameController.stage == 2)
            {
                MonkeyImage.color = new Color32(255, 255, 255, 255);
            }
            else if (GameController.stage ==3)
            {
                TigerImage.color = new Color32(255, 255, 255, 255);
            }
            else
            {
                DragonImage.color = new Color32(255, 255, 255, 255);
            }
        }

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
            menu.loadOverworld();
        }
    }

    public void setAllFalse()
    {
        InnPage.color = new Color32(255, 255, 255, 0);
        AmbushFlee.color = new Color32(255, 255, 255, 0);
        PotionMaster.color = new Color32(255, 255, 255, 0);
        BossBattle.color = new Color32(255, 255, 255, 0);
        MerchantPage.color = new Color32(255, 255, 255, 0);
        AmbushFight.color = new Color32(255, 255, 255, 0);
        ClericPage.color = new Color32(255, 255, 255, 0);
        ScoutPage.color = new Color32(255, 255, 255, 0);
        CardTheif.color = new Color32(255, 255, 255, 0);
        RoosterImage.color = new Color32(255, 255, 255, 0);
        MonkeyImage.color = new Color32(255, 255, 255, 0);
        TigerImage.color = new Color32(255, 255, 255, 0);
        DragonImage.color = new Color32(255, 255, 255, 0);
    }

}
