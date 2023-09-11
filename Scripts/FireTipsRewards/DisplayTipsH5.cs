using UnityEngine;
using UnityEngine.UI;

public class DisplayTipsH5 : MonoBehaviour
{
    public Text contentText;

    private void Start()
    {
        // Get the content of the text from the PlayerPref
        string content = PlayerPrefs.GetString("TipsH5");

        // Display the content in the Text object
        contentText.text = content;
    }
}
