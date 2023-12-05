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
        month.text = User.month.ToString() + "��";
        day.text = User.day.ToString() + "��";
        username.text = "�̸�: " + User.name;
        money.text = "��: " + ConvertNumberToText(User.coin) + "��";
        fanmeetingA.text = "A��� �ҹ��� Ƚ��: " + User.fanmeetingA.ToString() + "ȸ";
        fanmeetingB.text = "B��� �ҹ��� Ƚ��: " + User.fanmeetingB.ToString() + "ȸ";
        fanmeetingC.text = "C��� �ҹ��� Ƚ��: " + User.fanmeetingC.ToString() + "ȸ";
        likeability.text = "ȣ����: " + User.likeAbility.ToString() + "%";
        probability.text = "Ȯ��: " + Mathf.Floor((float)User.probability * 10f) / 10f + "%";
    }

    string ConvertNumberToText(long number)
    {
        if (number == 0)
        {
            return "0";
        }

        string[] unitNames = { "", "��", "��", "��" };
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
