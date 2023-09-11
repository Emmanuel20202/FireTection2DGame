using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    // Specify the player preference key you want to reset
    public string playerPrefKey = "Score";

    // Function to reset the player preference
    public void ResetPlayerPref()
    {
        PlayerPrefs.DeleteKey(playerPrefKey);
    }
}
