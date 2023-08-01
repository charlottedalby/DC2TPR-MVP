using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    Class: ArmorBar
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. CardHighlight1: Card Highlight 
    b. CardHighlight2: Card Highlight 
    c. CardHighlight3: Card Highlight 
    d. CardHighlight4: Card Highlight 
    e. CardHighlight5: Card Highlight 
    f. CardHighlight6: Card Highlight 
    g. CardHighlight7: Card Highlight 
    h. CardHighlight8: Card Highlight 
    i. CardHighlight9: Card Highlight 
    j. CardHighlight10: Card Highlight 
    k. CardHighlight11: Card Highlight 
    l. CardHighlight12: Card Highlight 
    m. cardPos: Card Position in List 
    n. cards: List of player Cards

    Methods: 

    a. setArmor()
    b. setMaxArmor()
*/

public class ReplacePlayerCard : MonoBehaviour
{
    public Image CardHighlight1;
    public Image CardHighlight2;
    public Image CardHighlight3;
    public Image CardHighlight4;
    public Image CardHighlight5;
    public Image CardHighlight6;
    public Image CardHighlight7;
    public Image CardHighlight8;
    public Image CardHighlight9;
    public Image CardHighlight10;
    public Image CardHighlight11;
    public Image CardHighlight12;
    public static int cardPos;
    public List<Card> cards = new List<Card>();
    public Menu menu;
    
    /*
        Method: Start()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Find and assign the Image component of CardHighlights
        b. Iterate through the playerStartingDeck list:
        c. Get the current card from the GameController's playerStartingDeck.
        d. Assign the properties of the current card to the corresponding properties of the cards in the cards array.
        e. Log the name of the current card.
        f. Call the assignCardUI() method on the current card.
    */

    void Start()
    {
        GameObject menuObject = GameObject.Find("Canvas");
        menu = menuObject.GetComponent<Menu>();

        CardHighlight1 = GameObject.Find("CardHighlight1").GetComponent<Image>();
        CardHighlight2 = GameObject.Find("CardHighlight1 (1)").GetComponent<Image>();
        CardHighlight3 = GameObject.Find("CardHighlight1 (2)").GetComponent<Image>();
        CardHighlight4 = GameObject.Find("CardHighlight1 (3)").GetComponent<Image>();
        CardHighlight5 = GameObject.Find("CardHighlight1 (4)").GetComponent<Image>();
        CardHighlight6 = GameObject.Find("CardHighlight1 (5)").GetComponent<Image>();
        CardHighlight7 = GameObject.Find("CardHighlight1 (6)").GetComponent<Image>();
        CardHighlight8= GameObject.Find("CardHighlight1 (7)").GetComponent<Image>();
        CardHighlight9 = GameObject.Find("CardHighlight1 (8)").GetComponent<Image>();
        CardHighlight10 = GameObject.Find("CardHighlight1 (9)").GetComponent<Image>();
        CardHighlight11 = GameObject.Find("CardHighlight1 (10)").GetComponent<Image>();
        CardHighlight12 = GameObject.Find("CardHighlight1 (11)").GetComponent<Image>();

        for(int i = 0; i < GameController.playerStartingDeck.Count; i++) 
        {
            Card currentCard = GameController.playerStartingDeck[i];
            cards[i].name = currentCard.name;
            cards[i].damage = currentCard.damage;
            cards[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            cards[i].handIndex = currentCard.handIndex;
            cards[i].armour = currentCard.armour;
            //new addition
            cards[i].healing = currentCard.healing;
            cards[i].damageMult = currentCard.damageMult;
            cards[i].ignoreArmour = currentCard.ignoreArmour;
            cards[i].hitChance = currentCard.hitChance;
            cards[i].endOfTurnValue = currentCard.endOfTurnValue;
            cards[i].assignCardUI();
        }
    }

    /*
        Method: CardClick()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Set all card highlight colors to white.
        b. Switch the cardPosition parameter:
        c. For each case, set the corresponding CardHighlight color to a specified color.
        d. If none of the cases match, return (invalid card position).
        e. Then Set the cardPos variable to the cardPosition parameter.
    */

    public void CardClick(int cardPosition)
    {
        setAllWhite();
        switch(cardPosition)
        {
            case 0:
            CardHighlight1.color = new Color32(13, 250, 19, 255);
            break;
            case 1:
                CardHighlight2.color = new Color32(13, 250, 19, 255);
                break;
            case 2:
                CardHighlight3.color = new Color32(13, 250, 19, 255);
                break;
            case 3:
                CardHighlight4.color = new Color32(13, 250, 19, 255);
                break;
            case 4:
                CardHighlight5.color = new Color32(13, 250, 19, 255);
                break;
            case 5:
                CardHighlight6.color = new Color32(13, 250, 19, 255);
                break;
            case 6:
                CardHighlight7.color = new Color32(13, 250, 19, 255);
                break;
            case 7:
                CardHighlight8.color = new Color32(13, 250, 19, 255);
                break;
            case 8:
                CardHighlight9.color = new Color32(13, 250, 19, 255);
                break;
            case 9:
                CardHighlight10.color = new Color32(13, 250, 19, 255);
                break;
            case 10:
                CardHighlight11.color = new Color32(13, 250, 19, 255);
                break;
            case 11:
                CardHighlight12.color = new Color32(13, 250, 19, 255);
                break;
            default:
                return;
        }
        cardPos = cardPosition;
    }

    /*
        Method: setAllWhite()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Set all CardHighlight colors to white.
    */

    public void setAllWhite()
    {
        CardHighlight1.color = new Color32(255,255,255,255);
        CardHighlight2.color = new Color32(255,255,255,255);
        CardHighlight3.color = new Color32(255,255,255,255);
        CardHighlight4.color = new Color32(255,255,255,255);
        CardHighlight5.color = new Color32(255,255,255,255);
        CardHighlight6.color = new Color32(255,255,255,255);
        CardHighlight7.color = new Color32(255,255,255,255);
        CardHighlight8.color = new Color32(255,255,255,255);
        CardHighlight9.color = new Color32(255,255,255,255);
        CardHighlight10.color = new Color32(255,255,255,255);
        CardHighlight11.color = new Color32(255,255,255,255);
        CardHighlight12.color = new Color32(255,255,255,255);
    }

    /*
        Method: confirmClick()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. If cardPos is not null:
        b. Replace the card at the cardPos index in the playerStartingDeck with the swapped card.
        c. Load the "OverworldScreen" scene.
    */

    public void confirmClick()
    {
        if(cardPos != null)
        {
            GameController.playerStartingDeck[cardPos] = GameController.SwappedCard;
            menu.loadOverworld();
        }
    }

    /*
        Method: cancelClick
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Load the "OverworldScreen" scene.
    */

    public void cancelClick()
    {
        menu.loadOverworld();
    }
}
