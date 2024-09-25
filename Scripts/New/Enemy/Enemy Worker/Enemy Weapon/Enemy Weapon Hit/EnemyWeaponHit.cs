using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponHit
{
    public class WeaponHitState
    {
        public EnemyWorker enemyWorker;

        public EnemyWeaponSettings weaponSettings;

        public WeaponHitState(EnemyWorker enemyWorker, EnemyWeaponSettings weaponSettings)
        {
            this.enemyWorker = enemyWorker;
            this.weaponSettings = weaponSettings;
        }

    }

    public WeaponHitState weaponHitState;

    public EnemyWeaponHit(EnemyWorker enemyWorker) => weaponHitState = new WeaponHitState(enemyWorker, enemyWorker.enemyAI.enemySettings.weaponSettings);

    public void HandleHit()
    {
        Player.Instance.playerWorker.playerDamage.HandleDamage(10);
    }
}
