using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WifiLevelText : MonoBehaviour
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
        text1.text = "Lv. " + User.count_probability;
        text2.text = json.wifis[User.count_probability + 1].NeedMoney + "¿ø";
        text3.text = Mathf.Floor((float)User.probability * 10f) / 10f + "%";
    }
}
