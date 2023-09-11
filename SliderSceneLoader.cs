using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderSceneLoader : MonoBehaviour
{
    public Slider slider;
    public string sceneName;

    private void Update()
    {
        if (slider.value >= slider.maxValue)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
