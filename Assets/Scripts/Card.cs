using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int damage;
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gameManager;
    public Player player;
    public static Card Instance;
    public GameObject PLAYER;
    public int armour;
    // new addition
    public int healing;
    public int damageMult;
    public string name;

    public void Awake(){
        if (Instance == null) {
            //First run, set the instance
            Instance = this;
            DontDestroyOnLoad(gameObject);
 
        } else if (Instance != this) {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            //Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void Start()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        assignCardUI();
        
    }

    public Card (string name, int damage, bool hasBeenPlayed, int handIndex, int armour, int healing, int damageMult)
    {
        this.name = name;
        this.damage = damage;
        this.hasBeenPlayed = hasBeenPlayed;
        this.handIndex = handIndex;
        this.armour = armour;
        //new addition
        this.healing = healing;
        this.damageMult = damageMult;
    }

    void OnMouseDown(){
        //If the Card has been clicked on and hasn't been played yet
        //If the View Card Scene is not active
        if(hasBeenPlayed == false){
        //Attack the enemy
        gameManager.player.attackEnemy(damage);
        //New addition, raise player's armour
        gameManager.player.raiseArmor(armour);
        //New addition, heal player's health
        gameManager.player.healPlayer(healing);
        //New addition, changes damage multiplier
        gameManager.player.powerUp(damageMult);
        

        //Move the card up so we can see that it has been played
        transform.position += Vector3.up * 5;
        Cursor.lockState = CursorLockMode.Locked;
        //Set hasBeenPlayed to true
        hasBeenPlayed = true;
        //Make the slot the card was in available again
        gameManager.player.availableCardSlots[handIndex] = true;
        //Move the card to the discardPile
        gameManager.player.Invoke("discardHand", 2f);
        //Invoke("MoveToDiscardPile", 2f);
        gameManager.enemy.Invoke("attackPlayer", 2f);
        }
    }

    public void MoveToDiscardPile()
    {
        if (gameManager.player.discardPile.Count < 12){
            //Fix for the nullReference errors
            if (gameManager == null) {
                this.gameManager = FindObjectOfType<GameManager>();
            }
            //Add the Card to the discardPile and set the card to inactive
            gameManager.player.discardPile.Add(this);
            //gameObject.SetActive(false);
            //Invoke the enemy to attack the player
            gameManager.enemy.Invoke("attackPlayer", 2f);
        }
    }

    public void assignCardUI()
    {
        GameObject[] cards;
        cards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject card in cards)
        {
            Card currentCard = card.GetComponent<Card>();
            Debug.Log(currentCard.name);
            if(currentCard.name != null)
            {
                if (currentCard.name == "Punch")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Punch").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Kick")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Kick").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Jump Kick")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Jump Kick").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Throw")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Throw").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Grapple")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Grapple").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Meditate")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Meditate").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Clamp Down")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Clamp Down").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Scurry")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Scurry").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Tail Strike")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Tail Strike").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Peck")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Peck").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Home In")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Home In").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Roost")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Roost").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Wing Defence")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Wing Defence").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Rear Kick")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Rear Kick").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Run Away")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Run Away").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Keen Sense")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Keen Sense").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Intimidate")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Intimidate").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Feather Dance")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Feather Dance").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Flock Attack")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Flock Attack").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Hound")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Hound").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Bite")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Bite").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Pounce")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Pounce").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Bare Teeth")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Bare Teeth").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Camouflage")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Camouflage").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Tail Lash")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Tail Lash").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Shed Tail")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Shed Tail").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Use Tools")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Use Tools").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Gouge")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Gouge").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Swing High")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Swing High").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Pummel")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Pummel").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Thick Skin")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Thick Skin").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Trample")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Trample").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Roll Around")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Roll Around").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Sniff Out")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Sniff Out").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Clamp")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Clamp").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Exoskeleton")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Exoskeleton").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Envenom")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Envenom").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Spin Web")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Spin Web").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Fang Strike")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Fang Strike").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Pin down")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Pin down").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Snap")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Snap").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Slow Start")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Slow Start").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Shell Attack")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Shell Attack").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Shell Armour")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Shell Armour").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Pincer")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Pincer").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Team Attack")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Team Attack").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Curl Up")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Curl Up").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Attempt Flight")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Attempt Flight").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }

                else if (currentCard.name == "Scramble")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Scramble").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
                else if (currentCard.name == "Gnaw")
                {
                    Image cardImage = currentCard.GetComponent<Image>();
                    Sprite newSprite = GameObject.Find("Gnaw").GetComponent<Image>().sprite;
                    cardImage.sprite = newSprite;
                }
            }
            
        }
    }
}
