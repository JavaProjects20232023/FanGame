using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    private DayMonth dayMonth;
    private float maxValue = 30f;

    void Start()
    {
        slider.maxValue = maxValue;
        dayMonth = GameObject.Find("DayMonth").GetComponent<DayMonth>();
    }

    void Update()
    {
        slider.value = (float)dayMonth.day;
    }
}
