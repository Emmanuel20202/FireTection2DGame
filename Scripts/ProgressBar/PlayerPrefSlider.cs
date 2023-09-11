using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class PlayerPrefSlider : MonoBehaviour
{
    public const string Coins = "Coins";
    public static int progress = 0;
    void Start()
    {
        progress = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void UpdateProgress()
    {
        PlayerPrefs.SetInt("Coins", progress);
        progress = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.Save();
    }
}
