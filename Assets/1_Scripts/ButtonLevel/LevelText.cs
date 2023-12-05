using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
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
        text1.text = "Lv. " + User.ClickLevel;
        text2.text = json.clicks[User.ClickLevel+1].NeedMoney + "원";
        text3.text = json.clicks[User.ClickLevel].GetMoney + "원";
    }
}
