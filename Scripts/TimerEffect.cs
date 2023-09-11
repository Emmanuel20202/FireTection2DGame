using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEffect : MonoBehaviour
{
    public GameObject GameOverHolder;
    float time_remaining;
    public float max_time = 5.0f;
    // Start is called before the first frame update
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

        }
        else
        {
            GameOverHolder.SetActive(true);

        }
    }
}
