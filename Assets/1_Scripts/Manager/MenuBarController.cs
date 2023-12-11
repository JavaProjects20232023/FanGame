using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBarController : MonoBehaviour
{
    public GameObject menuBar; // 메뉴바를 나타내는 게임 오브젝트를 인스펙터에서 지정해줍니다.
    public GameObject ItemMenu1;
    public GameObject ItemMenu2;
    public GameObject ItemMenu3;
    public GameObject ItemMenu4;
    public GameObject ItemMenu5;

    void Strat()
    {
        menuBar.SetActive(false);
    }

    public void UpButton()
    {
        menuBar.SetActive(true);
        ItemMenu_1();
    }

    public void DownButton()
    {
        menuBar.SetActive(false);
        GL.Clear(true, true, Color.black);
    }

    public void ItemMenu_1()
    {
        ItemMenu1.SetActive(true);
        ItemMenu2.SetActive(false);
        ItemMenu3.SetActive(false);
        ItemMenu4.SetActive(false);
        ItemMenu5.SetActive(false);
    }
    public void ItemMenu_2()
    {
        ItemMenu1.SetActive(false);
        ItemMenu2.SetActive(true);
        ItemMenu3.SetActive(false);
        ItemMenu4.SetActive(false);
        ItemMenu5.SetActive(false);
    }
    public void ItemMenu_3()
    {
        ItemMenu1.SetActive(false);
        ItemMenu2.SetActive(false);
        ItemMenu3.SetActive(true);
        ItemMenu4.SetActive(false);
        ItemMenu5.SetActive(false);
    }
    public void ItemMenu_4()
    {
        ItemMenu1.SetActive(false);
        ItemMenu2.SetActive(false);
        ItemMenu3.SetActive(false);
        ItemMenu4.SetActive(true);
        ItemMenu5.SetActive(false);
    }
    public void ItemMenu_5()
    {
        ItemMenu1.SetActive(false);
        ItemMenu2.SetActive(false);
        ItemMenu3.SetActive(false);
        ItemMenu4.SetActive(false);
        ItemMenu5.SetActive(true);
    }
}
