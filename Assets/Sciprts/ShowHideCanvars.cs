using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideCanvars : MonoBehaviour
{
    public Transform player;
    public Transform canvas;
    public float activationDistance = 5.0f;

    private bool isCanvasActive = false;

    private void Start()
    {
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false); // 처음에 Canvas를 비활성화합니다.
        }
    }

    private void Update()
    {
        if (player == null || canvas == null)
        {
            // Debug.LogWarning("Player or canvas references are not set.");
            return;
        }

        float distanceToPlayer = Vector3.Distance(player.position, canvas.position);

        if (distanceToPlayer <= activationDistance && !isCanvasActive)
        {
            canvas.gameObject.SetActive(true);
            isCanvasActive = true;
        }
        else if (distanceToPlayer > activationDistance && isCanvasActive)
        {
            canvas.gameObject.SetActive(false);
            isCanvasActive = false;
        }
    }
}
