using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewClearPref : MonoBehaviour
{
    public void NEWINTENTPAGE(string SceneName)
    {
        // Check if the score is "Lowly Aware"
        string resultText = PlayerPrefs.GetString("ResultText", "");
        if (resultText == "Lowly Aware")
        {
            // Clear all player preferences
            PlayerPrefs.DeleteAll();
        }

        // Load the specified scene
        SceneManager.LoadScene(SceneName);
    }
}
