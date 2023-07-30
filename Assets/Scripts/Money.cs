using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Money : MonoBehaviour
{
    public int coin = 0;
    public int coinLevel = 0;
    public int autolevel = 0;
    public int addcoin = 10;

    void Start()
    {
       StartCoroutine(Mo());
    }

    IEnumerator Mo()
    {
        while(true) {
            yield return new WaitForSeconds(1);
            coin += addcoin * autolevel;
        }
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown (0)) {
            if(!EventSystem.current.IsPointerOverGameObject()) {
                coin++;
            }
        }
    }
}