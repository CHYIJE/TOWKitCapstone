using UnityEngine;
using UnityEngine.XR;

public class RemoteGrabber : MonoBehaviour
{
    public XRNode controllerNode = XRNode.RightHand;
    public LayerMask interactableLayer;
    private InputDevice controller;
    private GameObject selectedObject = null;

    private void Start()
    {
        controller = InputDevices.GetDeviceAtXRNode(controllerNode);
    }

    void Update()
    {
        controller.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100, interactableLayer))
        {
            if (triggerValue && selectedObject == null) // 트리거 당길 때
            {
                selectedObject = hit.collider.gameObject;
            }
        }

        if (selectedObject != null && !triggerValue) // 트리거 놓았을 때
        {
            selectedObject.transform.position = transform.position;
            selectedObject = null;
        }
    }
}