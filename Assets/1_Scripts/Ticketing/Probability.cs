using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Probability : MonoBehaviour
{
    [SerializeField]
    private GameObject success;
    [SerializeField]
    private GameObject faild;
    private LikeAblity likeAblity;
    void Start()
    {
        likeAblity = GameObject.Find("GameManager").GetComponent<LikeAblity>();
    }

    public void Fan()
    {
        float k = Mathf.Round(Random.Range(0.1f, 100.0f)*10f) / 10f;
        if(k >= User.probability)
        {
            faild.SetActive(true);
            Invoke("Wait15SecFaild", 1.5f);
        }
        else
        {
            success.SetActive(true);
            Invoke("Wait15SecSuccess", 1.5f);
            likeAblity.LikeUp();
        }
    }

    void Wait15SecFaild()
    {
        faild.SetActive(false);
    }

    void Wait15SecSuccess()
    {
        success.SetActive(false);
    }
}
