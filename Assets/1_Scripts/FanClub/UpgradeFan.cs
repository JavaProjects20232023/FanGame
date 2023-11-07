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
    private Money money;
    private int count = 0;
    private bool minusOn = false;

    void Start()
    {
        jsonManager = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
        dayMonth = GameObject.Find("DayMonth").GetComponent<DayMonth>();
        money = GameObject.Find("Gold").GetComponent<Money>();
    }

    void Update()
    {
        if (dayMonth.fan == true)
        {
            if ( jsonManager.fan[count].MonthMoney > money.coin)
            {
                if (count == 5)
                {
                    FanGrade[count-1].GetComponent<Button>().enabled = true;
                    Check[count-1].SetActive(false);
                    NeedMoney[count-1].SetActive(true);
                    MonthMoney[count-1].SetActive(false);
                    count--;
                }
                else
                {
                    FanGrade[count].GetComponent<Button>().interactable = false;
                    count--;
                    FanGrade[count].GetComponent<Button>().enabled = true;
                    Check[count].SetActive(false);
                    NeedMoney[count].SetActive(true);
                    MonthMoney[count].SetActive(false);
                }
                Debug.Log("°¨¼Ò");
            }
            else
            {
                if (count != 0)
                {
                    money.coin -= jsonManager.fan[count].MonthMoney;
                }
            }
            dayMonth.fan = false;
        }
    }

    public void Upgrade()
    {
        Debug.Log(count);
        if (money.coin < jsonManager.fan[count].NeedMoney)
        {
            warning.SetActive(true);
            Invoke("Wait", 1.5f);
        }
        else
        {
            money.coin -= jsonManager.fan[count].NeedMoney;
            FanGrade[count].GetComponent<Button>().enabled = false;
            Check[count].SetActive(true);
            NeedMoney[count].SetActive(false);
            MonthMoney[count].SetActive(true);
            count++;
            if (FanGrade.Length != count)
            {
                FanGrade[count].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void Wait()
    {
        warning.SetActive(false);
    }
}
