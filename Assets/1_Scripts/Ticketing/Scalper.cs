using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalper : MonoBehaviour
{
    [SerializeField]
    private GameObject scalper;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Failbuy()
    {
        yield return StartCoroutine(Save.instance.DeleteInfo());
        Application.Quit();
    }

    public void PressYes()
    {
        scalper.SetActive(false);
        Debug.Log("�� �����ʹ� ���� ���İ���.");
        // delete
        StartCoroutine(Failbuy());
    }

    public void PressNo()
    {
        scalper.SetActive(false);
        Debug.Log("�� ����");
    }
}
