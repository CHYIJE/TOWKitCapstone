using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Getexplain : MonoBehaviour
{
    private string apiBaseUrl = "http://kitcomputer.kr:5200/unity/";
    public List<ExplainData> explainList = new List<ExplainData>();
    public Text objexplaintext;
    public string selectprocess = "믹싱공정"; // 원하는 값을 가져올때 필요.
    public string postProcess = "progress_one"; // 보낼때 필요한 값 믹싱일때 one, 코팅 two, 압연 three, 슬러팅 four
    public int explainnum = 0; // 문제 번호
    // public int postProgress = 1; // 문제별 진행도 할당
    private int postProgress; // 문제별 진행도 할당

    private int test = 0; // 진행도 백분률

    public Button myButton;

    void Start()
    {
        string loggedInUserId = PlayerPrefs.GetString("LoggedInUserId", "No user ID found");
        StartCoroutine(Getobjexplain());
         shareInt.userProgressInt = 0;
        
    }

   public void ProgressUpBtn()
    {
        objexplaintext.text = explainList[explainnum].Explain;
        shareInt.userProgressInt++;
        postProgress = shareInt.userProgressInt;
        test = postProgress * 100 / explainList.Count;
        StartCoroutine(Postprogress(test));

        myButton.interactable = false;
    }


    IEnumerator Getobjexplain()
    {
        getProcess loginData = new getProcess { process = selectprocess };
        string jsonData = JsonUtility.ToJson(loginData);

        UnityWebRequest hs_get = UnityWebRequest.Get(apiBaseUrl + "OBJexplain");
        hs_get.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
        hs_get.downloadHandler = new DownloadHandlerBuffer();
        hs_get.SetRequestHeader("Content-Type", "application/json");

        yield return hs_get.SendWebRequest();

        if (hs_get.result == UnityWebRequest.Result.Success)
        {
            string dataText = hs_get.downloadHandler.text;
            Debug.Log("ExplainList흐에에 : " + dataText);
            explainList = JsonUtility.FromJson<ExplainList>("{\"explains\":" + dataText + "}").explains;

            Debug.Log("ExplainList흐에에 : " + explainList[0].Explain);
            
        }
        else
        {
            Debug.Log("There was an error getting the Explaindata: " + hs_get.error);
        }
    }

    IEnumerator Postprogress(int postProgress)
    {
        Debug.Log("아니 이게왜 0이나와?" + explainList.Count);
        PlayerProgress userProgressData = new PlayerProgress
        {
            userId = PlayerPrefs.GetString("LoggedInUserId", "No user ID found"),
            process = postProcess,
            progress = postProgress
        };

        string jsonData = JsonUtility.ToJson(userProgressData);

        UnityWebRequest answerRequest = UnityWebRequest.PostWwwForm(apiBaseUrl + "progress", "POST");
        answerRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
        answerRequest.downloadHandler = new DownloadHandlerBuffer();
        answerRequest.SetRequestHeader("Content-Type", "application/json");

        yield return answerRequest.SendWebRequest();

        if (answerRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Successful");
        }
        else
        {
            Debug.Log("There was an error postting the userProgressData: " + answerRequest.error);
        }
    }

    [Serializable]
    private class getProcess
    {
        public string process;
    }

    [Serializable]
    public class ExplainData
    {
        public string Explain;
        public int idx;
    }

    [Serializable]
    public class ExplainList
    {
        public List<ExplainData> explains;
    }

    [Serializable]
    private class PlayerProgress
    {
        public string userId;
        public string process;
        public int progress;
    }
}
