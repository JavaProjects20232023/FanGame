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

    public void PressYes()
    {
        scalper.SetActive(false);
        Debug.Log("니 데이터는 내가 훔쳐간다.");
    }

    public void PressNo()
    {
        scalper.SetActive(false);
        Debug.Log("아 노잼");
    }
}
