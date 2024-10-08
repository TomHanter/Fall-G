using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Stopwatch : MonoBehaviour
{
    bool stopwatchActive = false;
    float currentTime;
    [SerializeField] TMP_Text currentTimeText;

    private void Start()
    {
        currentTime = 0;
    }

    private void Update()
    {
        if (stopwatchActive == true)
            currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }
    public void StartStopwatch(Collider other)
    {
        stopwatchActive = true;
    }

    public void StopStopwatch(Collider other)
    {
        stopwatchActive = false;
    }
}
