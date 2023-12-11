using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanMeetingLock : MonoBehaviour
{
    [SerializeField]
    private Button fan;

    private void Start()
    {
        fan.interactable = true;
    }

    public void OnClick()
    {
        fan.interactable = false;
    }
}
