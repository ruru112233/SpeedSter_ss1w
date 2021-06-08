using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeJonny : MonoBehaviour
{
    [SerializeField] Text timerText;
    private float second;
    private int minute;
    private int hour;

    bool jonny = false;

    void Update()
    {
        if (jonny)
        {
            second += Time.deltaTime;

            if (minute > 60)
            {
                hour++;
                minute = 0;
            }
            if (second > 60f)
            {
                minute += 1;
                second = 0;
            }

            timerText.text = hour.ToString() + ":" + minute.ToString("00") + ":" + second.ToString("f2");
        }
    }

    public void Jonny()
    {
        jonny = true;
    }
}