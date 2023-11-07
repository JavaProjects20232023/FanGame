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

    private Level level;

    private int count = 0;
    void Start()
    {
        for (int i = 0; i < electroncisUpgrade.Length; i++)
        {
            electroncisUpgrade[i].GetComponent<ElectronisController>();
            electroncis[i].GetComponent<ElectronisController>();
        }
        level = GameObject.Find("GameManager").GetComponent<Level>();
    }

    void Update()
    {

    }

    public void ElectronicUpgrade()
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
        count++;
        User.probability += 0.5f;
    }
}
