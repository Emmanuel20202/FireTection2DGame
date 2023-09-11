using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTextAware : MonoBehaviour
{
    public Text resultText;

    void Start()
    {
        // Retrieve the result text from PlayerPrefs
        string result = PlayerPrefs.GetString("ResultText");
        resultText.text = result;
    }
}
