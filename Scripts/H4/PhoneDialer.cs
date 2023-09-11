using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhoneDialer : MonoBehaviour
{
    public string phoneNumber;
    public Text inputText;
    public Button callButton;
    public Button[] numberButtons;
    public Button deleteButton;

    public Image countdownImage;
    public GameObject gameOverPanel;
    public Text collisionIndicatorText;
    private float currentTime = 20f;
    private bool timerIsRunning = false;
    private int starsEarned = 0;

    public void Start()
    {
        // Disable the CallButton at the start of the game
        callButton.interactable = false;

        // Set up OnClick events for number buttons
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int buttonNumber = i + 1;
            numberButtons[i].onClick.AddListener(() => AppendNumber(buttonNumber));
            numberButtons[i].GetComponentInChildren<Text>().text = buttonNumber.ToString();
        }

        // Set up OnClick event for delete button
        deleteButton.onClick.AddListener(DeleteNumber);

        timerIsRunning = true;
    }

    private void Update()
    {
        starsEarned = 0; // reset starsEarned variable at the start of Update

        if (timerIsRunning)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                //countdownImage.fillAmount = currentTime / 20f; // set the fill amount based on the current time

                if (currentTime <= 20f && currentTime > 15f && starsEarned < 3)
                {
                    starsEarned = 3;
                    Debug.Log("You earned 3 stars!");
                }
                else if (currentTime <= 14f && currentTime > 10f && starsEarned < 2)
                {
                    starsEarned = 2;
                    Debug.Log("You earned 2 stars!");
                }
                else if (currentTime <= 9f && currentTime >= 1f && starsEarned < 1)
                {
                    starsEarned = 1;
                    Debug.Log("You earned 1 star!");
                }
            }
            else
            {
                currentTime = 0;
                timerIsRunning = false;
                countdownImage.fillAmount = 0f; // set the fill amount to 0 when time's up
                gameOverPanel.SetActive(true); // activate game over panel
            }
        }
    }


    public void AppendNumber(int number)
    {
        phoneNumber += number.ToString();
        inputText.text = phoneNumber;

        // Enable the CallButton once a number is entered
        if (phoneNumber == "639123")
        {
            callButton.interactable = true;
        }
        else
        {
            callButton.interactable = false;
        }
    }

    public void DeleteNumber()
    {
        if (phoneNumber.Length > 0)
        {
            phoneNumber = phoneNumber.Substring(0, phoneNumber.Length - 1);
            inputText.text = phoneNumber;

            // Disable the CallButton if there are no more numbers entered
            if (phoneNumber == "")
            {
                callButton.interactable = false;
            }
        }
    }

    public void Call()
    {
        if (phoneNumber == "639123")
        {
            // Change the button text to "Calling"
            callButton.GetComponentInChildren<Text>().text = "Calling...";

            // Disable the button until the scene loads
            callButton.interactable = false;

            // Wait for 1 second before loading the next scene
            StartCoroutine(LoadSceneAfterDelay("CorrectH4", 2f));

            PlayerPrefs.SetFloat("capturedTime", currentTime);
            PlayerPrefs.SetInt("starsEarnedH4", starsEarned);


        }
        else
        {
            inputText.text = "Wrong number!";
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
