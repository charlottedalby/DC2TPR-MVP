using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WorldMapGenerator{



public class NodeOBJ : MonoBehaviour {
    public Node node;
    private Vector3 normalScale;
    [SerializeField] private Transform GFX;
    [SerializeField] private Animator animator;
    private bool canSelect = false;

    void Start(){

        normalScale = GFX.localScale;
        
        if(node.row != 0){
            animator.enabled = false;
        }

    }

    void OnMouseOver(){
        GFX.transform.localScale = 2 * normalScale;
    }

    void OnMouseExit(){
        GFX.transform.localScale = normalScale;
    }

    void OnMouseDown(){
        SceneManager.LoadScene("BattleScreen");
    }
}

}
