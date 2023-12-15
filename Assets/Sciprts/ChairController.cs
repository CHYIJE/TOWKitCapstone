using UnityEngine;

public class ChairController : MonoBehaviour
{
    private float moveSpeed = 5f; // 이동 속도
    private float maxYPosition = 0.9f; // 움직일 수 있는 최대 Y 좌표 값
    private float minYPosition = 0.45f; // 움직일 수 있는 최소 Y 좌표 값
    private float targetYPosition; // 목표 Y 좌표 값
    private float smoothTime = 0.05f; // 부드러운 이동을 위한 시간 값

    void Awake()
    {
        // 처음에 의자를 최소 Y 좌표로 설정
        transform.position = new Vector3(transform.position.x, minYPosition, transform.position.z);
        targetYPosition = minYPosition;
    }

    void Update()
    {
        // Oculus 컨트롤러의 A 버튼이 눌렸을 때
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            MoveUp();
        }

        // Oculus 컨트롤러의 B 버튼이 눌렸을 때
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            MoveDown();
        }

        // 서서히 움직임
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetYPosition, transform.position.z), smoothTime);
    }

    void MoveUp()
    {
        // 목표 위치를 최대 Y 좌표로 설정
        targetYPosition = maxYPosition;
    }

    void MoveDown()
    {
        // 목표 위치를 최소 Y 좌표로 설정
        targetYPosition = minYPosition;
    }

    void MoveToNewPosition(float targetYPosition)
    {
        // 특정 위치로 이동
        targetYPosition = 1.36F;
    }
}