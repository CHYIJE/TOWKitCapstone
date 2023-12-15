using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrab : MonoBehaviour
{
    private bool isGrabbing = false;
    private Transform grabbedObject;

    void Update()
    {
        // Oculus 컨트롤러 버튼 입력 감지
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && !isGrabbing)
        {
            // 물체를 잡기
            Grab();
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) && isGrabbing)
        {
            // 물체를 놓기
            Release();
        }
    }

    void Grab()
    {
        // Oculus 컨트롤러에서 Ray 발사
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Ray에 부딪힌 물체를 잡기
            grabbedObject = hit.transform;
            isGrabbing = true;

            // 잡은 물체를 컨트롤러에 부착
            grabbedObject.SetParent(transform);
        }
    }

    void Release()
    {
        // 잡은 물체를 놓기
        if (grabbedObject != null)
        {
            grabbedObject.SetParent(null);
            isGrabbing = false;
            grabbedObject = null;
        }
    }
}
