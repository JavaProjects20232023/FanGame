using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject Warning;
    private float timer;
    JsonManager json;

    void Start()
    {
        json = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
        Warning.SetActive(false);
    }

    void Wait15Sec()
    {
        Warning.SetActive(false);
    }

    public void Click()
    {
        if(User.coin >= json.clicks[User.ClickLevel+1].NeedMoney) {
            User.coin = User.coin - json.clicks[User.ClickLevel +1].NeedMoney;
            User.ClickLevel++;
        }
        else {
            Debug.Log("돈이 부족합니다.");
            Warning.SetActive(true);
            Invoke("Wait15Sec", 1.5f);
        }
    }

    public void AutoMoney()
    {
        if(User.coin >= json.autos[User.AutoLevel +1].NeedMoney) {
            User.coin = User.coin - json.autos[User.AutoLevel +1].NeedMoney;
            User.AutoLevel++;
        }
        else {
            Debug.Log("돈이 부족합니다.");
            Warning.SetActive(true);
            Invoke("Wait15Sec", 1.5f);
        }
    }

    public void Ticketing()
    {
        if(User.coin >= json.wifis[User.count_probability +1].NeedMoney) {
            User.count_probability++;
            User.coin = User.coin - json.wifis[User.count_probability].NeedMoney;
            User.probability += json.wifis[User.count_probability].Probility;
        }
        else {
            Debug.Log("돈이 부족합니다.");
            Warning.SetActive(true);
            Invoke("Wait15Sec", 1.5f);
        }
    }
}
