using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponCollision
{
    public class WeaponCollisionState
    {
        public EnemyWorker enemyWorker;

        public EnemyWeaponSettings weaponSettings;

        public bool isAttackStarted, isWaiting;

        public WeaponCollisionState(EnemyWorker enemyWorker, EnemyWeaponSettings weaponSettings)
        {
            this.enemyWorker = enemyWorker;
            this.weaponSettings = weaponSettings;
        }
    }

    public WeaponCollisionState weaponCollisionState;

    public EnemyWeaponCollision(EnemyWorker enemyWorker) => weaponCollisionState = new WeaponCollisionState(enemyWorker, enemyWorker.enemyAI.enemySettings.weaponSettings);

    public void OnTriggerEnter(GameObject collidedGameObject)
    {
        if (weaponCollisionState.isWaiting || !weaponCollisionState.isAttackStarted || collidedGameObject.tag != "Player Hit Collider") return;
        weaponCollisionState.isWaiting = true;
        weaponCollisionState.enemyWorker.enemyWeapon.weaponState.enemyWeaponHit.HandleHit();
        weaponCollisionState.enemyWorker.enemyVFX.vfxState.enemyWeaponHitVFX.PlayHitVFX(collidedGameObject.transform);
    }
}
