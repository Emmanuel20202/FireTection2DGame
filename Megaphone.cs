using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Megaphone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float longPressDuration = 1.0f;
    public float quickReleaseDuration = 0.1f;
    public string nextSceneName;

    public Text typingText; // Reference to the Text component to display typing effect
    public string displayText; // The complete text to display

    private bool isHolding = false;
    private float pressStartTime = 0.0f;
    private float releaseTime = 0.0f;
    private float buttonHoldTime = 0.0f;

    private bool hasPlayed = false;
    private bool isTyping = false;
    private float typeStartTime = 0.0f;
    private int displayedCharacters = 0;



    public Image countdownImage;
    public GameObject gameOverPanel;
    public Text collisionIndicatorText;
    private float currentTime = 20f;
    private bool timerIsRunning = false;
    private int starsEarned = 0;

    private void Start()
    {
        timerIsRunning = true;
    }


    private void Awake()
    {
        typingText.text = ""; // Clear the text initially
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        pressStartTime = Time.time;
        releaseTime = 0.0f;
        StartTypingEffect();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        buttonHoldTime = 0.0f;
        releaseTime = Time.time;
        StopTypingEffect();
    }

    private void StartTypingEffect()
    {
        isTyping = true;
        typeStartTime = Time.time;
        displayedCharacters = 0;
        typingText.text = "";
    }

    private void StopTypingEffect()
    {
        isTyping = false;
        typingText.text = displayText; // Display the complete text

        PlayerPrefs.SetFloat("capturedTime", currentTime);
        PlayerPrefs.SetInt("starsEarnedS4", starsEarned);
        // Move to the next scene
        SceneManager.LoadScene(nextSceneName);
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

        if (isHolding && Time.time - pressStartTime > longPressDuration && !audioSource.isPlaying && !hasPlayed)
        {
            audioSource.PlayOneShot(audioClip);
            releaseTime = Time.time + audioClip.length;
            buttonHoldTime = Time.time - pressStartTime;
            hasPlayed = true;
        }
        else if (!isHolding && releaseTime > 0.0f && Time.time - releaseTime < quickReleaseDuration)
        {
            audioSource.Stop();
            releaseTime = 0.0f;
        }

        // check if the audio clip has finished playing and go to the next scene
        if (!audioSource.isPlaying && releaseTime > 0.0f)
        {
            PlayerPrefs.SetFloat("capturedTime", currentTime);
            PlayerPrefs.SetInt("starsEarnedS4", starsEarned);
            SceneManager.LoadScene(nextSceneName);
            releaseTime = 0.0f;
            hasPlayed = false;
        }

        // Update the typing effect
        if (isTyping)
        {
            float elapsedTime = Time.time - typeStartTime;
            int totalCharacters = Mathf.FloorToInt(elapsedTime * 10); // Adjust typing speed here (higher number = faster typing)
            if (totalCharacters > displayedCharacters)
            {
                displayedCharacters = totalCharacters;
                typingText.text = displayText.Substring(0, Mathf.Min(displayedCharacters, displayText.Length));
            }
        }
    }
}
