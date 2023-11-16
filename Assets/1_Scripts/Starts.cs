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

        // 페이드아웃 해서 넘어가게 해 줘
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
        Debug.Log("게임 꺼지게 만들어줘 응애");
        Application.Quit();
    }
}
