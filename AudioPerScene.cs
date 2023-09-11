using UnityEngine;

public class AudioPerScene : MonoBehaviour
{
    public AudioSource audioSource;
    private const string volumePrefKey = "volume28";

    private void Start()
    {
        // Set the volume of the audio source to the saved volume value, or to the default of 1 if it hasn't been set yet.
        audioSource.volume = PlayerPrefs.GetFloat(volumePrefKey, 1f);
    }
}
