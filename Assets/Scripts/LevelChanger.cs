using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;  

    public void fadeToLevel(string name)
    {
        animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(name);
    }
}
