using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    Class: CardStealButtons
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. Highlight1: Card highlight 1
    b. Highlight2: Card highlight 2
    c. Highlight3: Card highlight 3
    d. Highlight4: Card highlight 4

    Methods: 

    a. Start()
    b. CardClicked()
    c. SetAllFalse()

*/

public class CardStealButtons : MonoBehaviour
{
    public GameObject Highlight1;
    public GameObject Highlight2;
    public GameObject Highlight3;
    public GameObject Highlight4;

    /*
	    Method: Start()
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Finds CardHighlight in Scene for 1, 2, 3, 4
        b. Sets all Highlights to false

    */

    void Start()
    {
        Highlight1 = GameObject.Find("CardHighlight1");
        Highlight2 = GameObject.Find("CardHighlight2");
        Highlight3 = GameObject.Find("CardHighlight3");
        Highlight4 = GameObject.Find("CardHighlight4");
        SetAllFalse();
    }

    /*
	    Method: CardClicked()
        Visibility: Public  
        Output: N/A
        Purpose: 

        a. Sets all Highlights to False
        b. Creates a new highlight gameObject 
        c. Creates a new Card 
        d. Executes Case based on Index Passed through 
        e. Each Case will set respective highlight to on 
        f. Each Case will get the Card and set it to Card
        g. if highlight is not equal to null and Highlight active status is equal to false
        h. highlight active status set to true 
        i. Swapped Card variable in GameController Class equals Card 
    */

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

    /*
	    Method: SetAllFalse()
        Visibility: Public  
        Output: N/A
        Purpose: 

        a. Sets Each  Highlight to False
    */

    public void SetAllFalse()
    {
        Highlight1.SetActive(false);
        Highlight2.SetActive(false);
        Highlight3.SetActive(false);
        Highlight4.SetActive(false);
    }
}



