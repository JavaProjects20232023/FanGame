using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressYes()
    {
        SceneManager.LoadScene("Game");
        // 페이드아웃 해서 넘어가게 해 줘
    }

    public void PressNo()
    {
        Debug.Log("게임 꺼지게 만들어줘 응애");
    }
}
