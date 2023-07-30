using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollLevelText : MonoBehaviour
{
    public Text text;

    Level level;

    void Start()
    {
        level = GameObject.Find("GameManager").GetComponent<Level>();
    }

    void Update()
    {
        text.text = "Lv. " + level.AutoLevel.ToString();
    }
}