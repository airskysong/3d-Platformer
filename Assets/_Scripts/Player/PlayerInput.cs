using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputAction playerInputAction;

    #region 属性
    public bool isJump => playerInputAction.GamePlay.Jump.phase == InputActionPhase.Started;

    public Vector2 move => playerInputAction.GamePlay.Axies.ReadValue<Vector2>();

    #endregion

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
    }

    public void SetPlayerInputEnable()
    {
        playerInputAction.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

}
