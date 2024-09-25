using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFocusControl
{
    public class FocusControlState
    {
        public PlayerWorker playerWorker;

        public PlayerControl.ControlState controlState;

        public PlayerControlSettings controlSettings;

        public bool lockLeftTargetInput, lockRightTargetInput;

        public FocusControlState(PlayerWorker playerWorker, PlayerControlSettings controlSettings)
        {
            this.playerWorker = playerWorker;
            this.controlSettings = controlSettings;
        }

        public void InitializeFocusControlState(PlayerControl playerControl) => controlState = playerControl.controlState;
    }

    public FocusControlState focusControlState;

    public PlayerFocusControl(PlayerWorker playerWorker) => focusControlState = new FocusControlState(playerWorker, playerWorker.player.playerSettings.controlSettings);

    public void Start() => SetFocusInput();

    public void Update() => HandleFocusInput();

    public void SetFocusInput()
    {
        focusControlState.controlState.inputActions.PlayerMovement.LockLeftTarget.performed += i => focusControlState.lockLeftTargetInput = true;
        focusControlState.controlState.inputActions.PlayerMovement.LockRightTarget.performed += i => focusControlState.lockRightTargetInput = true;
    }

    public void HandleFocusInput()
    {
        if (focusControlState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform == null) return;
        else if (focusControlState.lockLeftTargetInput) OnLockLeftTarget();
        else if (focusControlState.lockRightTargetInput) OnLockRightTarget();
    }

    public void OnLockLeftTarget()
    {
        focusControlState.lockLeftTargetInput = false;
        focusControlState.playerWorker.playerCamera.cameraState.playerCameraFocus.HandleCameraFocus(true);
    }

    public void OnLockRightTarget()
    {
        focusControlState.lockRightTargetInput = false;
        focusControlState.playerWorker.playerCamera.cameraState.playerCameraFocus.HandleCameraFocus(false);
    }
}
