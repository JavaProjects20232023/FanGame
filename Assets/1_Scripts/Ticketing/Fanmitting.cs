using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanmitting : MonoBehaviour
{
    public GameObject[] fanmtting;

    private int spawn;
    public int count = 0;
    private int setting;
    int k = 0;
    bool lockcon = false;
    bool lockcon2 = false;

    private DayMonth dayMonth;

    void Start()
    {
        dayMonth = GameObject.Find("DayMonth").GetComponent<DayMonth>();
    }

    private void Update()
    {
        if(dayMonth.month == 1 && !lockcon2)
        {
            lockcon = false;
        }
        if (dayMonth.month == 2)
        {
            lockcon2 = false;
            for (int i = 0; i < fanmtting.Length; i++)
            {
                fanmtting[i].SetActive(false);
            }
        }

        if (!lockcon)
        {
            k = Random.Range(0, fanmtting.Length);
            fanmtting[k].SetActive(true);
            
            for (int i = 0; i < fanmtting.Length; i++)
            {
                if (i != k)
                {
                    fanmtting[i].SetActive(false);
                }
            }

            lockcon = true;
            lockcon2 = true;
        }
    }
}