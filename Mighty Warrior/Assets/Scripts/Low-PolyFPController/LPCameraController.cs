using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPCameraController : MonoBehaviour
{
    [SerializeField] private float xMouseSensitivity;
    [SerializeField] private float yMouseSensitivity;
    [SerializeField] private Transform arms;
    [SerializeField] private Transform body;
    [SerializeField] private float clampUp = 90f;
    [SerializeField] private float clampDown = -90f;

    private float xRot;

    private void Start()
    {
        LockCursor();
    }

    private void Update()
    {
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * xMouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * yMouseSensitivity * Time.deltaTime;

        xRot += mouseY;
        xRot = Mathf.Clamp(xRot, clampDown, clampUp);

        arms.localRotation = Quaternion.Euler(new Vector3(xRot, 0, 0));
        body.Rotate(new Vector3(0, mouseX, 0));
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
