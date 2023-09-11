using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnOffSFX : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted1"))
        {
            PlayerPrefs.SetInt("muted1", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButton();
        AudioListener.pause = muted;
    }


    public void onButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted1") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted1", muted ? 1 : 0);
    }

}
