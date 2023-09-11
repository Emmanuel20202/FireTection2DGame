using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScoreButton : MonoBehaviour
{
    public void ClearScore()
    {
        PlayerPrefs.DeleteKey("Score");
        //PlayerPrefs.DeleteKey("ResultText");
        PlayerPrefs.Save();
    }
}
