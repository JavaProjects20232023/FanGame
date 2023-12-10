using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.Text;

public class Save : MonoBehaviour
{
    /*
    
    public static Save instance = null;
    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }

    public string host;
    public string deleteurl;
    public string idurl;
    public string posturl;

    public IEnumerator LoadInfo()
    {
        idurl = User.uuid;
        var url = string.Format("{0}/{1}", host, idurl);
        Debug.Log(url);

        yield return StartCoroutine(this.GetId(url, (raw) =>
        {
            var res = JsonConvert.DeserializeObject<Protocols.Packets.user>(raw);
            User.name = res.name;
            User.coin = res.coin;
            User.fanmeetingA = res.fanmeetingA;
            User.fanmeetingB = res.fanmeetingB;
            User.fanmeetingC = res.fanmeetingC;
            User.likeAbility = res.likeability;
            User.probability = res.probability;
            User.month = res.month;
            User.day = res.day;
            Debug.LogFormat("{0} : {1}", res.uuid, res.name);
        }));
    }

    public IEnumerator SaveInfo()
    {
        var url = string.Format("{0}/{1}", host, posturl);
        Debug.Log(url);

        var req = new Protocols.Packets.user();
        req.uuid = User.uuid;
        req.name = User.name;
        req.coin = User.coin;
        req.fanmeetingA = User.fanmeetingA;
        req.fanmeetingB = User.fanmeetingB;
        req.fanmeetingC = User.fanmeetingC;
        req.likeability = User.likeAbility;
        req.probability = User.probability;
        req.month = User.month;
        req.day = User.day;

        var json = JsonConvert.SerializeObject(req); // Object to string
        Debug.Log(json);

        yield return StartCoroutine(this.GetPost(url, json, (raw) =>
        {
            Protocols.Packets.user res = JsonConvert.DeserializeObject<Protocols.Packets.user>(raw);
            Debug.LogFormat("{0}, {1}", res.uuid, res.name);
        }));
    }

    public IEnumerator DeleteInfo()
    {
        var url = string.Format("{0}/{1}", host, deleteurl);
        Debug.Log(url);

        yield return StartCoroutine(this.GetDelete(url));
    }

    private IEnumerator GetId(string url, System.Action<string> callback)
    {
        var webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        Debug.Log("--->" + webRequest.downloadHandler.text);

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("네트워크 환경이 안좋아서 통신을 할수 없습니다.");
        }
        else
        {
            callback(webRequest.downloadHandler.text);
        }
    }

    private IEnumerator GetPost(string url, string json, System.Action<string> callback)
    {
        var webRequest = new UnityWebRequest(url, "POST");
        var bodyRaw = Encoding.UTF8.GetBytes(json); // string to byte list

        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("네트워크 환경이 안좋아서 통신을 할수 없습니다.");
        }
        else
        {
            Debug.LogFormat("{0}\n{1}\n{2}", webRequest.responseCode, webRequest.downloadHandler.data, webRequest.downloadHandler.text);
            callback(webRequest.downloadHandler.text);
        }

        webRequest.Dispose();
    }

    private IEnumerator GetDelete(string url)
    {
        var webRequest = UnityWebRequest.Delete(url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("네트워크 환경이 안좋아서 통신을 할수 없습니다.");
        }
    }

    */
}