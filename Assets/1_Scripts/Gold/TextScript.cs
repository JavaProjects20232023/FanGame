using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        text.text = ConvertNumberToText(User.coin) + "원";
    }

    string ConvertNumberToText(long number)
    {
        if (number == 0)
        {
            return "0";
        }

        string[] unitNames = { "", "만", "억", "조" };
        string result = "";
        int unitIndex = 0;

        while (number > 0)
        {
            int group = (int)(number % 10000);
            if (group > 0)
            {
                result = ConvertGroupToText(group) + unitNames[unitIndex] + result;
            }

            number /= 10000;
            unitIndex++;
        }

        return result;
    }

    string ConvertGroupToText(int group)
    {
        if (group == 0)
        {
            return "";
        }

        string groupText = group.ToString();
        return groupText;
    }
}