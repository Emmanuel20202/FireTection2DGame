using UnityEngine;

public class Add : MonoBehaviour
{
    public int coinsToAdd = 15;
    public string sceneKey = ""; // Unique key for this scene

    public void AddCoins()
    {
        // Check if the button has already been clicked in this scene
        if (PlayerPrefs.HasKey(sceneKey))
        {
            Debug.Log("Coins can only be added once per scene.");
            return;
        }

        // Add coins and set the flag indicating the button has been clicked
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        currentCoins += coinsToAdd;
        PlayerPrefs.SetInt("Coins", currentCoins);
        PlayerPrefs.SetInt(sceneKey, 1);

        Debug.Log("Coins added. Current coins: " + currentCoins);
    }
}
