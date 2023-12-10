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


    private void Startgame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Do()
    {
        if (User.name == "")
        {
            newmodal.SetActive(true);
        }
        else
        {
            SaveLoad.instance.Load();
            Startgame();
        }
    }

    public void PressYes()
    {
        Do();
    }

    public void RegistYes()
    {
        if (nametext.text != "")
        {
            User.name = nametext.text;
            SaveLoad.instance.Save();
            Startgame();
        }
    }

    public void PressNo()
    {
        Debug.Log("게임 꺼지게 만들어줘 응애");
        Application.Quit();
    }
}
