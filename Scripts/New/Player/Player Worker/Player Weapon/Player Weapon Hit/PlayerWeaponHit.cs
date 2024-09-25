using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHit
{
    public class WeaponHitState
    {
        public PlayerWorker playerWorker;

        public PlayerWeaponSettings weaponSettings;

        public bool mutex;
        public bool isWaiting;

        public WeaponHitState(PlayerWorker playerWorker, PlayerWeaponSettings weaponSettings)
        {
            this.playerWorker = playerWorker;
            this.weaponSettings = weaponSettings;
        }
    }

    public WeaponHitState weaponHitState;

    public PlayerWeaponHit(PlayerWorker playerWorker) => weaponHitState = new WeaponHitState(playerWorker, playerWorker.player.playerSettings.weaponSettings);

    public void HandleHit(GameObject enemyGameObject)
    {
        enemyGameObject.transform.parent.parent.GetComponent<EnemyAI>().enemyWorker.enemyDamage.HandleDamage(25);
    }
}
