using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mandeshire;

public class PlayerWeaponHolder
{
    public class WeaponHolderState
    {
        public PlayerWorker playerWorker;

        public PlayerWeaponSettings weaponSettings;

        public Transform weaponSlot;

        public WeaponItem currentWeaponItem;

        public WeaponHolderState(PlayerWorker playerWorker, PlayerWeaponSettings weaponSettings)
        {
            this.playerWorker = playerWorker;
            this.weaponSettings = weaponSettings;
            weaponSlot = weaponSettings.weaponSlot;
        }
    }

    public WeaponHolderState weaponHolderState;

    public PlayerWeaponHolder(PlayerWorker playerWorker) => weaponHolderState = new WeaponHolderState(playerWorker, playerWorker.player.playerSettings.weaponSettings);

    public void MountWeapon(WeaponItem newWeaponItem)
    {
        if (weaponHolderState.currentWeaponItem != null) UnMountWeapon();
        weaponHolderState.currentWeaponItem = newWeaponItem;
        weaponHolderState.playerWorker.playerVFX.vfxState.playerTrailVFX.UpdateTrailVFXParent();
        weaponHolderState.playerWorker.playerVFX.vfxState.playerWeaponHitVFX.UpdateWeaponHitVFXParent();
        ChangeCurrentWeaponVisibility(true);
    }

    public void UnMountWeapon()
    {
        ChangeCurrentWeaponVisibility(false);
        weaponHolderState.currentWeaponItem = null;
    }

    public GameObject GetCurrentWeaponGameObject() => weaponHolderState.weaponSlot.GetChild(weaponHolderState.currentWeaponItem.weaponIndex).gameObject;

    public void ChangeCurrentWeaponVisibility(bool visibility) => weaponHolderState.weaponSlot.GetChild(weaponHolderState.currentWeaponItem.weaponIndex).gameObject.SetActive(visibility);
}
