using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// 공정 설명 요청 코드임 받아오기

public class QuizUI : MonoBehaviour
{
    private string apiBaseUrl = "http://kitcomputer.kr:5200/unity/";
    public string selectprocess = "믹싱공정";
    public int quiznum = 0;
    public Text objquiztext;
    public Button oBtn;
    public Button xBtn;
    private int test;
    
    List<QuizData> quizList = new List<QuizData>();
    public bool userAnswer;
    public GameObject uiPanel; // 문제 제출후 UI를 삭제하기 위해 필요
    
    void Start()
    {
        uiPanel.SetActive(true); // UI 를 보이고자 나타냄
        StartCoroutine(GetObjQuiz());
        
    }

    
    public void Obtn()
    {
        userAnswer = true;
        oBtn.interactable = false;
        xBtn.interactable = true;
    }

    public void Xbt()
    {
        userAnswer = false;
        oBtn.interactable = true;
        xBtn.interactable = false;
    }

    public void testbtn()
    {

    }
    public void submitAnswer()
    {
        StartCoroutine(Postanswer()); // 문제 UI에 제출 버튼에 연결하고 정답을 선택한 후 문제를 제출하면 끝 이후 UI 삭제
        uiPanel.SetActive(false); // UI 삭제 코드
    }

    bool trueOrfalse()
    {
        if(userAnswer == quizList[quiznum].quizYN)
        {
            return true;
        } else {
            return false;
        }
    }

    // 
    IEnumerator GetObjQuiz()
    {

        // 코드 4개 복사하고 밑에 selectprocess 를 공정에 맞게 수정
        
        getProcess loginData = new getProcess { process = selectprocess };
        string jsonData = JsonUtility.ToJson(loginData);

        UnityWebRequest hs_get = UnityWebRequest.Get(apiBaseUrl + "OBJquiz");
        hs_get.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
        hs_get.downloadHandler = new DownloadHandlerBuffer();
        hs_get.SetRequestHeader("Content-Type", "application/json");

        // 가져오기 요청
        yield return hs_get.SendWebRequest();

        // 요청이 성공했을 경우
        if (hs_get.result == UnityWebRequest.Result.Success)
        {
            string dataText = hs_get.downloadHandler.text;
            Debug.Log("전체 데이터" + dataText);
            
            quizList = JsonUtility.FromJson<QuizList>("{\"quizzes\":" + dataText + "}").quizzes;
            objquiztext.text = quizList[quiznum].quiz;
            Debug.Log("문제 인덱스 " + quizList[quiznum].idx);
            test = quizList[quiznum].idx;

        }
        // 요청이 실패했을 경우
        else
        {
            Debug.Log("There was an error getting the Explaindata: " + hs_get.error);
        }

        
    }

    IEnumerator Postanswer()
    {
        string loggedInUserId = PlayerPrefs.GetString("LoggedInUserId", "No user ID found");
        Player answerData = new Player { userId = loggedInUserId, idx = test, quizYN = trueOrfalse() };

        string jsonData = JsonUtility.ToJson(answerData);
        Debug.Log("개섹스"+jsonData);

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
    public class getProcess
    {
        public string process;
    }

    [Serializable]
    public class QuizData
    {
        public string quiz;
        public int idx;
        public bool quizYN;
    }
    [Serializable]
    public class QuizList
    {
        public List<QuizData> quizzes;
    }
    [Serializable]
    private class Player
    {
        public string userId; // string loggedInUserId = PlayerPrefs.GetString("LoggedInUserId", "No user ID found");
        public int idx; // quizList[randomNumber].quiz;
        public bool quizYN; // 여기에 정답을 비교해서 넣어야지...
    }
}   
