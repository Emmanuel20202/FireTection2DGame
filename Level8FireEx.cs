using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Level8FireEx : MonoBehaviour, IDragHandler
{
    public Transform leverTransform;
    public float currentRotation;
    private float maxRotation = 20f;
    public Image leverImage;
    public ParticleSystem particleSystem; // reference to the particle system
    public float animationFrameRate = 10f; // number of frames per second to animate
    private bool isAnimating = false; // flag to indicate if animation is currently playing

    public Image pullPinImage; // reference to the pull pin image
    private bool isPullPinUnlocked = false; // flag to indicate if the pull pin is unlocked

    public GameObject[] fireImages; // array of all fire images
    private bool allDisabled = false; // flag to indicate if all fire images are disabled

    //ForStars
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
        // Check if the pull pin image has been dragged beyond a certain threshold
        if (eventData.position.y < Screen.height * 0.5f)
        {
            UnlockPullPin();
        }

        // Move the pull pin image to the current pointer position
        pullPinImage.rectTransform.anchoredPosition += eventData.delta;
    }


    public void OnPullPinDrag()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(pullPinImage.rectTransform, Input.mousePosition, null, out pos);
        pullPinImage.rectTransform.anchoredPosition = pos;

        pullPinImage.enabled = false; // Disable the image while dragging
    }


    void Update()
    {
        if (isPullPinUnlocked)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    PullLever();
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    ReleaseLever();
                }
            }
        }

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
    }



    public void UnlockPullPin()
    {
        isPullPinUnlocked = true;
    }

    void PullLever()
    {
        if (currentRotation > -maxRotation)
        {
            currentRotation -= 20f;
            leverTransform.localRotation = Quaternion.Euler(0f, 0f, currentRotation);
            UpdateLeverImage();

            // Start the animation if it's not already playing
            if (!isAnimating)
            {
                isAnimating = true;
                particleSystem.Play(); // start playing the particle system
            }
        }
    }

    void ReleaseLever()
    {
        if (currentRotation < 0f)
        {
            currentRotation += 40f;
            leverTransform.localRotation = Quaternion.Euler(0f, 0f, currentRotation);
            UpdateLeverImage();

            if (isAnimating)
            {
                isAnimating = false; // stop animation when lever is released
                particleSystem.Stop(); // stop the particle system
            }
        }
        else if (currentRotation > 0f)
        {
            currentRotation -= 2f;
            leverTransform.localRotation = Quaternion.Euler(0f, 0f, currentRotation);
            UpdateLeverImage();
        }

        // Check if all fire images are disabled
        bool allDisabled = true;
        foreach (GameObject fireImage in fireImages)
        {
            if (fireImage.activeSelf)
            {
                allDisabled = false;
                break;
            }
        }

        // If all fire images are disabled, move to the next scene
        if (allDisabled)
        {
          
            // Load the next scene
            SceneManager.LoadScene("WrongH8");
        }

    }
    void UpdateLeverImage()
    {
        leverImage.fillAmount = (currentRotation + maxRotation) / (maxRotation * 2);
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Fire")
        {
            Destroy(other);
        }
    }

}
