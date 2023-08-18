using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Class: LevelChanger 
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. animator

    Purpose: 

    a. Fades Out Scene
*/

public class LevelChanger : MonoBehaviour
{
    public Animator animator;  

    public void fadeToLevel(string name)
    {
        animator.SetTrigger("FadeOut");
        #if UNITY_EDITOR
            string tempName = "Assets/Scenes/";
            string amendedNameOne = tempName + name;
            string amendedNameTwo = amendedNameOne +".unity";
            name = amendedNameTwo;
            UnityEditor.SceneManagement.EditorSceneManager.OpenScene(name);
        #endif
    }
}
