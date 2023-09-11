using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangerFade : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;


    // Update is called once per frame
    void Update()
    {

    }
    public void FadetoLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
        levelToLoad = levelIndex;
    }
}
