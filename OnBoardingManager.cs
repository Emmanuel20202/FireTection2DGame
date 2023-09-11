using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnBoardingManager : MonoBehaviour
{
    private const string FirstTimeKey = "IsFirstTime";

    public Button startButton;

    private void Awake()
    {
        // Check if it's the first time the app is launched
        if (PlayerPrefs.GetInt(FirstTimeKey, 1) == 1)
        {
            // If it's the first time, mark it as not the first time
            PlayerPrefs.SetInt(FirstTimeKey, 0);
            PlayerPrefs.Save();
        }
        else
        {
            // If it's not the first time and the button has been clicked, load the main scene and destroy the onboarding scene
            if (PlayerPrefs.GetInt("ButtonClicked", 0) == 1)
            {
                SceneManager.LoadScene("MainMenu");
                Destroy(gameObject);
                return;
            }
        }

        startButton.onClick.AddListener(StartButtonClicked);
    }

    public void StartButtonClicked()
    {
        PlayerPrefs.SetInt("ButtonClicked", 1);
        PlayerPrefs.Save();
      
    }
}