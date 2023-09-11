using UnityEngine;
using UnityEngine.UI;

public class DisplayTipsS3 : MonoBehaviour
{
    public Text contentText;

    private void Start()
    {
        // Get the content of the text from the PlayerPref
        string content = PlayerPrefs.GetString("TipsS3");

        // Display the content in the Text object
        contentText.text = content;
    }
}
