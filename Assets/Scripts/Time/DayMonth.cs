using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayMonth : MonoBehaviour
{
    Timer timer;
    public Text text;
    public int month = 1;
    public int day = 1;
    void Start()
    {
        timer = GameObject.Find("Time").GetComponent<Timer>();
        text.text = month.ToString() + "월 " + day.ToString() + "일";
        StartCoroutine(Texts());
    }

    IEnumerator Texts()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            day++;
            if (day > 30)
            {
                day = 1;
                month++;
                if (month > 12)
                {
                    month = 1;
                }
            }
            text.text = month.ToString() + "월 " + day.ToString() + "일";
        }
    }
}
