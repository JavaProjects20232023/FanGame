using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static SaveData;
using Random = UnityEngine.Random;

[System.Serializable]
public class SaveData
{
    public string id;
    public string name;
    public int coin;
    public int fanmeetingA;
    public int fanmeetingB;
    public int fanmeetingC;
    public int likeAbility;
    public int day;
    public int month;
    public double probability;
    public int ClickLevel;
    public int AutoLevel;
    public int count_probability;
    public int ItemCount;
    public int StoryCount;
    public int FanclubCount;

    public class SaveDataBuilder
    {
        private SaveData saveData;

        public SaveDataBuilder()
        {
            saveData = new SaveData();
        }

        public SaveDataBuilder WithId(string id)
        {
            saveData.id = id;
            return this;
        }

        public SaveDataBuilder WithName(string name)
        {
            saveData.name = name;
            return this;
        }

        public SaveDataBuilder WithCoin(int coin)
        {
            saveData.coin = coin;
            return this;
        }

        public SaveDataBuilder WithFanmeetingA(int fanmeetingA)
        {
            saveData.fanmeetingA = fanmeetingA;
            return this;
        }

        public SaveDataBuilder WithFanmeetingB(int fanmeetingB)
        {
            saveData.fanmeetingB = fanmeetingB;
            return this;
        }

        public SaveDataBuilder WithFanmeetingC(int fanmeetingC)
        {
            saveData.fanmeetingC = fanmeetingC;
            return this;
        }

        public SaveDataBuilder WithLikeAbility(int likeAbility)
        {
            saveData.likeAbility = likeAbility;
            return this;
        }

        public SaveDataBuilder WithDay(int day)
        {
            saveData.day = day;
            return this;
        }

        public SaveDataBuilder WithMonth(int month)
        {
            saveData.month = month;
            return this;
        }

        public SaveDataBuilder WithProbability(double probability)
        {
            saveData.probability = probability;
            return this;
        }

        public SaveDataBuilder WithClickLevel(int clickLevel)
        {
            saveData.ClickLevel = clickLevel;
            return this;
        }

        public SaveDataBuilder WithAutoLevel(int autoLevel)
        {
            saveData.AutoLevel = autoLevel;
            return this;
        }

        public SaveDataBuilder WithCountProbability(int countProbability)
        {
            saveData.count_probability = countProbability;
            return this;
        }

        public SaveDataBuilder WithItemCount(int itemCount)
        {
            saveData.ItemCount = itemCount;
            return this;
        }

        public SaveDataBuilder WithStoryCount(int storyCount)
        {
            saveData.StoryCount = storyCount;
            return this;
        }

        public SaveDataBuilder WithFanclubCount(int fanclubCount)
        {
            saveData.FanclubCount = fanclubCount;
            return this;
        }

        // 최종적으로 SaveData 인스턴스를 반환
        public SaveData Build()
        {
            return saveData;
        }
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

    public static void Delete(string saveFileName)
    {
        File.Delete(saveFileName+"userinfo.json");
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

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    [Header("Notice: If doesn't work, change encryption mode")]
    [SerializeField]
    private bool useEncryption = true;
    void Start()
    {
        if (File.Exists(SaveSystem.SavePath + "userinfo" + ".json"))
        {
            Load();
        }
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

    public void Delete()
    {
        SaveSystem.Delete(SaveSystem.SavePath);
    }

    public void Save()
    {
        SaveData character = new SaveDataBuilder()
                            .WithId(User.id)
                            .WithName(User.name)
                            .WithCoin(User.coin)
                            .WithFanmeetingA(User.fanmeetingA)
                            .WithFanmeetingB(User.fanmeetingB)
                            .WithFanmeetingC(User.fanmeetingC)
                            .WithLikeAbility(User.likeAbility)
                            .WithDay(User.day)
                            .WithMonth(User.month)
                            .WithProbability(User.probability)
                            .WithClickLevel(User.ClickLevel)
                            .WithAutoLevel(User.AutoLevel)
                            .WithCountProbability(User.count_probability)
                            .WithItemCount(User.ItemCount)
                            .WithStoryCount(User.StoryCount)
                            .WithFanclubCount(User.FanclubCount)
                            .Build();
        SaveSystem.Save(character, "userinfo", useEncryption);
    }

    public void Load()
    {
        SaveData loadData = SaveSystem.Load("userinfo", useEncryption);
        if (loadData != null)
        {
            User.id = loadData.id;
            User.name = loadData.name;
            User.coin = loadData.coin;
            User.fanmeetingA = loadData.fanmeetingA;
            User.fanmeetingB = loadData.fanmeetingB;
            User.fanmeetingC = loadData.fanmeetingC;
            User.likeAbility = loadData.likeAbility;
            User.day = loadData.day;
            User.month = loadData.month;
            User.probability = loadData.probability;
            User.ClickLevel = loadData.ClickLevel;
            User.AutoLevel = loadData.AutoLevel;
            User.count_probability = loadData.count_probability;
            User.ItemCount = loadData.ItemCount;
            User.StoryCount = loadData.StoryCount;
            User.FanclubCount = loadData.FanclubCount;
        }
    }
}