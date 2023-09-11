using UnityEngine;
using UnityEngine.UI;

public class B3Star : MonoBehaviour
{
    public Image star1;
    public Image star2;
    public Image star3;

    public Image fullStarImage;
    public Image emptyStarImage;

    private int starsEarned;
    private int highestStarsEarned;

    void Start()
    {
        starsEarned = PlayerPrefs.GetInt("starsEarnedB3", 0);
        highestStarsEarned = PlayerPrefs.GetInt("highestStarsEarnedB3", 0);

        if (starsEarned > highestStarsEarned)
        {
            highestStarsEarned = starsEarned;
            PlayerPrefs.SetInt("highestStarsEarnedB3", highestStarsEarned);
            PlayerPrefs.Save();
        }
        else
        {
            starsEarned = highestStarsEarned;
        }

        switch (starsEarned)
        {
            case 3:
                star1.sprite = fullStarImage.sprite;
                star2.sprite = fullStarImage.sprite;
                star3.sprite = fullStarImage.sprite;
                break;
            case 2:
                star1.sprite = fullStarImage.sprite;
                star2.sprite = fullStarImage.sprite;
                star3.sprite = emptyStarImage.sprite;
                break;
            case 1:
                star1.sprite = fullStarImage.sprite;
                star2.sprite = emptyStarImage.sprite;
                star3.sprite = emptyStarImage.sprite;
                break;
            default:
                star1.sprite = emptyStarImage.sprite;
                star2.sprite = emptyStarImage.sprite;
                star3.sprite = emptyStarImage.sprite;
                break;
        }
    }
}
