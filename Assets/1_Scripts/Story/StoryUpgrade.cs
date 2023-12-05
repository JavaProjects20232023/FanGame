using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUpgrade : MonoBehaviour
{
    [SerializeField]
    private Text a;
    [SerializeField]
    private Text b;
    [SerializeField]
    private Text c;
    [SerializeField]
    private Text like;
    [SerializeField]
    private int count;

    private JsonManager json;
    // Start is called before the first frame update
    void Start()
    {
        json = GameObject.Find("LevelUpManager").GetComponent<JsonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (User.fanmeetingA < json.storis[count].NeedA)
        {
            a.text = "<color=#ff0000>" + json.storis[count].NeedA + "회" + "</color>";
        }
        else
        {
            a.text = json.storis[count].NeedA.ToString() + "회";
        }

        if (User.fanmeetingB < json.storis[count].NeedB)
        {
            b.text = "<color=#ff0000>" + json.storis[count].NeedB + "회" + "</color>";
        }
        else
        {
            b.text = json.storis[count].NeedB.ToString() + "회";
        }

        if (User.fanmeetingC < json.storis[count].NeedC)
        {
            c.text = "<color=#ff0000>" + json.storis[count].NeedC + "회" + "</color>";
        }
        else
        {
            c.text = json.storis[count].NeedC.ToString() + "회";
        }

        if (User.likeAbility < json.storis[count].NeedLike)
        {
            like.text = "<color=#ff0000>" + json.storis[count].NeedLike + "%" + "</color>";
        }
        else
        {
            like.text = json.storis[count].NeedLike.ToString() + "%";
        }
    }
}
