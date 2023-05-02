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
    void Start(){
        normalScale = GFX.localScale;
        animator.enabled = false;

    }

    void OnMouseOver(){
        GFX.transform.localScale = 2 * normalScale;
    }

    void OnMouseExit(){
        GFX.transform.localScale = normalScale;
    }

    void OnMouseDown(){
        if (GameController.PlayerStartHealth != 100){
            int chance = Random.Range(1,10);
            if (chance == 1 || chance == 3){
                GameController.PlayerStartHealth += 10;
                if (GameController.PlayerStartHealth > 100){
                    GameController.PlayerStartHealth = 100;
                }
                SceneManager.LoadScene("RestStop");
            }
        }
        else{
            SceneManager.LoadScene("BattleScreen");
        }
        
    }
}


