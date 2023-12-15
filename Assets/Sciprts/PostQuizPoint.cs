using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class PostQuizPoint : MonoBehaviour
{
    private string apiBaseUrl = "http://kitcomputer.kr:5200/unity/";
    private string userAnswer;



    void Start()
    {
        
        
    }
    
    void Postanswerbtn()
    {
        // 문제에 대한 정답과 User의 정답을 비교 해서 true or false

        StartCoroutine(Postanswer());
    }

    IEnumerator Postanswer()
    {
        string loggedInUserId = PlayerPrefs.GetString("LoggedInUserId", "No user ID found");
        Player answerData = new Player { userId = loggedInUserId, quiz = "test", quizYN = true };
        string jsonData = JsonUtility.ToJson(answerData);

        UnityWebRequest answerRequest = UnityWebRequest.PostWwwForm(apiBaseUrl + "QuizPoint", "POST");
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
            Debug.Log("There was an error postting the answerData: " + answerRequest.error);
        }
    }

    [Serializable]
    private class Player
    {
        public string userId;
        public string quiz;
        public bool quizYN;
    }
}
