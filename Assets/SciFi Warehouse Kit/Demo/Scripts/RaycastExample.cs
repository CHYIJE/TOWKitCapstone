using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiPanel; // UI 요소를 참조할 변수
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                // 여기서 UI 요소를 활성화
                uiPanel.SetActive(true);
            }
        }
    }
}
