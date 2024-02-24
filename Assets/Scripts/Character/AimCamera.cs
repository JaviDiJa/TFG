using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UIElements;

public class AimCamera : MonoBehaviour
{
    public Cinemachine.AxisState xAxis, yAxis;
    [SerializeField] Transform cameraFollowPosition;

    public CinemachineFreeLook playerFreeLookCamera;

    [SerializeField] private float zoomMultiplier = 2;
    [SerializeField] private float defaultFov = 60;
    [SerializeField] private float zoomDuration = 4;

    void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        if (Input.GetMouseButton(1))
        {
            ZoomCamera(defaultFov / zoomMultiplier);
        }

        else if (playerFreeLookCamera.m_Lens.FieldOfView != defaultFov)
        {
            ZoomCamera(defaultFov);
        }
    }

    private void LateUpdate()
    {
        cameraFollowPosition.localEulerAngles = new Vector3(yAxis.Value, cameraFollowPosition.localEulerAngles.y, cameraFollowPosition.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
    }

    private void ZoomCamera(float target)
    {
        float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);
        playerFreeLookCamera.m_Lens.FieldOfView = Mathf.MoveTowards(playerFreeLookCamera.m_Lens.FieldOfView, target, angle / zoomDuration * Time.deltaTime);
    }
}