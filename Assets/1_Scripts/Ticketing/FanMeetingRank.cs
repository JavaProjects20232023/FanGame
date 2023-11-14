using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanMeetingRank : MonoBehaviour
{
    [SerializeField]
    private Text Rank;
    [SerializeField]
    private Text TicketPrice;
    [SerializeField]
    private Probability probability;
    [SerializeField]
    private FanMeetingLock fanMeetingLock;
    [SerializeField]
    private GameObject warning;

    private char[] rank = { 'A', 'B', 'C' };

    private int a;

    private void Start()
    {
    }

    private void Update()
    {
        
    }

    public void Open()
    {
        int k = Random.Range(1, 101);
        Debug.Log(k);
        if ( k <= 10)
        {
            Rank.text = rank[0].ToString();
            Price(rank[0]);
            a = 0;
        }
        else if (k <= 40)
        {
            Rank.text = rank[1].ToString();
            Price(rank[1]);
            a = 1;
        }
        else
        {
            Rank.text = rank[2].ToString();
            Price(rank[2]);
            a = 2;
        }

    }

    private void Price(char k)
    {
        if (k == rank[0]) TicketPrice.text = "30만원";
        else if (k == rank[1]) TicketPrice.text = "20만원";
        else TicketPrice.text = "10만원";
    }

    public void BuyTicket()
    {
        if (a == 0)
        {
            if (User.coin > 300000)
            {
                User.coin -= 300000;
                fanMeetingLock.OnClick();
                probability.Fan();
                if (probability.succes)
                {
                    User.fanmeetingA++;
                    probability.succes = false;
                }
            }
            else
            {
                warning.SetActive(true);
                Invoke("Wait", 1.5f);
            }
        }
        else if (a == 1)
        {
            if (User.coin > 200000)
            {
                User.coin -= 200000;
                fanMeetingLock.OnClick();
                probability.Fan();
                if (probability.succes)
                {
                    User.fanmeetingB++;
                    probability.succes = false;
                }

            }
            else
            {
                warning.SetActive(true);
                Invoke("Wait", 1.5f);
            }
        }
        else if (a == 2)
        {
            if (User.coin > 100000)
            {
                User.coin -= 100000;
                fanMeetingLock.OnClick();
                probability.Fan();
                if (probability.succes)
                {
                    User.fanmeetingC++;
                    probability.succes = false;
                }

            }
            else
            {
                warning.SetActive(true);
                Invoke("Wait", 1.5f);
            }
        }
    }

    void Wait()
    {
        warning.SetActive(false);
    }
}
