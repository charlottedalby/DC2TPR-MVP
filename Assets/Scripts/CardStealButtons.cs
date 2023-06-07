using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardStealButtons : MonoBehaviour
{
    public GameObject Highlight1;
    public GameObject Highlight2;
    public GameObject Highlight3;
    public GameObject Highlight4;
    public static Card card;

    void Start()
    {
        Highlight1 = GameObject.Find("CardHighlight1");
        Highlight2 = GameObject.Find("CardHighlight2");
        Highlight3 = GameObject.Find("CardHighlight3");
        Highlight4 = GameObject.Find("CardHighlight4");
        card = null;
        SetAllFalse();
    }

    public void FirstClicked()
    {
        SetAllFalse();
        if(Highlight1.activeSelf == false)
        {
            Highlight1.SetActive(true);
            card = GameController.enemyStartingDeck[0];
            GameController.SwappedCard = card;
        }
    }

    public void SecondClicked()
    {
        SetAllFalse();
        if(Highlight2.activeSelf == false)
        {
            Highlight2.SetActive(true);
            card = GameController.enemyStartingDeck[1];
            GameController.SwappedCard = card;
            
        }
    }

    public void ThirdClicked()
    {
        SetAllFalse();
        if(Highlight3.activeSelf == false)
        {
            Highlight3.SetActive(true);
            card = GameController.enemyStartingDeck[2];
            GameController.SwappedCard = card;
            
        }
    }

    public void FourthClicked()
    {
        SetAllFalse();
        if(Highlight4.activeSelf == false)
        {
            Highlight4.SetActive(true);
            card = GameController.enemyStartingDeck[3];
            GameController.SwappedCard = card;
            
        }
    }

    public void SetAllFalse()
    {
        Highlight1.SetActive(false);
        Highlight2.SetActive(false);
        Highlight3.SetActive(false);
        Highlight4.SetActive(false);
    }

    public Card getCard()
    {
        return card;
    }
}



