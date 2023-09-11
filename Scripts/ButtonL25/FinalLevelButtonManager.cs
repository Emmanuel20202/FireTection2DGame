using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalLevelButtonManager : MonoBehaviour
{
    // Declare static variables to keep track of button clicks across scenes
    public static bool button1Clicked = false;
    public static bool button2Clicked = false;
    public static bool button3Clicked = false;

    // Declare keys for saving button click states in PlayerPrefs
    public static string button1Key = "button1Clicked";
    public static string button2Key = "button2Clicked";
    public static string button3Key = "button3Clicked";

    // This function will be called from each button in Scene 1, 2, and 3
    public static void UpdateButtons(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1:
                if (button1Clicked)
                {
                    Debug.Log("Button 1 has already been clicked");
                    return;
                }
                button1Clicked = true;
                PlayerPrefs.SetInt(button1Key, 1);
                Debug.Log("Button 1 has been clicked");
                break;
            case 2:
                if (button2Clicked)
                {
                    Debug.Log("Button 2 has already been clicked");
                    return;
                }
                button2Clicked = true;
                PlayerPrefs.SetInt(button2Key, 1);
                Debug.Log("Button 2 has been clicked");
                break;
            case 3:
                if (button3Clicked)
                {
                    Debug.Log("Button 3 has already been clicked");
                    return;
                }
                button3Clicked = true;
                PlayerPrefs.SetInt(button3Key, 1);
                Debug.Log("Button 3 has been clicked");
                break;
            default:
                Debug.Log("Invalid button number");
                break;
        }
    }

    void Start()
    {
        // Load the saved button click states from PlayerPrefs
        button1Clicked = PlayerPrefs.GetInt(button1Key, 0) == 1;
        button2Clicked = PlayerPrefs.GetInt(button2Key, 0) == 1;
        button3Clicked = PlayerPrefs.GetInt(button3Key, 0) == 1;
    }
}
