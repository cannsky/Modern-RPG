using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon
{
    public class WeaponState
    {
        public EnemyWorker enemyWorker;

        public EnemyWeaponSettings weaponSettings;

        public EnemyWeaponCollision enemyWeaponCollision;
        public EnemyWeaponHolder enemyWeaponHolder;
        public EnemyWeaponHit enemyWeaponHit;

        public WeaponState(EnemyWorker enemyWorker, EnemyWeaponSettings weaponSettings)
        {
            this.enemyWorker = enemyWorker;
            this.weaponSettings = weaponSettings;
            enemyWeaponCollision = new EnemyWeaponCollision(enemyWorker);
            enemyWeaponHolder = new EnemyWeaponHolder(enemyWorker);
            enemyWeaponHit = new EnemyWeaponHit(enemyWorker);
        }
    }

    public WeaponState weaponState;

    public EnemyWeapon(EnemyWorker enemyWorker) => weaponState = new WeaponState(enemyWorker, enemyWorker.enemyAI.enemySettings.weaponSettings);

    public void Start() => weaponState.enemyWeaponHolder.MountWeapon(weaponState.weaponSettings.testWeapon);
}
