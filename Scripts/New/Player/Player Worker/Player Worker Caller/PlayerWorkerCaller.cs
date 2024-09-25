using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorkerCaller : MonoBehaviour
{
    public enum CallWorker { PlayerWeaponCollision }

    public CallWorker callWorker;

    public enum CallType { OnTriggerEnter }

    public CallType callType;

    public void OnTriggerEnter(Collider other)
    {
        if (callType != CallType.OnTriggerEnter) return;
        if (callWorker == CallWorker.PlayerWeaponCollision) Player.Instance.playerWorker.playerWeapon.weaponState.playerWeaponCollision.OnTriggerEnter(other.gameObject);
    }
}
