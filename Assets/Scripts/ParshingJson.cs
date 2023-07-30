using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class ParsingJson : MonoBehaviour
{
    void Start()
    {
        string filePath = "Assets/Balance/PlayerTouch.json";
        string json = File.ReadAllText(filePath);
    }
}