using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollLevelText : MonoBehaviour
{
    [SerializeField]
    private Text text1;
    [SerializeField]
    private Text text2;
    [SerializeField]
    private Text text3;

    Level level;
    JsonManager json;

    void Start()
    {
        level = GameObject.Find("GameManager").GetComponent<Level>();
        json = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
    }

    void Update()
    {
        text1.text = "Lv. " + level.AutoLevel;
        text2.text = json.autos[level.AutoLevel+1].NeedMoney + "원";
        text3.text = json.autos[level.AutoLevel].GetMoney + "원";
    }
}
