using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Rotating : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector2 swipeStartPos;
    private Vector2 swipeEndPos;

    public Image frontBody;
    public Image backBody;
    public GameObject fireImageUI;

    private int swipeUpCount = 0;
    private int swipeDownCount = 0;

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



    public void OnDrag(PointerEventData eventData)
    {
        swipeEndPos = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (swipeEndPos.y < swipeStartPos.y)
        {
            // Swipe down
            swipeDownCount++;
            Debug.Log("Swipe Down Count: " + swipeDownCount);
            frontBody.gameObject.SetActive(true);
            backBody.gameObject.SetActive(false);
        }
        else if (swipeEndPos.y > swipeStartPos.y)
        {
            // Swipe up
            swipeUpCount++;
            Debug.Log("Swipe Up Count: " + swipeUpCount);
            frontBody.gameObject.SetActive(false);
            backBody.gameObject.SetActive(true);
        }

        if (swipeUpCount >= 2 && swipeDownCount >= 2)
        {
            fireImageUI.SetActive(false);
            Invoke("Second", 1f);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        swipeStartPos = eventData.position;
    }

    // Use this method to detect mouse input for testing in the Unity Editor
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


        if (Input.GetMouseButtonDown(0))
        {
            swipeStartPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            swipeEndPos = Input.mousePosition;

            if (swipeEndPos.y < swipeStartPos.y)
            {
                // Swipe down
                swipeDownCount++;
                Debug.Log("Swipe Down Count: " + swipeDownCount);
                frontBody.gameObject.SetActive(true);
                backBody.gameObject.SetActive(false);
            }
            else if (swipeEndPos.y > swipeStartPos.y)
            {
                // Swipe up
                swipeUpCount++;
                Debug.Log("Swipe Up Count: " + swipeUpCount);
                frontBody.gameObject.SetActive(false);
                backBody.gameObject.SetActive(true);
            }

            if (swipeUpCount >= 2 && swipeDownCount >= 2)
            {
                fireImageUI.SetActive(false);
                Invoke("Second", 1f);
            }
        }
    }

    public void Second()
    {
        PlayerPrefs.SetFloat("capturedTime", currentTime);
        PlayerPrefs.SetInt("starsEarnedS8", starsEarned);
        SceneManager.LoadScene("CorrectS8");
    }
}
