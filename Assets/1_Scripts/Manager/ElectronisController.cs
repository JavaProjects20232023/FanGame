using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronisController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] electroncis;
    [SerializeField]
    private GameObject[] electroncisUpgrade;
    [SerializeField]
    private GameObject warning;

    private JsonManager jsonManager;
    private int count = 0;
    void Start()
    {
        for (int i = 0; i < electroncisUpgrade.Length; i++)
        {
            electroncisUpgrade[i].GetComponent<ElectronisController>();
            electroncis[i].GetComponent<ElectronisController>();
        }
        jsonManager = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
    }

    void Update()
    {

    }

    public void ElectronicUpgrade()
    {
        if (User.coin < jsonManager.electronics[count].NeedMoney)
        {
            warning.SetActive(true);
            Invoke("Wait", 1.5f);
        }
        else
        {
            electroncisUpgrade[count].GetComponent<Button>().enabled = false;
            if (count == electroncis.Length - 1)
            {
                electroncis[0].SetActive(false);
                electroncis[electroncis.Length - 1].SetActive(true);
            }
            else
            {
                electroncisUpgrade[count + 1].GetComponent<Button>().interactable = true;
                electroncis[count].SetActive(true);
            }
            User.coin -= jsonManager.electronics[count].NeedMoney;
            User.probability += jsonManager.electronics[count].Plus;
            count++;
        }
    }

    public void Wait()
    {
        warning.SetActive(false);
    }
}
