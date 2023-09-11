using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomString : MonoBehaviour
{
    // GameObject
    public Text sentenceText;

    void Start()
    {
        // Retrieve the tipsList from PlayerPrefs
        List<string> tipsList = new List<string>();

        // Add values from PlayerPrefs if they exist
        if (!AllPlayerPrefsEmpty())
        {
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB1")))
                tipsList.Add(PlayerPrefs.GetString("WTipsB1"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB2")))
                tipsList.Add(PlayerPrefs.GetString("WTipsB2"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB3")))
                tipsList.Add(PlayerPrefs.GetString("WTipsB3"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB4")))
                tipsList.Add(PlayerPrefs.GetString("WTipsB4"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB5")))
                tipsList.Add(PlayerPrefs.GetString("WTipsB5"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB6")))
                tipsList.Add(PlayerPrefs.GetString("WTipsB6"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB7")))
                tipsList.Add(PlayerPrefs.GetString("WTipsB7"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB8")))
                tipsList.Add(PlayerPrefs.GetString("WTipsB8"));

            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH1")))
                tipsList.Add(PlayerPrefs.GetString("WTipsH1"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH2")))
                tipsList.Add(PlayerPrefs.GetString("WTipsH2"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH3")))
                tipsList.Add(PlayerPrefs.GetString("WTipsH3"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH4")))
                tipsList.Add(PlayerPrefs.GetString("WTipsH4"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH5")))
                tipsList.Add(PlayerPrefs.GetString("WTipsH5"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH6")))
                tipsList.Add(PlayerPrefs.GetString("WTipsH6"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH7")))
                tipsList.Add(PlayerPrefs.GetString("WTipsH7"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH8")))
                tipsList.Add(PlayerPrefs.GetString("WTipsH8"));

            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS1")))
                tipsList.Add(PlayerPrefs.GetString("WTipsS1"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS2")))
                tipsList.Add(PlayerPrefs.GetString("WTipsS2"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS3")))
                tipsList.Add(PlayerPrefs.GetString("WTipsS3"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS4")))
                tipsList.Add(PlayerPrefs.GetString("WTipsS4"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS5")))
                tipsList.Add(PlayerPrefs.GetString("WTipsS5"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS6")))
                tipsList.Add(PlayerPrefs.GetString("WTipsS6"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS7")))
                tipsList.Add(PlayerPrefs.GetString("WTipsS7"));
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS8")))
                tipsList.Add(PlayerPrefs.GetString("WTipsS8"));
        }

        // Check if the tipsList is empty
        if (tipsList.Count == 0)
        {
            Debug.Log("The tips list is empty or PlayerPrefs values are empty!");

            // Set a default text when the tipsList is empty
            sentenceText.text = "In case of Fire and other Emergencies please Contact Our Hotline Number Mobile Number: 0925-453-0777 Tel. No. (044) 940-5258";
        }
        else
        {
            // Generate a random index to select a tip from the list
            int randomIndex = Random.Range(0, tipsList.Count);
            // Get the tip at the random index
            string tip = tipsList[randomIndex];
            // Set the text of the Text component to the randomly selected tip
            sentenceText.text = tip;
        }
    }


    // Helper method to check if all PlayerPrefs values are empty
    private bool AllPlayerPrefsEmpty()
    {
        return string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB1"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB2"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB3"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB4"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB5"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB6"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB7"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsB8"))

            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH1"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH2"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH3"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH4"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH5"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH6"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH7"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsH8"))

            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS1"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS2"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS3"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS4"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS5"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS6"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS7"))
            && string.IsNullOrEmpty(PlayerPrefs.GetString("WTipsS8"));
    }
}
