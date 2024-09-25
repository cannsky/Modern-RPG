using Mandeshire;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponHolder
{
    public class WeaponHolderState
    {
        public EnemyWorker enemyWorker;

        public EnemyWeaponSettings weaponSettings;

        public Transform weaponSlot;

        public WeaponItem currentWeaponItem;

        public WeaponHolderState(EnemyWorker enemyWorker, EnemyWeaponSettings weaponSettings)
        {
            this.enemyWorker = enemyWorker;
            this.weaponSettings = weaponSettings;
            weaponSlot = weaponSettings.weaponSlot;
        }
    }

    public WeaponHolderState weaponHolderState;

    public EnemyWeaponHolder(EnemyWorker enemyWorker) => weaponHolderState = new WeaponHolderState(enemyWorker, enemyWorker.enemyAI.enemySettings.weaponSettings);

    public void MountWeapon(WeaponItem newWeaponItem)
    {
        if (weaponHolderState.currentWeaponItem != null) UnMountWeapon();
        weaponHolderState.currentWeaponItem = newWeaponItem;
        weaponHolderState.enemyWorker.enemyVFX.vfxState.enemyTrailVFX.UpdateTrailVFXParent();
        weaponHolderState.enemyWorker.enemyVFX.vfxState.enemyWeaponHitVFX.UpdateWeaponHitVFXParent();
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
