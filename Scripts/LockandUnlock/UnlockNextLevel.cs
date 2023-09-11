using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockNextLevel : MonoBehaviour
{
    public string[] sceneNames; // The names of the scenes corresponding to each level

    public void Unlock()
    {
        int currentLevelIndex = GetCurrentLevelIndex();

        if (currentLevelIndex < sceneNames.Length - 1)
        {
            // Unlock the next level
            PlayerPrefs.SetInt(sceneNames[currentLevelIndex + 1] + "Unlocked", 1);
        }
    }

    private int GetCurrentLevelIndex()
    {
        // Get the index of the current level
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (Application.loadedLevelName == sceneNames[i])
            {
                return i;
            }
        }

        return -1; // Level not found
    }
}
