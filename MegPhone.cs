using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MegPhone : MonoBehaviour
{
    public AudioClip soundClip;
    public Text typingText;
    public string nextSceneName;

    public AudioSource audioSource;

    public Image countdownImage;
    public GameObject gameOverPanel;
    public Text collisionIndicatorText;
    private float currentTime = 20f;
    private bool timerIsRunning = false;
    private int starsEarned = 0;


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        typingText.text = "";
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
        public void PlaySoundAndMoveNextScene()
    {
        // Play the sound
        audioSource.clip = soundClip;
        audioSource.Play();

        // Start typing text coroutine
        StartCoroutine(TypeText());

        // Move to the next scene after the sound finishes playing
        Invoke("MoveNextScene", soundClip.length);

        PlayerPrefs.SetFloat("capturedTime", currentTime);
        PlayerPrefs.SetInt("starsEarnedS4", starsEarned);
    }

    private void MoveNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    private System.Collections.IEnumerator TypeText()
    {
        string fullText = "Everyone let us gather to conduct a headcount...";
        for (int i = 0; i <= fullText.Length; i++)
        {
            typingText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
