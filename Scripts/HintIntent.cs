using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintIntent : MonoBehaviour
{
    public void HINTSCENE(string scenename)
    {
       
        SceneManager.LoadScene(scenename);
    }
}

