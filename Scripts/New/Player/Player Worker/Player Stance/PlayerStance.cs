using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStance
{
    public class StanceState
    {
        public PlayerWorker playerWorker;

        public PlayerStanceSettings stanceSettings;

        public float changeToAggressiveStanceWaitTime, idleWaitTime, passedAggressiveStanceTime, passedIdleTime;

        public bool isStanceB;

        public StanceState(PlayerWorker playerWorker, PlayerStanceSettings stanceSettings)
        {
            this.playerWorker = playerWorker;
            this.stanceSettings = stanceSettings;
            changeToAggressiveStanceWaitTime = stanceSettings.changeToAggressiveStanceWaitTime;
            idleWaitTime = stanceSettings.idleWaitTime;
        }
    }

    public StanceState stanceState;

    public PlayerStance(PlayerWorker playerWorker) => stanceState = new StanceState(playerWorker, playerWorker.player.playerSettings.stanceSettings);

    public void Update() => HandleStance();

    public void HandleStance()
    {
        if (!stanceState.isStanceB) return;
        if (stanceState.passedAggressiveStanceTime >= stanceState.changeToAggressiveStanceWaitTime)
            if (stanceState.passedIdleTime >= stanceState.idleWaitTime) ChangeToRelaxedStance();
            else stanceState.passedIdleTime += Time.deltaTime;
        else stanceState.passedAggressiveStanceTime += Time.deltaTime;
    }

    public void ChangeToRelaxedStance()
    {
        stanceState.isStanceB = false;
        stanceState.playerWorker.playerAnimation.ChangePlayerStance();
    }

    public void ChangeToAggressiveStance()
    {
        stanceState.isStanceB = true;
        stanceState.passedAggressiveStanceTime = 0;
        stanceState.passedIdleTime = 0;
        stanceState.playerWorker.playerAnimation.ChangePlayerStance();
    }

    public void ChangeToAggressiveStanceFast()
    {
        stanceState.isStanceB = true;
        stanceState.passedAggressiveStanceTime = 0;
        stanceState.passedIdleTime = 0;
        stanceState.playerWorker.playerAnimation.UpdateStanceValue();
        stanceState.playerWorker.playerFixer.ChangeToAgressiveWeaponSlot();
    }
}
