using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerCall : MonoBehaviour
{
  
    public Button callButton;
   
    public Image countdownImage;
    public GameObject gameOverPanel;
    public Text collisionIndicatorText;
    private float currentTime = 20f;
    private bool timerIsRunning = false;
    private int starsEarned = 0;

    public void Start()
    {
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

    public void Call()
    {
        // Wait for 1 second before loading the next scene
        StartCoroutine(LoadSceneAfterDelay("CorrectB4", 1f));
        PlayerPrefs.SetFloat("capturedTime", currentTime);
        PlayerPrefs.SetInt("starsEarnedB4", starsEarned);
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
