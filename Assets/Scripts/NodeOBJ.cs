using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Class: Menu 
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. node: node in the Overworld Map
    b. normalScale Vector 
    c. GFX: nodes Transform
    d. animator: animation for nodes
    e. enemies: Instance of Enemies 
    f. enemy: Instance of Enemy 

    Methods: 

    a. Start()
    b. OnMouseOver()
    c. OnMouseExit()
    d. OnMouseDown()
    e. animateNodes()
    f. deanimateNodes()
    g. loadBattleScene()
    h. loadRestStop()
*/

public class NodeOBJ : MonoBehaviour {
    
    public Node node;
    private Vector3 normalScale;
    [SerializeField] private Transform GFX;
    [SerializeField] private Animator animator;
    public Enemies enemies;
    public Enemy enemy;
    
    /*
        Method: Start()
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Set the initial value of the normalScale variable to the local scale of the GFX object.
        b. Disable the animator component.
        c. Call the animateNodes() method to initiate node animation.
        d. If the enemies variable is null
        e. Assign the Enemies component from the current GameObject to the enemies variable.
    */

    void Start()
    {
        normalScale = GFX.localScale;
        animator.enabled = false;
        animateNodes();

        if (enemies == null)
        {
            enemies = GetComponent<Enemies>();
        }
    }

    /*
        Method: OnMouseOver()
        Visibility: Private
        Output: N/A
        Purpose: 

        a. If the GameController's PlayerStartNode is not null:
        b. Check if the current node is connected to the PlayerStartNode.
        c. If it is connected, scale up the GFX object by multiplying its normalScale by 2.
        d. If the GameController's PlayerStartNode is null and the current node is in the first row:
        e. Scale up the GFX object by multiplying its normalScale by 2.
    */

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

    /*
        Method: OnMouseExit()
        Visibility: Private
        Output: N/A
        Purpose: 

        a. Scale down the GFX Object to normal original scale 
    */

    void OnMouseExit()
    {
        GFX.transform.localScale = normalScale;
    }

    /*
        Method: OnMouseDown()
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Declare an integer variable named "randomNumber".
        b. If the GameController's PlayerStartNode is not null:
        c. Then Check if the current node is connected to the PlayerStartNode.
        d. If it is connected:
        e. Then Check the battleStrength of the current node:
        f. If it is 0
        g. Then call the loadRestStop() method.
        h. If it is 1, 2, or 3
        i. Then call the loadBattleScene() method. If it is 4 then Load Event Scene
        j. If the GameController's PlayerStartNode is null:
        k. Then Check if the current node has no backward connections.
        l. If it doesn't have any backward connections
        m. Then call the loadBattleScene() method.
    */

    void OnMouseDown()
    {
        int randomNumber;
        if (GameController.PlayerStartNode != null)
        {
            if (GameController.PlayerStartNode.IsConnected(node) == true)
            {
                
                if(node.battleStrength == 0)
                {
                    loadRestStop();
                }
                
                if(node.battleStrength == 1)
                {
                    loadBattleScene();
                }
                
                if(node.battleStrength == 2)
                {
                    loadBattleScene();
                }
                
                if(node.battleStrength == 3)
                {
                    loadBattleScene();
                }
                if(node.battleStrength == 4)
                {
                    loadEventScene();
                }
            }
        }

        else
        {
            if(node.backwardConnections.Count == 0)
            {
                loadBattleScene();
            }
            
        }
    }

    /*

        Method: animateNodes
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Iterate through the GameController's PlayerMapPos list.
        b. If the current node's ID matches an ID in the PlayerMapPos list
        c. Then enable the animator component.
    */

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

    /*

        Method: deanimateNodes
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Loop through the GameController's PlayerMapPos list.
        b. If the current node's ID matches an ID in the PlayerMapPos list
        c. Then disable the animator component.

    */

    public void deanimateNodes()
    {
        for (int i = 0; i < GameController.PlayerMapPos.Count; i++)
        {
            if (node.id == GameController.PlayerMapPos[i])
            {
                animator.enabled = false;
            }
        }
    }

    /*
        Method: loadBattleScene
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Set the GameController's PlayerStartColumn to the current node's column.
        b. Set the GameController's PlayerStartNode to the current node.
        c. Add the current node's ID to the GameController's PlayerMapPos list.
        d. Load the "BattleScreen" scene using SceneManager.
    */

    void loadBattleScene()
    {
        GameController.PlayerStartColumn = node.column;
        GameController.PlayerStartNode = node;
        GameController.PlayerMapPos.Add(node.id);

        SceneManager.LoadScene("BattleScreen");
    } 

    /*
        Method: loadRestStop
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Load the "RestStop" scene using SceneManager.
        b. Set the GameController's PlayerStartColumn to the current node's column.
        c. Set the GameController's PlayerStartNode to the current node.
        d. Add the current node's ID to the GameController's PlayerMapPos list.
    */

    void loadRestStop()
    {
        SceneManager.LoadScene("RestStop");
        GameController.PlayerStartColumn = node.column;
        GameController.PlayerStartNode = node;
        GameController.PlayerMapPos.Add(node.id);
    }

    /*
        Method: loadEventStop
        Visibility: Private 
        Output: N/A
        Purpose: 

        a. Load the "EventStop" scene using SceneManager.
        b. Set the GameController's PlayerStartColumn to the current node's column.
        c. Set the GameController's PlayerStartNode to the current node.
        d. Add the current node's ID to the GameController's PlayerMapPos list.
    */

    void loadEventScene()
    {
        SceneManager.LoadScene("EventStop");
        GameController.PlayerStartColumn = node.column;
        GameController.PlayerStartNode = node;
        GameController.PlayerMapPos.Add(node.id);
    }
}
