using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewIntent : MonoBehaviour
{
    public void NEWINTENTPAGE(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
