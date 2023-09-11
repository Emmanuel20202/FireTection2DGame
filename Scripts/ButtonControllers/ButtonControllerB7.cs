using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControllerB7 : MonoBehaviour
{
    public string sceneName;
    public float incrementAmount = 0.1f;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClickHandler);
    }

    private void ButtonClickHandler()
    {
        // Check if the button has been clicked in this scene before
        if (!PlayerPrefs.HasKey(sceneName + "ButtonClickedB7"))
        {
            // Increment the slider value by the specified amount
            float newValue = PlayerPrefs.GetFloat("SliderValue", 0f) + incrementAmount;
            PlayerPrefs.SetFloat("SliderValue", newValue);
            PlayerPrefs.Save();

            // Set the flag to indicate that the button has been clicked in this scene
            PlayerPrefs.SetInt(sceneName + "ButtonClickedB7", 1);
            PlayerPrefs.Save();
        }

        // Load the scene containing the slider
        SceneManager.LoadScene(sceneName);
    }
}
