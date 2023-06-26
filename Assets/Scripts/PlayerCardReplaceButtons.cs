using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;

public class PlayerCardReplaceButtons : MonoBehaviour
{
    public int cardPos;
    public GameObject Highlight1;
    public GameObject Highlight2;
    public GameObject Highlight3;
    public GameObject Highlight4;
    public GameObject Highlight5;
    public GameObject Highlight6;
    public GameObject Highlight7;
    public GameObject Highlight8;
    public GameObject Highlight9;
    public GameObject Highlight10;
    public GameObject Highlight11;
    public GameObject Highlight12;

    // Start is called before the first frame update
    void Start()
    {
        cardPos = 0;
        Highlight1 = GameObject.Find("CardHighlight1");
        Highlight2 = GameObject.Find("CardHighlight1 (1)");
        Highlight3 = GameObject.Find("CardHighlight1 (2)");
        Highlight4 = GameObject.Find("CardHighlight1 (3)");
        Highlight5 = GameObject.Find("CardHighlight1 (4)");
        Highlight6 = GameObject.Find("CardHighlight1 (5)");
        Highlight7 = GameObject.Find("CardHighlight1 (6)");
        Highlight8 = GameObject.Find("CardHighlight1 (7)");
        Highlight9 = GameObject.Find("CardHighlight1 (8)");
        Highlight10 = GameObject.Find("CardHighlight1 (9)");
        Highlight11 = GameObject.Find("CardHighlight1 (10)");
        Highlight12 = GameObject.Find("CardHighlight1 (11)");
        SetAllFalse();
    }

    public void SetAllFalse()
    {
        Highlight1.SetActive(false);
        Highlight2.SetActive(false);
        Highlight3.SetActive(false);
        Highlight4.SetActive(false);
        Highlight5.SetActive(false);
        Highlight6.SetActive(false);
        Highlight7.SetActive(false);
        Highlight8.SetActive(false);
        Highlight9.SetActive(false);
        Highlight10.SetActive(false);
        Highlight11.SetActive(false);
        Highlight12.SetActive(false);
    }
    
    public void firstclick()
    {
        SetAllFalse();
        if(Highlight1.activeSelf == false)
        {
            Highlight1.SetActive(true);
            cardPos = 0;
        }
    }

    public void Secondclick()
    {
        SetAllFalse();
        if(Highlight2.activeSelf == false)
        {
            Highlight2.SetActive(true);
            cardPos = 1;
        }
    }
/*
    public void Thirdclick()
    {
        SetAllFalse();
        if(Highlight3.activeSelf == false)
        {
            Highlight3.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[2] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }

    public void Fourthclick()
    {
        SetAllFalse();
        if(Highlight4.activeSelf == false)
        {
            Highlight4.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[3] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }

    public void fifthclick()
    {
        SetAllFalse();
        if(Highlight5.activeSelf == false)
        {
            Highlight5.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[4] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }

    public void Sixclick()
    {
        SetAllFalse();
        if(Highlight6.activeSelf == false)
        {
            Highlight6.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[5] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }

    public void Sevenclick()
    {
        SetAllFalse();
        if(Highlight7.activeSelf == false)
        {
            Highlight7.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[6] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }
    public void Eightclick()
    {
        SetAllFalse();
        if(Highlight8.activeSelf == false)
        {
            Highlight8.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[7] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }

    public void Nineclick()
    {
        SetAllFalse();
        if(Highlight9.activeSelf == false)
        {
            Highlight9.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[8] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }

    public void Tenclick()
    {
        SetAllFalse();
        if(Highlight10.activeSelf == false)
        {
            Highlight10.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[9] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }

    public void Elevenclick()
    {
        SetAllFalse();
        if(Highlight11.activeSelf == false)
        {
            Highlight11.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[10] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }

    public void Twelveclick()
    {
        SetAllFalse();
        if(Highlight12.activeSelf == false)
        {
            Highlight12.SetActive(true);
            Thread.Sleep(1000);
            GameController.playerStartingDeck[11] = GameController.SwappedCard;
            ConfirmUI.SetActive(true);
        }
    }
*/
    public void confirmClick()
    {
        if(cardPos != null)
        {
            GameController.playerStartingDeck[cardPos] = GameController.SwappedCard;
            SceneManager.LoadScene("OverworldScreen");
        }
    }
}
