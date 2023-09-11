using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IncreaseTips()
    {
        TipsPrefManager.tips.ToString();
        TipsPrefManager.UpdateTips();
    }
}
