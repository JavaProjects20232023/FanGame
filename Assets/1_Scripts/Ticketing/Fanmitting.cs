using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanmitting : MonoBehaviour
{
    public GameObject[] fanmtting;

    int k = 0;
    bool lockcon = false;
    bool lockcon2 = false;

    void Start()
    {
    }

    private void Update()
    {
        if(User.month == 1 && !lockcon2)
        {
            lockcon = false;
        }
        if (User.month == 2)
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