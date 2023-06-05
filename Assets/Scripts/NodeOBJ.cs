using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeOBJ : MonoBehaviour {
    public Node node;
    private Vector3 normalScale;
    [SerializeField] private Transform GFX;
    [SerializeField] private Animator animator;
    public Enemies enemies;
    public Enemy enemy;
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
        int randomNumber;
        //If the Start Node is null then Load battle screen and set Start Node
        if (GameController.PlayerStartNode != null)
        {
            if (GameController.PlayerStartNode.IsConnected(node) == true)
            {
                //if node battle diffculty is 0, then laod rest stop 
                if(node.battleStrength == 0)
                {
                    loadRestStop();
                }
                //if node battle difficulty is 1, then load easy battle (Will be changed)
                if(node.battleStrength == 1)
                {
                    loadBattleScene();
                }
                //if node battle difficulty is 1, then load hard battle (Will be changed)
                if(node.battleStrength == 2)
                {
                    //loadBattleScene();
                }
                //if node battle difficulty is 1, then load boss battle (Will be changed)
                if(node.battleStrength == 3)
                {
                    //loadBattleScene();
                }
            }
        }
        else
        {
            //Player can only select first row on their first go
            if(node.backwardConnections.Count == 0){
                loadBattleScene();
            }
            
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
        SceneManager.LoadScene("RestStop");
        GameController.PlayerStartColumn = node.column;
        GameController.PlayerStartNode = node;
        GameController.PlayerMapPos.Add(node.id);
    }
}
