using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // 회전 속도

    void Update()
    {
        // 모델의 로컬 좌표계를 기준으로 주어진 속도로 회전
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
    }
}