using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int ClickLevel = 0;
    public int AutoLevel = 0;
    public int TicketLevel = 0;
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
        if(User.coin >= json.clicks[ClickLevel+1].NeedMoney) {
            User.coin = User.coin - json.clicks[ClickLevel+1].NeedMoney;
            ClickLevel++;
        }
        else {
            Debug.Log("돈이 부족합니다.");
            Warning.SetActive(true);
            Invoke("Wait15Sec", 1.5f);
        }
    }

    public void AutoMoney()
    {
        if(User.coin >= json.autos[AutoLevel+1].NeedMoney) {
            User.coin = User.coin - json.autos[AutoLevel+1].NeedMoney;
            AutoLevel++;
        }
        else {
            Debug.Log("돈이 부족합니다.");
            Warning.SetActive(true);
            Invoke("Wait15Sec", 1.5f);
        }
    }

    public void Ticketing()
    {
        if(User.coin >= json.wifis[TicketLevel+1].NeedMoney) {
            TicketLevel++;
            User.coin = User.coin - json.wifis[TicketLevel].NeedMoney;
            User.probability += json.wifis[TicketLevel].Probility;
        }
        else {
            Debug.Log("돈이 부족합니다.");
            Warning.SetActive(true);
            Invoke("Wait15Sec", 1.5f);
        }
    }
}
