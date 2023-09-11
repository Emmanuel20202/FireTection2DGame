using UnityEngine;
using UnityEngine.UI;

public class CoinsDisplay : MonoBehaviour
{
    public Text coinsText;
    public string[] sceneKeys; // Array of unique keys for this scene

    void Start()
    {
        // Get the current number of coins from PlayerPrefs
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);

        // Check if the button has already been clicked in any of the scene keys
        bool coinsAdded = false;
        foreach (string key in sceneKeys)
        {
            if (PlayerPrefs.HasKey(key))
            {
                coinsAdded = true;
                break;
            }
        }

        if (coinsAdded)
        {
            Debug.Log("Coins have already been added in this scene.");
        }
        else
        {
            // If the button hasn't been clicked yet, add the coins and set the flag
            int coinsToAdd = 0;
            currentCoins += coinsToAdd;
            PlayerPrefs.SetInt("Coins", currentCoins);

            foreach (string key in sceneKeys)
            {
                PlayerPrefs.SetInt(key, 1);
            }

            Debug.Log("Coins added. Current coins: " + currentCoins);
        }

        // Display the current number of coins in the Text component
        coinsText.text = currentCoins.ToString();
    }
}
