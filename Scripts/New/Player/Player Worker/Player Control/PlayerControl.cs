using UnityEngine;

public class PlayerControl
{
    public class ControlState
    {
        public PlayerWorker playerWorker;

        public PlayerControlSettings controlSettings;

        public PlayerAttackControl playerAttackControl;
        public PlayerFocusControl playerFocusControl;
        public PlayerMovementControl playerMovementControl;
        public PlayerRollControl playerRollControl;
        public PlayerUIControl playerUIControl;

        public float rollInputTimer;

        public bool bInput, rollFlag, sprintFlag, isInteracting;

        public PlayerControls inputActions;

        public ControlState(PlayerWorker playerWorker, PlayerControlSettings controlSettings)
        {
            this.playerWorker = playerWorker;
            this.controlSettings = controlSettings;
            playerAttackControl = new PlayerAttackControl(playerWorker);
            playerFocusControl = new PlayerFocusControl(playerWorker);
            playerMovementControl = new PlayerMovementControl(playerWorker);
            playerRollControl = new PlayerRollControl(playerWorker);
            playerUIControl = new PlayerUIControl(playerWorker);
        }

        public void InitializeControlState(PlayerControl playerControl)
        {
            SetInputActions();
            playerAttackControl.attackControlState.InitializeAttackControlState(playerControl);
            playerFocusControl.focusControlState.InitializeFocusControlState(playerControl);
            playerMovementControl.movementControlState.InitializeMovementControlState(playerControl);
            playerRollControl.rollControlState.InitializeRollControlState(playerControl);
            playerUIControl.uiControlState.InitializeAttackControlState(playerControl);

        }

        public void SetInputActions()
        {
            inputActions = new PlayerControls();
            inputActions.Enable();
        }
    }

    public ControlState controlState;

    public PlayerControl(PlayerWorker playerWorker) => controlState = new ControlState(playerWorker, playerWorker.player.playerSettings.controlSettings);

    public void Start()
    {
        controlState.InitializeControlState(this);
        controlState.playerAttackControl.Start();
        controlState.playerFocusControl.Start();
        controlState.playerMovementControl.Start();
        controlState.playerRollControl.Start();
        controlState.playerUIControl.Start();
    }

    public void OnEnable() => controlState.inputActions.Enable();

    public void OnDisable() => controlState.inputActions.Disable();

    public void Update()
    {
        controlState.playerAttackControl.Update();
        controlState.playerFocusControl.Update();
        controlState.playerMovementControl.Update();
        controlState.playerRollControl.Update();
        controlState.playerUIControl.Update();
    }

    public void LateUpdate()
    {
        controlState.playerAttackControl.LateUpdate();
        controlState.playerUIControl.LateUpdate();
        controlState.rollFlag = false;
        controlState.sprintFlag = false;
    }
}
