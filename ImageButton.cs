using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageButton : MonoBehaviour
{
    public Image buttonImage;
    public Image newImage;
    public float holdTimeThreshold = 2f; // The time in seconds the button needs to be held for
    public float nextSceneDelay = 1.5f; // The time in seconds to wait before moving to the next scene

    private float holdTime = 0f;
    private bool isHolding = false;
    private bool imageChanged = false;
    private float delayTimer = 0f;
    private bool startDelay = false;

    public Image countdownImage;
    public GameObject gameOverPanel;
    public Text collisionIndicatorText;
    private float currentTime = 20f;
    private bool timerIsRunning = false;
    private int starsEarned = 0;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        timerIsRunning = true;
    }

    void Update()
    {
        starsEarned = 0; // reset starsEarned variable at the start of Update

        if (timerIsRunning)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                countdownImage.fillAmount = currentTime / 20f; // set the fill amount based on the current time

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


        if (Input.GetMouseButton(0))
        {
            holdTime += Time.deltaTime;
            if (holdTime >= holdTimeThreshold && !isHolding && !imageChanged)
            {
                isHolding = true;
                buttonImage.sprite = newImage.sprite;
                imageChanged = true;
                startDelay = true;
            }
        }
        else if (isHolding)
        {
            isHolding = false;
            if (imageChanged)
            {
                startDelay = true;
            }
        }
        else if (startDelay)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= nextSceneDelay)
            {
                PlayerPrefs.SetFloat("capturedTime", currentTime);
                PlayerPrefs.SetInt("starsEarnedB7", starsEarned);
                SceneManager.LoadScene("CorrectB7"); // Replace "NextScene" with the name of the scene you want to load
               
            }
        }
        else
        {
            holdTime = 0f;
        }
    }
}
