using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeFan : MonoBehaviour
{
    [SerializeField]
    private GameObject[] FanGrade;
    [SerializeField]
    private GameObject[] Check;
    [SerializeField]
    private GameObject[] NeedMoney;
    [SerializeField]
    private GameObject[] MonthMoney;
    [SerializeField]
    private GameObject warning;

    private JsonManager jsonManager;
    private DayMonth dayMonth;


    void Start()
    {
        jsonManager = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
        dayMonth = GameObject.Find("DayMonth").GetComponent<DayMonth>();
        for (int i = User.FanclubCount + 1; i < FanGrade.Length; i++)
        {
            FanGrade[i].GetComponent<Button>().interactable = false;
        }
        for (int i = 0; i < User.FanclubCount; i++)
        {
            FanGrade[i].GetComponent<Button>().enabled = false;
            Check[i].SetActive(true);
            NeedMoney[i].SetActive(false);
            MonthMoney[i].SetActive(true);
        }
    }

    void Update()
    {
        if (dayMonth.fan == true)
        {
            if ( jsonManager.fan[User.FanclubCount].MonthMoney > User.coin)
            {
                if (User.FanclubCount == 5)
                {
                    FanGrade[User.FanclubCount - 1].GetComponent<Button>().enabled = true;
                    Check[User.FanclubCount - 1].SetActive(false);
                    NeedMoney[User.FanclubCount - 1].SetActive(true);
                    MonthMoney[User.FanclubCount - 1].SetActive(false);
                    User.FanclubCount--;
                }
                else
                {
                    FanGrade[User.FanclubCount].GetComponent<Button>().interactable = false;
                    User.FanclubCount--;
                    FanGrade[User.FanclubCount].GetComponent<Button>().enabled = true;
                    Check[User.FanclubCount].SetActive(false);
                    NeedMoney[User.FanclubCount].SetActive(true);
                    MonthMoney[User.FanclubCount].SetActive(false);
                }
                Debug.Log("감소");
            }
            else
            {
                if (User.FanclubCount != 0)
                {
                    User.coin -= jsonManager.fan[User.FanclubCount].MonthMoney;
                }
            }
            dayMonth.fan = false;
        }
    }

    public void Upgrade()
    {
        Debug.Log(User.FanclubCount);
        if (User.coin < jsonManager.fan[User.FanclubCount].NeedMoney)
        {
            warning.SetActive(true);
            Invoke("Wait", 1.5f);
        }
        else
        {
            User.coin -= jsonManager.fan[User.FanclubCount].NeedMoney;
            FanGrade[User.FanclubCount].GetComponent<Button>().enabled = false;
            Check[User.FanclubCount].SetActive(true);
            NeedMoney[User.FanclubCount].SetActive(false);
            MonthMoney[User.FanclubCount].SetActive(true);
            User.FanclubCount++;
            if (FanGrade.Length != User.FanclubCount)
            {
                FanGrade[User.FanclubCount].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void Wait()
    {
        warning.SetActive(false);
    }
}
