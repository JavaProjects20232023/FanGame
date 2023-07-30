using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    private float currentTime = 1f;
    private float maxValue = 61f;
    private float incrementValue = 1f;

    void Start()
    {
        slider.maxValue = maxValue;
    }

    void Update()
    {
        currentTime += incrementValue * Time.deltaTime;
        if (currentTime >= maxValue)
        {
            currentTime = 1f;
        }

        slider.value = currentTime;
    }
}
