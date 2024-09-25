using UnityEngine;

public class PlayerWeaponCollision
{
    public class WeaponCollisionState
    {
        public PlayerWorker playerWorker;

        public PlayerWeaponSettings weaponSettings;

        public bool mutex;
        public bool isWaiting;

        public WeaponCollisionState(PlayerWorker playerWorker, PlayerWeaponSettings weaponSettings)
        {
            this.playerWorker = playerWorker;
            this.weaponSettings = weaponSettings;
        }
    }

    public WeaponCollisionState weaponCollisionState;

    public PlayerWeaponCollision(PlayerWorker playerWorker) => weaponCollisionState = new WeaponCollisionState(playerWorker, playerWorker.player.playerSettings.weaponSettings);

    public void OnTriggerEnter(GameObject collidedGameObject)
    {
        if (weaponCollisionState.isWaiting ||
            !Player.Instance.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isAttacking
            || collidedGameObject.gameObject.tag != "Enemy Hit Collider") return;
        weaponCollisionState.isWaiting = true;
        weaponCollisionState.playerWorker.playerWeapon.weaponState.playerWeaponHit.HandleHit(collidedGameObject);
        weaponCollisionState.playerWorker.playerVFX.vfxState.playerWeaponHitVFX.PlayHitVFX(collidedGameObject.transform);
    }
}
