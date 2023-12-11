using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField]
    private GameObject status;
    [SerializeField]
    private Text username;
    [SerializeField]
    private Text day;
    [SerializeField]
    private Text month;
    [SerializeField]
    private Text money;
    [SerializeField]
    private Text fanmeetingA;
    [SerializeField]
    private Text fanmeetingB;
    [SerializeField]
    private Text fanmeetingC;
    [SerializeField]
    private Text likeability;
    [SerializeField]
    private Text probability;

    private void Start()
    {
        
    }

    private void Update()
    {
        month.text = User.month.ToString() + "월";
        day.text = User.day.ToString() + "일";
        username.text = "이름: " + User.name;
        money.text = "돈: " + ConvertNumberToText(User.coin) + "원";
        fanmeetingA.text = "A등급 팬미팅 횟수: " + User.fanmeetingA.ToString() + "회";
        fanmeetingB.text = "B등급 팬미팅 횟수: " + User.fanmeetingB.ToString() + "회";
        fanmeetingC.text = "C등급 팬미팅 횟수: " + User.fanmeetingC.ToString() + "회";
        likeability.text = "호감도: " + User.likeAbility.ToString() + "%";
        probability.text = "확률: " + Mathf.Floor((float)User.probability * 10f) / 10f + "%";
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

    public void OpenStatus()
    {
        status.SetActive(true);
    }

    public void CloseStatus()
    {
        status.SetActive(false);
    }
}
