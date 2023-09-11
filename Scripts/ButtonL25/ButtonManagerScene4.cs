using UnityEngine;
using UnityEngine.UI;

public class ButtonManagerScene4 : MonoBehaviour
{
    // Declare reference to the canvas object in Scene 4
    public GameObject canvasObject;
    private const string canvasShownKey = "CanvasShown";

    private void Awake()
    {
        // Check if the canvas has been shown before
        bool isCanvasShown = PlayerPrefs.GetInt(canvasShownKey, 0) == 1;

        if (!isCanvasShown)
        {
            // Load the saved button click states from PlayerPrefs
            bool button1Clicked = PlayerPrefs.GetInt(FinalLevelButtonManager.button1Key, 0) == 1;
            bool button2Clicked = PlayerPrefs.GetInt(FinalLevelButtonManager.button2Key, 0) == 1;
            bool button3Clicked = PlayerPrefs.GetInt(FinalLevelButtonManager.button3Key, 0) == 1;

            // Check if all three buttons have been clicked
            if (button1Clicked && button2Clicked && button3Clicked)
            {
                // Make the canvas object active
                canvasObject.SetActive(true);
                PlayerPrefs.SetInt(canvasShownKey, 1); // Set the flag to indicate the canvas has been shown
            }
            else
            {
                // Make the canvas object inactive
                canvasObject.SetActive(false);
            }
        }
        else
        {
            // Make the canvas object inactive if it has already been shown
            canvasObject.SetActive(false);
        }
    }
}
