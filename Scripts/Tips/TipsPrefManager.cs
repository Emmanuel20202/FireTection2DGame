using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsPrefManager : MonoBehaviour
{
   // public const string Coins = "Coins";
    public static string tips = "";
    void Start()
    {
        tips = PlayerPrefs.GetString("Coins");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void UpdateTips()
    {
        PlayerPrefs.SetString("Coins", tips);
        tips = PlayerPrefs.GetString("Coins");
        PlayerPrefs.Save();
    }

}
