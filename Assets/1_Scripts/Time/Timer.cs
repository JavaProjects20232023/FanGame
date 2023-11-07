using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    private float maxValue = 30f;

    void Start()
    {
        slider.maxValue = maxValue;
    }

    void Update()
    {
        slider.value = (float)User.day;
    }
}
