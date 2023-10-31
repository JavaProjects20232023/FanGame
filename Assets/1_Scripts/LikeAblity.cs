using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeAblity : MonoBehaviour
{
    [SerializeField]
    private Text likeAblity;
    [SerializeField]
    private Slider likeSlider;
    private float maxValue = 100f;
    private float likes = 0;

    private void Start()
    {
        likeSlider.maxValue = maxValue;
        likeSlider.value = 0;
    }

    public void LikeUp()
    {
        float k = Random.Range(0f, 10f);
        if (k < 1)
        {
            likes++;
            likeAblity.text = likes.ToString() + "%";
            likeSlider.value = likes;
            Debug.Log("È®·ü¾÷");
        }
    }
}
