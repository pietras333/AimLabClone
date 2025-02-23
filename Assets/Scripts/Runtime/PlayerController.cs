using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float sensitivity = 0.1f;

    [SerializeField]
    private float minVerticalAngle = -89f; // Prevent looking too far down

    [SerializeField]
    private float maxVerticalAngle = 89f; // Prevent looking too far up

    private Vector2 lookDirection;
    private float currentVerticalAngle = 0f;
    private bool isCursorActive = false;

    void Update()
    {
        if (isCursorActive)
        {
            return;
        }
        // Update vertical rotation with clamping
        currentVerticalAngle -= lookDirection.y * sensitivity;
        currentVerticalAngle = Mathf.Clamp(
            currentVerticalAngle,
            minVerticalAngle,
            maxVerticalAngle
        );

        // Update horizontal rotation
        float horizontalRotation =
            cameraTransform.rotation.eulerAngles.y + (lookDirection.x * sensitivity);

        // Apply both rotations
        cameraTransform.rotation = Quaternion.Euler(currentVerticalAngle, horizontalRotation, 0f);
    }

    public void SetCursorActivity(bool isActive)
    {
        Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isActive;
        isCursorActive = isActive;
    }

    public void OnLookInput(Vector2 lookDirection)
    {
        this.lookDirection = lookDirection;
    }
}
