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
    Money money;
    JsonManager json;

    void Start()
    {
        money = GameObject.Find("Gold").GetComponent<Money>();
        json = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
        Warning.SetActive(false);
    }

    void Wait15Sec()
    {
        Warning.SetActive(false);
    }

    public void Click()
    {
        if(money.coin >= json.clicks[ClickLevel+1].NeedMoney) {
            money.coin = money.coin - json.clicks[ClickLevel+1].NeedMoney;
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
        if(money.coin >= json.autos[AutoLevel+1].NeedMoney) {
            money.coin = money.coin - json.autos[AutoLevel+1].NeedMoney;
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
        if(money.coin >= 100) {
            TicketLevel++;
            money.coin = money.coin - 100;
        }
        else {
            Debug.Log("돈이 부족합니다.");
            Warning.SetActive(true);
            Invoke("Wait15Sec", 1.5f);
        }
    }
}
