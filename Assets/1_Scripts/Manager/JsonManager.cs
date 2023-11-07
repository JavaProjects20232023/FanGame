using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Clicks
{
    public int NeedMoney;
    public int GetMoney;

    public static implicit operator int(Clicks v)
    {
        throw new NotImplementedException();
    }
}

[System.Serializable]
public class Autos
{
    public int NeedMoney;
    public int GetMoney;

    public static implicit operator int(Autos w)
    {
        throw new NotImplementedException();
    }
}

[System.Serializable]
public class Wifis
{
    public int NeedMoney;
    public float Probility;

    public static implicit operator int(Wifis y)
    {
        throw new NotImplementedException();
    }
}
[System.Serializable]
public class Fan
{
    public int NeedMoney;
    public int MonthMoney;

    public static implicit operator int(Fan z)
    {
        throw new NotImplementedException();
    }
}

public class JsonManager : MonoBehaviour
{
    public Clicks[] clicks = new Clicks[10];
    public Autos[] autos = new Autos[10];
    public Wifis[] wifis = new Wifis[10];
    public Fan[] fan = new Fan[5];
}
