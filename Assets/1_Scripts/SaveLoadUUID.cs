using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class SaveData
{
    public string uuid; // private면 좋아요
    public SaveData(string uuid)
    {
        this.uuid = uuid;
    }
}

public static class SaveSystem // save location -> C:\Users\{username}\AppData\LocalLow\{addition_location}
{
    public static string SavePath => Application.persistentDataPath + "/saves/";
    private static string encryptionCodeWord = "SoloGame";
    // private static bool useEncryption = true;


    public static void Save(SaveData saveData, string saveFileName, bool useEncryption)
    {
        if (!Directory.Exists(SavePath)) // 존재하지 않으면 새로 만들어준다.
        {
            Directory.CreateDirectory(SavePath);
        }

        if (saveData.uuid == "")
        {
            string s = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < 32; i++)
            {
                int k = Random.Range(0, s.Length);
                saveData.uuid += s[k];
            }
        }

        string saveJson = JsonUtility.ToJson(saveData);
        if (useEncryption)
        {
            saveJson = EncryptDecrypt(saveJson);
        }

        string saveFilePath = SavePath + saveFileName + ".json";

        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("Save Success: " + saveFilePath);
    }

    public static SaveData Load(string saveFileName, bool useEncryption)
    {
        string saveFilePath = SavePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.LogError("No such saveFile exists");
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        if (useEncryption)
        {
            saveFile = EncryptDecrypt(saveFile);
        }
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
        return saveData;
    }

    public static string EncryptDecrypt(string saveJson)
    {
        string modified = "";

        for (int i = 0; i < saveJson.Length; i++)
        {
            modified += (char)(saveJson[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }

        return modified;
    }
}

public class SaveLoadUUID : MonoBehaviour
{
    [Header("Notice: If doesn't work, change encryption mode")]
    [SerializeField]
    private bool useEncryption = true;
    void Start()
    {
        if (!File.Exists(SaveSystem.SavePath + "uuidinfo" + ".json"))
        {
            Save();
        }
        Load();
    }
    void Update()
    {
        /*
        if (Input.GetKeyDown("s"))
        {
            Save();
        }
        if (Input.GetKeyDown("l"))
        {
            Load();
        }*/
    }

    void Save()
    {
        SaveData character = new SaveData(User.uuid);
        SaveSystem.Save(character, "uuidInfo", useEncryption);
    }

    void Load()
    {
        SaveData loadData = SaveSystem.Load("uuidInfo", useEncryption);
        if (loadData != null)
        {
            User.uuid = loadData.uuid;// 유저 uuid에 대입
        }
    }
}