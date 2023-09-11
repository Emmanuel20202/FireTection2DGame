using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsDisplay : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TipsPrefManager.tips = PlayerPrefs.GetString("Coins");
        string[] temp = text.text.Split(':');
        text.text = temp[0] + " : " +TipsPrefManager.tips;
       

    }
}
