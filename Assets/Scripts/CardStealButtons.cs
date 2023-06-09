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

    public void CardClicked(int index)
    {
        SetAllFalse();
        GameObject highlight = null;
        Card card = null;

        switch(index)
        {
            case 0:
                highlight = Highlight1;
                card = GameController.enemyStartingDeck[0];
                break;
            case 1:
                highlight = Highlight2;
                card = GameController.enemyStartingDeck[1];
                break;
            case 2:
                highlight = Highlight3;
                card = GameController.enemyStartingDeck[2];
                break;
            case 3:
                highlight = Highlight4;
                card = GameController.enemyStartingDeck[3];
                break;
        }

        if(highlight != null && highlight.activeSelf == false)
        {
            highlight.SetActive(true);
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



