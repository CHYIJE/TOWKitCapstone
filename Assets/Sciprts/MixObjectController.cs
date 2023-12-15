using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixObjectController : MonoBehaviour
{
    public GameObject chair; // 의자 오브젝트에 대한 레퍼런스
    public GameObject lowerBox; // 아랫통 오브젝트에 대한 레퍼런스

    private bool isMixObjectOn = true; // MIX 오브젝트의 ON/OFF 상태

    void Start()
    {
        // 초기화 코드 작성
    }

    void Update()
    {
        // 매 프레임마다 실행되는 코드 작성
    }

    public void OnChairButtonUp()
    {
        // 의자를 UP하는 동작 코드 작성
        chair.transform.Translate(Vector3.up * Time.deltaTime);
    }

    public void OnChairButtonDown()
    {
        // 의자를 DOWN하는 동작 코드 작성
        chair.transform.Translate(Vector3.down * Time.deltaTime);
    }
    public void OnChairClick()
    {
        // 의자를 클릭하는 동작 코드 작성
        // 예를 들어, 의자를 회전시키거나 다른 동작을 수행
        Debug.Log("의자가 클릭되었습니다.");
    }



    public void OnLowerBoxButtonClick()

    {
        // 아랫통을 클릭하는 동작 코드 작성
        // 예를 들어, 아랫통을 열거나 다른 동작을 수행
    }

    public void OnMixObjectToggle()
    {
        // MIX 오브젝트를 ON/OFF 토글하는 동작 코드 작성
        isMixObjectOn = !isMixObjectOn;
        gameObject.SetActive(isMixObjectOn);
    }
}