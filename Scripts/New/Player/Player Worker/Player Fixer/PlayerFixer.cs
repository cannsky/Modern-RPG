using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFixer
{
    public class FixerState
    {
        public PlayerWorker playerWorker;

        public Transform agressiveSlotTransform, relaxedSlotTransform, weaponSlotTransform;

        public FixerState(PlayerWorker playerWorker, PlayerFixerSettings playerFixerSettings)
        {
            this.playerWorker = playerWorker;
            agressiveSlotTransform = playerFixerSettings.agressiveSlotTransform;
            relaxedSlotTransform = playerFixerSettings.relaxedSlotTransform;
            weaponSlotTransform = playerFixerSettings.weaponSlotTransform;
        }
    }

    public FixerState fixerState;

    public PlayerFixer(PlayerWorker playerWorker) => fixerState = new FixerState(playerWorker, playerWorker.player.playerSettings.fixerSettings);

    public void ChangeToAgressiveWeaponSlot()
    {
        fixerState.weaponSlotTransform.parent = fixerState.agressiveSlotTransform;
        ResetWeaponSlotTransformVariables();
    }

    public void ChangeToRelaxedWeaponSlot()
    {
        fixerState.weaponSlotTransform.parent = fixerState.relaxedSlotTransform;
        ResetWeaponSlotTransformVariables();
    }

    public void ResetWeaponSlotTransformVariables()
    {
        fixerState.weaponSlotTransform.localPosition = Vector3.zero;
        fixerState.weaponSlotTransform.localRotation = Quaternion.identity;
    }
}
