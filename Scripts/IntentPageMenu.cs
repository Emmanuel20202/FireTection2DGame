using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntentPageMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void HouseLevelMenu()
    {
        SceneManager.LoadScene("HouseMenu");
    }
    public void SchoolLevelMenu()
    {
        SceneManager.LoadScene("SchoolMenu");
    }
    public void BusinessLevelMenu()
    {
        SceneManager.LoadScene("BusinessMenu");
    }
    public void FireSafetyTipsMenu()
    {
        SceneManager.LoadScene("FireSafetyTips");
    }
    public void TutorialsMenu()
    {
        SceneManager.LoadScene("IntroT1");
    }
}
