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
    void Start()
    {
        jsonManager = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
        for (int i = User.ItemCount + 1; i < electroncis.Length; i++)
        {
            electroncisUpgrade[i].GetComponent<Button>().interactable = false;
        }
        for (int i = 0; i < User.ItemCount; i++)
        {
            electroncisUpgrade[i].GetComponent<Button>().enabled = false;
            electroncis[i].SetActive(true);
            User.probability += jsonManager.electronics[i].Plus;
        }
    }

    void Update()
    {

    }

    public void ElectronicUpgrade()
    {
        if (User.coin < jsonManager.electronics[User.ItemCount].NeedMoney)
        {
            warning.SetActive(true);
            Invoke("Wait", 1.5f);
        }
        else
        {
            electroncisUpgrade[User.ItemCount].GetComponent<Button>().enabled = false;
            if (User.ItemCount == electroncis.Length - 1)
            {
                electroncis[electroncis.Length - 1].SetActive(true);
            }
            else
            {
                electroncisUpgrade[User.ItemCount + 1].GetComponent<Button>().interactable = true;
                electroncis[User.ItemCount].SetActive(true);
            }
            User.coin -= jsonManager.electronics[User.ItemCount].NeedMoney;
            User.probability += jsonManager.electronics[User.ItemCount].Plus;
            User.ItemCount++;
        }
    }

    public void Wait()
    {
        warning.SetActive(false);
    }
}
