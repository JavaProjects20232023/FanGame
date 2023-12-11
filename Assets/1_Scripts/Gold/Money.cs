using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Money : MonoBehaviour
{
    JsonManager json;

    void Start()
    {
       StartCoroutine(Mo());
       json = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
    }

    IEnumerator Mo()
    {
        while(true) {
            yield return new WaitForSeconds(1);
            User.coin += json.autos[User.AutoLevel].GetMoney;
        }
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown (0)) {
            if(!EventSystem.current.IsPointerOverGameObject()) {
                User.coin += json.clicks[User.ClickLevel].GetMoney;
            }
        }
    }
}