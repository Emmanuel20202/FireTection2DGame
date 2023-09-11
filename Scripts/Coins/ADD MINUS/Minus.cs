using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Minus : MonoBehaviour
{
    public int coinsToDeduct = 60;
    public Text popupText;
    public string nextScene;

    public void DeductCoins()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);

        if (currentCoins >= coinsToDeduct)
        {
            currentCoins -= coinsToDeduct;
            PlayerPrefs.SetInt("Coins", currentCoins);

            Debug.Log("Coins deducted. Current coins: " + currentCoins);

            // Load the next scene if there are enough coins
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            // Display popup text if there are not enough coins
            popupText.text = "YOU DON'T HAVE ENOUGH COINS TO BUY A HINT";
            Debug.Log("Not enough coins to deduct!");
        }

        // Update the coinsText component in the next scene
        PlayerPrefs.SetInt("CoinsToDisplay", currentCoins);
    }
}
