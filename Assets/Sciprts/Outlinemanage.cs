using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlinemanage : MonoBehaviour
{
    void Update()
    {
        // 오른손 컨트롤러 위치 및 회전 가져오기
        Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

        // Ray 방향 설정 (컨트롤러의 정면 방향으로)
        Vector3 rayDirection = controllerRotation * Vector3.forward;

        // Ray 생성
        Ray controllerRay = new Ray(controllerPosition, rayDirection);

        // 이제 controllerRay를 사용하여 레이캐스트 등을 수행할 수 있습니다.
        // 예를 들어, Ray에 맞는 물체 감지, 상호작용 등을 구현할 수 있습니다.
        RaycastHit hit;
        if (Physics.Raycast(controllerRay, out hit, Mathf.Infinity))
        {
            // Ray가 어떤 물체에 부딪혔을 때의 처리
            Debug.Log("Ray hit: " + hit.collider.gameObject.name);
        }
    }
}
