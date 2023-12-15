using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mix_Rotation : MonoBehaviour
{
    // 회전 속도 조절을 위한 변수
    public float rotationSpeed = 50f;

    void Update()
    {
        // 오른쪽으로 Y 축을 중심으로 회전
        RotateObject(Vector3.up);
    }

    void RotateObject(Vector3 axis)
    {
        // Time.deltaTime을 사용하여 회전 속도를 초당 몇 도로 할지 지정
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // 현재 오브젝트의 transform을 사용하여 Y 축을 중심으로 회전
        transform.Rotate(axis, rotationAmount, Space.World);
    }
}