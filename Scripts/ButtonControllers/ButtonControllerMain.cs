using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerMain : MonoBehaviour
{
    public string sceneKey;
    public float incrementAmount = 0.1f;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClickHandler);
    }

    private void ButtonClickHandler()
    {
        // Check if the button has been clicked in this scene before
        if (!PlayerPrefs.HasKey(sceneKey))
        {
            // Increment the slider value by the specified amount
            float newValue = PlayerPrefs.GetFloat("SliderValue", 0f) + incrementAmount;
            PlayerPrefs.SetFloat("SliderValue", newValue);
            PlayerPrefs.Save();

            // Set the flag to indicate that the button has been clicked in this scene
            PlayerPrefs.SetInt(sceneKey, 1);
            PlayerPrefs.Save();

            Debug.Log("Button clicked in scene " + sceneKey + ". Value added to the slider: " + newValue);
        }
        else
        {
            Debug.Log("Button already clicked in scene " + sceneKey + ". No value added to the slider.");
        }
    }
}
