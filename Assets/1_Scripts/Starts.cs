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
        // ���̵�ƿ� �ؼ� �Ѿ�� �� ��
    }

    public void PressNo()
    {
        Debug.Log("���� ������ ������� ����");
    }
}
