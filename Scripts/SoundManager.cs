using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    private const string volumePrefKey = "volume28";

    private void Awake()
    {
        // Set the volume slider value to the saved volume value, or to the default of 1 if it hasn't been set yet.
        volumeSlider.value = PlayerPrefs.GetFloat(volumePrefKey, 1f);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(volumePrefKey, volume);
    }
}
