using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDownCanvars : MonoBehaviour
{
    public Camera mainCamera; // 카메라를 참조합니다.
    public GameObject uiObject; // 클릭 시 활성화할 UI GameObject를 참조합니다.

    private bool isUIActive = false; // UI 활성화 상태를 추적합니다.

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭을 감지합니다.
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject) // 클릭된 객체를 확인합니다.
                {
                    ToggleUI();
                }
            }
        }
    }

    private void ToggleUI()
    {
        isUIActive = !isUIActive; // UI 상태를 토글합니다.
        if (uiObject != null)
        {
            uiObject.SetActive(isUIActive); // UI를 활성화 또는 비활성화합니다.
        }
    }
}
