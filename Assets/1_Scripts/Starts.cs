using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Starts : MonoBehaviour
{
    public GameObject newmodal;
    public Text nametext;
    // Start is called before the first frame update
    void Awake()
    {
        
    }


    private IEnumerator Startgame()
    {
        yield return StartCoroutine(Save.instance.LoadInfo());

        // ���̵�ƿ� �ؼ� �Ѿ�� �� ��
        SceneManager.LoadScene("Game");
    }

    public IEnumerator Do()
    {
        yield return StartCoroutine(Save.instance.LoadInfo());
        if (User.name == "")
        {
            newmodal.SetActive(true);
        }
        else
        {
            StartCoroutine(Startgame());
        }
    }

    public void PressYes()
    {
        StartCoroutine(Do());
    }

    public void RegistYes()
    {
        if (nametext.text != "")
        {
            User.name = nametext.text;
        }
        StartCoroutine(Save.instance.SaveInfo());
        StartCoroutine(Startgame());
    }

    public void PressNo()
    {
        Debug.Log("���� ������ ������� ����");
        Application.Quit();
    }
}
