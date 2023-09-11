using UnityEngine;
using UnityEngine.UI;

public class SlidingDoor : MonoBehaviour
{
    public Slider slider;
    public Image image;
    private float initialXPosition;

    void Start()
    {
        initialXPosition = image.rectTransform.localPosition.x;
    }

    void Update()
    {
        float sliderValue = slider.value;
        float imageWidth = image.rectTransform.rect.width;
        float handleWidth = slider.handleRect.rect.width;
        float maxXPosition = (imageWidth / 2) - (handleWidth / 2) - Mathf.Abs(initialXPosition);
        float newXPosition = Mathf.Lerp(-maxXPosition, maxXPosition, sliderValue);

        Vector3 newPosition = image.rectTransform.localPosition;
        newPosition.x = initialXPosition + newXPosition;
        image.rectTransform.localPosition = newPosition;
    }
}
