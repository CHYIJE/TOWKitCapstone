using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GoFac : MonoBehaviour
{
    private string apiBaseUrl = "http://kitcomputer.kr:5200/unity/";
    public string Process = "믹싱공정"; // 보낼때 필요한 값 믹싱일때 one, 코팅 two, 압연 three, 슬러팅 four
    public string Process_score = "process_score_one";


    public void GoFac1()
    {
        SceneManager.LoadScene("Fac1Edu");
    }
    public void GoFac2()
    {
        SceneManager.LoadScene("Fac2Edu");
    }
    public void GoFac3()
    {
        SceneManager.LoadScene("Fac3Edu");
    }
    public void GoFac4()
    {
        SceneManager.LoadScene("Fac4Edu");
    }
    public void GoFac1Test()
    {
        SceneManager.LoadScene("Fac1Eval");
    }
    public void GoFac2Test()
    {
        SceneManager.LoadScene("Fac2Eval");
    }
    public void GoFac3Test()
    {
        SceneManager.LoadScene("Fac3Eval");
    }
    public void GoFac4Test()
    {
        SceneManager.LoadScene("Fac4Eval");
    }
    public void GoUIMap()
    {
        SceneManager.LoadScene("UIMap");
    }
    public void testFinish()
    {
        SceneManager.LoadScene("UIMap");
        StartCoroutine(FinishTest());
    }
    IEnumerator FinishTest()
    {
        getProcess processData = new getProcess { process = Process, userId = PlayerPrefs.GetString("LoggedInUserId", "No user ID found"), processNum = Process_score };
        string jsonData = JsonUtility.ToJson(processData);

        Debug.Log("실행 되는가 : "+jsonData);

        UnityWebRequest hs_get = UnityWebRequest.Get(apiBaseUrl + "testFinish");
        hs_get.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
        hs_get.downloadHandler = new DownloadHandlerBuffer();
        hs_get.SetRequestHeader("Content-Type", "application/json");

        yield return hs_get.SendWebRequest();

        if (hs_get.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Sucessful!");
        }
        else
        {
            Debug.Log("There was an error getting the Explaindata: " + hs_get.error);
        }
    }
    [Serializable]
    private class getProcess
    {
        public string process;
        public string userId;
        public string processNum;
    }
}

