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

    private void Start()
    {
        likeSlider.maxValue = maxValue;
        likeSlider.value = User.likeAbility;
        likeAblity.text = User.likeAbility.ToString();
    }

    private void Update()
    {
        likeSlider.value = User.likeAbility;
        likeAblity.text = User.likeAbility.ToString();
    }

    public void LikeUp()
    {
        float k = Random.Range(0f, 10f);
        if (k < 1)
        {
            User.likeAbility++;
            likeAblity.text = User.likeAbility.ToString() + "%";
            likeSlider.value = User.likeAbility;
        }
    }
}
