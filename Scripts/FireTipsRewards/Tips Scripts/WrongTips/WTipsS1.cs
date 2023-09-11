using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WTipsS1 : MonoBehaviour
{
    public Text contentText;
    public Button sendButton;
    public string nextSceneName;

    private void Start()
    {
        sendButton.onClick.AddListener(SendText);
    }

    private void SendText()
    {
        // Save the content of the text as a PlayerPref specific to this scene
        PlayerPrefs.SetString("WTipsS1", contentText.text);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
