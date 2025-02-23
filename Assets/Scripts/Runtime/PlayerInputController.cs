using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private PlayerFPSController playerFPSController;

    public void OnLook(InputValue context)
    {
        Vector2 lookDirection = context.Get<Vector2>();
        playerController.OnLookInput(lookDirection);
    }

    public void OnShoot(InputValue value)
    {
        bool isPressed = value.isPressed;
        playerFPSController.OnShootInput(isPressed);
    }
}
