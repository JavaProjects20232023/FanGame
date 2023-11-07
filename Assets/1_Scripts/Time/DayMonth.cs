using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayMonth : MonoBehaviour
{
    Timer timer;
    public Text text;
    public bool fan = false;
    void Start()
    {
        timer = GameObject.Find("Time").GetComponent<Timer>();
        text.text = User.month.ToString() + "월 " + User.day.ToString() + "일";
        StartCoroutine(Texts());
    }

    IEnumerator Texts()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            User.day++;
            if (User.day > 30)
            {
                User.day = 1;
                User.month++;
                fan = true;
                if (User.month > 12)
                {
                    User.month = 1;
                }
            }
            text.text = User.month.ToString() + "월 " + User.day.ToString() + "일";
        }
    }
}
