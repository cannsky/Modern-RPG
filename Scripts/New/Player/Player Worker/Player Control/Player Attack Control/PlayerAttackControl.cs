using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl
{
    public class AttackControlState
    {
        public PlayerWorker playerWorker;

        public PlayerControl.ControlState controlState;

        public PlayerControlSettings controlSettings;

        public bool attackInput, skillAttackInput;

        public AttackControlState(PlayerWorker playerWorker, PlayerControlSettings controlSettings)
        {
            this.playerWorker = playerWorker;
            this.controlSettings = controlSettings;
        }

        public void InitializeAttackControlState(PlayerControl playerControl) => controlState = playerControl.controlState;
    }

    public AttackControlState attackControlState;

    public PlayerAttackControl(PlayerWorker playerWorker) => attackControlState = new AttackControlState(playerWorker, playerWorker.player.playerSettings.controlSettings);

    public void Start() => SetAttackInput();

    public void Update() => HandleAttackInput();

    public void LateUpdate()
    {
        attackControlState.attackInput = false;
        attackControlState.skillAttackInput = false;
    }

    public void SetAttackInput()
    {
        attackControlState.controlState.inputActions.PlayerActions.Attack.performed += i => attackControlState.attackInput = true;
        attackControlState.controlState.inputActions.PlayerActions.SkillAttack.performed += i => attackControlState.skillAttackInput = true;
    }

    public void HandleAttackInput()
    {
        if (attackControlState.attackInput) attackControlState.playerWorker.playerAttack.Attack();
        else if (attackControlState.skillAttackInput) attackControlState.playerWorker.playerAttack.Attack();
    }
}
