using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay2 : MonoBehaviour
{
    public Text scoreText;
    public Text resultText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "YOUR SCORE: " + score;

        if (score <= 12)
        {
            resultText.text = "Lowly Aware";
        }
        else if (score >= 13 && score <= 18)
        {
            resultText.text = "Moderately Aware";
            SceneManager.LoadScene("Congrats Scene");
        }
        else if (score >= 19 && score <= 25)
        {
            resultText.text = "Highly Aware";
            SceneManager.LoadScene("Congrats Scene");
            return; // Exit the method after loading the scene
        }

        // Store the result text in PlayerPrefs
        PlayerPrefs.SetString("ResultText", resultText.text);
    }
}
