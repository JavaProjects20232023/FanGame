using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanmitting : MonoBehaviour
{
    public GameObject fanmtting;

    void Start()
    {
        fanmtting.SetActive(false);
        Invoke("RandomFanMitting", 10f);
    }

    void RandomFanMitting()
    {
        Debug.Log("나타남");
        fanmtting.SetActive(true);
        Invoke("EndFanMitting", 10f);
    }

    void EndFanMitting()
    {
        Debug.Log("사라짐");
        fanmtting.SetActive(false);
    }
}