using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    [SerializeField]
    private GameObject[] storyObjects;
    [SerializeField]
    private GameObject warning;

    private JsonManager json;
    void Start()
    {
        json = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
        for (int i = User.StoryCount + 1; i <storyObjects.Length; i++)
        {
            storyObjects[i].SetActive(false);
        }
        for (int i = 0; i < User.StoryCount; i++)
        {
            storyObjects[i].GetComponent<Button>().interactable = false;
            User.likeAbility += json.storis[i].GetLikeAbility;
            User.probability += json.storis[i].GetProbability;
        }
    }

    void Update()
    {
        
    }

    public void Upgrade()
    {
        if (User.StoryCount != storyObjects.Length - 1)
        {
            Debug.Log(json.storis[User.StoryCount].GetLikeAbility);
            Debug.Log(json.storis[User.StoryCount].GetProbability);
            if (json.storis[User.StoryCount].NeedA > User.fanmeetingA || json.storis[User.StoryCount].NeedB > User.fanmeetingB 
                || json.storis[User.StoryCount].NeedC > User.fanmeetingC || json.storis[User.StoryCount].NeedLike > User.likeAbility)
            {
                warning.SetActive(true);
                Invoke("wait", 1.5f);

            }
            else
            {
                storyObjects[User.StoryCount].GetComponent<Button>().interactable = false;
                User.likeAbility += json.storis[User.StoryCount].GetLikeAbility;
                User.probability += json.storis[User.StoryCount].GetProbability;
                User.StoryCount++;
                storyObjects[User.StoryCount].SetActive(true);
            }
        }
        else
        {
            storyObjects[User.StoryCount].GetComponent<Button>().interactable = false;
            Debug.Log("엔딩임 우와아아아앙");
        }
        
    }

    public void wait()
    {
        warning.SetActive(false);
    }
}
