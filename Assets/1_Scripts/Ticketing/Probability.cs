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
    [SerializeField]
    private GameObject scalper;

    private LikeAblity likeAblity;
    public bool succes = false;
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
            succes = true;
        }
    }

    void Wait15SecFaild()
    {
        faild.SetActive(false);
        scalper.SetActive(true);
    }

    void Wait15SecSuccess()
    {
        success.SetActive(false);
    }
}
