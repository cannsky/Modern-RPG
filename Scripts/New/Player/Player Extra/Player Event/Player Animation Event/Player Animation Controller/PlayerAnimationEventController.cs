using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerAnimationEventController
{
    public void ChangeWeaponSlot(int attackValue)
    {
        if (attackValue == 1) Player.Instance.playerWorker.playerFixer.ChangeToRelaxedWeaponSlot();
        else Player.Instance.playerWorker.playerFixer.ChangeToAgressiveWeaponSlot();
    }

    public void StartAttack(int value)
    {
        Player.Instance.playerWorker.playerVFX.vfxState.playerTrailVFX.EnableTrails();
        Player.Instance.playerWorker.playerSFX.sfxState.playerTrailSFX.PlayTrailAudio(value);
    }

    public void EndAttack()
    {
        Player.Instance.playerWorker.playerVFX.vfxState.playerTrailVFX.DisableTrails();
    }

    public void CheckExtraAttack(GameObject gameObject)
    {
        Player.Instance.playerWorker.playerWeapon.weaponState.playerWeaponCollision.weaponCollisionState.isWaiting = false;
        Player.Instance.playerWorker.playerCombatTechnique.combatTechniqueState.playerCombatTechniqueQueue.combatTechniqueQueueState.isCombatTechniqueReady = true;
    }

    public void StopCheckExtraAttack(GameObject gameObject)
    {
        Player.Instance.playerWorker.playerCombatTechnique.combatTechniqueState.playerCombatTechniqueQueue.combatTechniqueQueueState.isCombatTechniqueReady = false;
    }

    public void PlayFootstepAudio(GameObject gameObject, int footstepSFXValue)
    {
        if (gameObject.tag == "Animator2") return;
        Player.Instance.playerWorker.playerSFX.sfxState.playerFootstepSFX.PlayFootstepAudio(footstepSFXValue);
    }
}