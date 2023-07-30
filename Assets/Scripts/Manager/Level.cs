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

    void Start()
    {
        money = GameObject.Find("Gold").GetComponent<Money>();
        Warning.SetActive(false);
    }

    public void Click()
    {
        if(money.coin >= 100) {
            ClickLevel++;
            money.coin = money.coin - 100;
        }
        else {
            Debug.Log("돈이 부족합니다.");
            Warning.SetActive(true);
            Invoke("Wait15Sec", 1.5f);
        }
    }

    void Wait15Sec()
    {
        Warning.SetActive(false);
    }

    public void AutoMoney()
    {
        AutoLevel++;
    }

    public void Ticketing()
    {
        TicketLevel++;
    }
}
