using UnityEngine;
using UnityEngine.UI;

public class DisplayTipsS7 : MonoBehaviour
{
    public Text contentText;

    private void Start()
    {
        // Get the content of the text from the PlayerPref
        string content = PlayerPrefs.GetString("TipsS7");

        // Display the content in the Text object
        contentText.text = content;
    }
}
