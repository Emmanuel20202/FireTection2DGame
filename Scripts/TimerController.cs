using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOverHolder;
    public Image linear_foreground;
    float time_remaining;
    public float max_time = 10.0f;
    //public GameObject timertextholder;

    void Start()
    {
        time_remaining = max_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
            linear_foreground.fillAmount = time_remaining / max_time;
        }
        else
        {
            GameOverHolder.SetActive(true);
            //timertextholder.SetActive(false);
        }

    }
}
