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
    public Image card1;
    public Image card2;
    public Image card3;
    public Image card4;
    public Image card5;
    public Image card6;
    public Image card7;
    public Image card8;
    public Image card9;
    public Image card10;
    public Image card11;
    public Image card12;
    public static int cardPos;
    
    public Image changeCard;
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
        card1 = GameObject.Find("PlayerCard").GetComponent<Image>();
        card2 = GameObject.Find("PlayerCard (1)").GetComponent<Image>();
        card3 = GameObject.Find("PlayerCard (2)").GetComponent<Image>();
        card4 = GameObject.Find("PlayerCard (3)").GetComponent<Image>();
        card5 = GameObject.Find("PlayerCard (4)").GetComponent<Image>();
        card6 = GameObject.Find("PlayerCard (5)").GetComponent<Image>();
        card7 = GameObject.Find("PlayerCard (6)").GetComponent<Image>();
        card8 = GameObject.Find("PlayerCard (7)").GetComponent<Image>();
        card9 = GameObject.Find("PlayerCard (8)").GetComponent<Image>();
        card10 = GameObject.Find("PlayerCard (9)").GetComponent<Image>();
        card11 = GameObject.Find("PlayerCard (10)").GetComponent<Image>();
        card12 = GameObject.Find("PlayerCard (11)").GetComponent<Image>();
        

    }

    public void firstClick()
    {
        setAllWhite();
        CardHighlight1.color = new Color32(13,250,19,255);
        cardPos = 0;
        changeCard = card1;
    }
    public void SecondClick()
    {
        setAllWhite();
        CardHighlight2.color = new Color32(13,250,19,255);
        cardPos = 1; 
        changeCard = card2;
    }
    public void thirdClick()
    {
        setAllWhite();
        CardHighlight3.color = new Color32(13,250,19,255);
        cardPos = 2;
        changeCard = card3;

    }
    public void fourthClick()
    {
        setAllWhite();
        CardHighlight4.color = new Color32(13,250,19,255);
        cardPos = 3; 
        changeCard = card4;
    }
    public void fifthClick()
    {
        setAllWhite();
        CardHighlight5.color = new Color32(13,250,19,255);
        cardPos = 4; 
        changeCard = card5;
    }
    public void sixthClick()
    {
        setAllWhite();
        CardHighlight6.color = new Color32(13,250,19,255);
        cardPos = 5; 
        changeCard = card6;
    }
    public void seventhClick()
    {
        setAllWhite();
        CardHighlight7.color = new Color32(13,250,19,255);
        cardPos = 6;
        changeCard = card7; 
    }
    public void eighthClick()
    {
        setAllWhite();
        CardHighlight8.color = new Color32(13,250,19,255);
        cardPos = 7;
        changeCard = card8; 
    }
    public void ninthClick()
    {
        setAllWhite();
        CardHighlight9.color = new Color32(13,250,19,255);
        cardPos = 8;
        changeCard = card9; 
    }
    public void tenthClick()
    {
        setAllWhite();
        CardHighlight10.color = new Color32(13,250,19,255);
        cardPos = 9;
        changeCard = card10; 
    }
    public void eleventhClick()
    {
        setAllWhite();
        CardHighlight11.color = new Color32(13,250,19,255);
        cardPos = 10;
        changeCard = card11; 
    }
    public void twelvthClick()
    {
        setAllWhite();
        CardHighlight12.color = new Color32(13,250,19,255);
        cardPos = 11;
        changeCard = card12; 
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
            changeCard = GameController.cardImage;
            SceneManager.LoadScene("OverworldScreen");
        }
    }

    public void cancelClick()
    {
        SceneManager.LoadScene("OverworldScreen");
    }
}
