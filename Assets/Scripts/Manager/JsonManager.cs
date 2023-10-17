using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class JsonManager : MonoBehaviour
{
    public Clicks[] clicks = new Clicks[10];
    public Autos[] autos = new Autos[10];

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
