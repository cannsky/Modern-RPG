using UnityEngine;

public class PlayerWeapon
{
    public class WeaponState
    {
        public PlayerWorker playerWorker;

        public PlayerWeaponSettings weaponSettings;

        public PlayerWeaponCollision playerWeaponCollision;
        public PlayerWeaponHit playerWeaponHit;
        public PlayerWeaponHolder playerWeaponHolder;

        public WeaponState(PlayerWorker playerWorker, PlayerWeaponSettings weaponSettings)
        {
            this.playerWorker = playerWorker;
            this.weaponSettings = weaponSettings;
            playerWeaponCollision = new PlayerWeaponCollision(playerWorker);
            playerWeaponHit = new PlayerWeaponHit(playerWorker);
            playerWeaponHolder = new PlayerWeaponHolder(playerWorker);
        }
    }

    public WeaponState weaponState;

    public PlayerWeapon(PlayerWorker playerWorker) => weaponState = new WeaponState(playerWorker, playerWorker.player.playerSettings.weaponSettings);

    public void Start() => weaponState.playerWeaponHolder.MountWeapon(weaponState.weaponSettings.testWeapon);
}
