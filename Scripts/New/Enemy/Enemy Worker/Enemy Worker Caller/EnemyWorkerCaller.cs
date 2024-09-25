using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWorkerCaller : MonoBehaviour
{
    public EnemyAI enemyAI;

    public enum CallWorker { EnemyWeaponCollision }

    public CallWorker callWorker;

    public enum CallType { OnTriggerEnter }

    public CallType callType;

    public void OnTriggerEnter(Collider other)
    {
        if (callType != CallType.OnTriggerEnter) return;
        if (callWorker == CallWorker.EnemyWeaponCollision) enemyAI.enemyWorker.enemyWeapon.weaponState.enemyWeaponCollision.OnTriggerEnter(other.gameObject);
    }
}
