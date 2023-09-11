using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLevelScript : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPage;
    [SerializeField] private AudioSource audioSource;

    public void Paused()
    {
        PauseMenuPage.SetActive(true);
        Time.timeScale = 0f;
        audioSource.Pause();
    }

    public void Resume()
    {
        PauseMenuPage.SetActive(false);
        Time.timeScale = 1f;
        audioSource.UnPause();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
    }
}
