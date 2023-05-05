using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeOBJ : MonoBehaviour {
    public Node node;
    private Vector3 normalScale;
    [SerializeField] private Transform GFX;
    [SerializeField] private Animator animator;
    //private bool canSelect = false;
    void Start()
    {
        normalScale = GFX.localScale;
        animator.enabled = false;
        animateNodes();
    }

    void OnMouseOver()
    {
        if (GameController.PlayerStartNode != null)
        {
            if (GameController.PlayerStartNode.IsConnected(node) == true)
            {
                GFX.transform.localScale = 2 * normalScale;
            }
        }
        else if(node.row == 0)
        {
            GFX.transform.localScale = 2 * normalScale;
        }
    }

    void OnMouseExit()
    {
        GFX.transform.localScale = normalScale;
    }

    void OnMouseDown()
    {
        //If the Start Node is null then Load battle screen and set Start Node
        if (GameController.PlayerStartNode != null)
        {
            if (GameController.PlayerStartNode.IsConnected(node) == true)
            {
                //Ensures Node Clicked is on the correct row the player should be on
                Debug.Log(GameController.PlayerStartColumn + " " + node.column);
                Debug.Log("PlayerStartRow is equal to node row");
                //Need a function that returns current row, then if the current row is clicked then it will be selected or animated
                //If Player Health is less than 100 (Max) then there is a chance of a rest stop 
                if (GameController.PlayerStartHealth != 100 && node.forwardConnections.Count != 0)
                {
                    //Chance is randon between 1 and 10
                    int chance = Random.Range(1,10);
                    if (chance == 1 || chance == 3)
                    {
                        //Loads Rest Stop Scene 
                        loadRestStop();
                    }
                    else
                    {
                        //Loads Battle Scene
                        loadBattleScene();
                    }
                }
                else
                {
                    loadBattleScene();
                }
            }
        }
        else
        {
            loadBattleScene();
        }
    }

    void animateNodes()
    {
        for (int i = 0; i < GameController.PlayerMapPos.Count; i++)
        {
            if (node.id == GameController.PlayerMapPos[i])
            {
                animator.enabled = true;
            }
        }
    }

    void loadBattleScene()
    {
        GameController.PlayerStartColumn = node.column;
        GameController.PlayerStartNode = node;
        GameController.PlayerMapPos.Add(node.id);
        SceneManager.LoadScene("BattleScreen");
    } 

    void loadRestStop()
    {
        GameController.PlayerStartColumn = node.column;
        GameController.PlayerStartNode = node;
        GameController.PlayerStartHealth += 5;
        GameController.PlayerMapPos.Add(node.id);
        if (GameController.PlayerStartHealth > 100)
        {
            GameController.PlayerStartHealth = 100;
        }
        SceneManager.LoadScene("RestStop");
    }
}
