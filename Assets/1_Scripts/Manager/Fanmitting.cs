using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanmitting : MonoBehaviour
{
    public GameObject[] fanmtting;

    private int spawn;
    public int count = 0;
    private int setting;

    public DayMonth dayMonth;

    void Start()
    {
    }

    private void Update()
    {
        int k = 0;
        if (dayMonth.month == 1)
        {
            k = Random.Range(0, fanmtting.Length - 1);
            fanmtting[k].SetActive(true);
        }

        for (int i = 0; i < fanmtting.Length; i++)
        {
            if (i!= k)
            {
                fanmtting[i].SetActive(false);
            }
        }
    }
}