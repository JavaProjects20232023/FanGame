using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Money : MonoBehaviour
{
    Level level;
    JsonManager json;

    void Start()
    {
       StartCoroutine(Mo());
       json = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
       level = GameObject.Find("GameManager").GetComponent<Level>();
    }

    IEnumerator Mo()
    {
        while(true) {
            yield return new WaitForSeconds(1);
            User.coin += json.autos[level.AutoLevel].GetMoney;
        }
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown (0)) {
            if(!EventSystem.current.IsPointerOverGameObject()) {
                User.coin += json.clicks[level.ClickLevel].GetMoney;
            }
        }
    }
}