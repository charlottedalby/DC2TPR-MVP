using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    
    void Start()
    {
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
            Debug.Log(currentCard);
            cards[i] = currentCard;
            cards[i].name = currentCard.name;
            cards[i].damage = currentCard.damage;
            cards[i].hasBeenPlayed = currentCard.hasBeenPlayed;
            cards[i].handIndex = currentCard.handIndex;
            cards[i].armour = currentCard.armour;
            //new addition
            cards[i].healing = currentCard.healing;
            cards[i].damageMult = currentCard.damageMult;
            cards[i].assignCardUI();
        }
    }

    public void firstClick()
    {
        setAllWhite();
        CardHighlight1.color = new Color32(13,250,19,255);
        cardPos = 0; 
    }
    public void SecondClick()
    {
        setAllWhite();
        CardHighlight2.color = new Color32(13,250,19,255);
        cardPos = 1; 
    }
    public void thirdClick()
    {
        setAllWhite();
        CardHighlight3.color = new Color32(13,250,19,255);
        cardPos = 2; 
    }
    public void fourthClick()
    {
        setAllWhite();
        CardHighlight4.color = new Color32(13,250,19,255);
        cardPos = 3; 
    }
    public void fifthClick()
    {
        setAllWhite();
        CardHighlight5.color = new Color32(13,250,19,255);
        cardPos = 4; 
    }
    public void sixthClick()
    {
        setAllWhite();
        CardHighlight6.color = new Color32(13,250,19,255);
        cardPos = 5; 
    }
    public void seventhClick()
    {
        setAllWhite();
        CardHighlight7.color = new Color32(13,250,19,255);
        cardPos = 6; 
    }
    public void eighthClick()
    {
        setAllWhite();
        CardHighlight8.color = new Color32(13,250,19,255);
        cardPos = 7; 
    }
    public void ninthClick()
    {
        setAllWhite();
        CardHighlight9.color = new Color32(13,250,19,255);
        cardPos = 8; 
    }
    public void tenthClick()
    {
        setAllWhite();
        CardHighlight10.color = new Color32(13,250,19,255);
        cardPos = 9; 
    }
    public void eleventhClick()
    {
        setAllWhite();
        CardHighlight11.color = new Color32(13,250,19,255);
        cardPos = 10; 
    }
    public void twelvthClick()
    {
        setAllWhite();
        CardHighlight12.color = new Color32(13,250,19,255);
        cardPos = 11; 
    }


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

    public void confirmClick()
    {
        if(cardPos != null)
        {
            GameController.playerStartingDeck[cardPos] = GameController.SwappedCard;
            SceneManager.LoadScene("OverworldScreen");
        }
    }

    public void cancelClick()
    {
        SceneManager.LoadScene("OverworldScreen");
    }
}
