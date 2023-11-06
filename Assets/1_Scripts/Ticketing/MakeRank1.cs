using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRank1 : MonoBehaviour
{
    [SerializeField]
    private FanMeetingRank[] rank;

    private void OnEnable()
    {
        for (int i =0; i < rank.Length; i++)
        {
            rank[i].Open();
        }
    }
}
