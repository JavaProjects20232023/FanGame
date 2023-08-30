using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollLevelText : MonoBehaviour
{
    public Text text1;
    public Text text2;

    Level level;
    JsonManager json;

    void Start()
    {
        level = GameObject.Find("GameManager").GetComponent<Level>();
        json = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
    }

    void Update()
    {
        text1.text = "Lv. " + level.ClickLevel.ToString();
        text2.text = json.clicks[level.ClickLevel+1].NeedMoney + "원";
    }
}
