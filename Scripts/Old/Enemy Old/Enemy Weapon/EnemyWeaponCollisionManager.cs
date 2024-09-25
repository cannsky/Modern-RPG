using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponCollisionManager : MonoBehaviour
{
    public class EnemyWeaponCollisionState
    {
        public bool mutex;
        public bool isWaiting;
        public float waitTime;

        public bool UpdateWaitingStatus()
        {
            if (!mutex && !isWaiting)
            {
                mutex = true;
                isWaiting = true;
                mutex = false;
                return true;
            }
            else return false;
        }
    }

    public EnemyWeaponCollisionState enemyWeaponCollisionState;
    public EnemyAI enemyAI;

    private void Start()
    {
        enemyWeaponCollisionState = new EnemyWeaponCollisionState();
    }

    public void OnTriggerEnter(Collider other)
    {
        /*
        if (enemyWeaponCollisionState.isWaiting ||
            !enemyAI.enemyWorker.enemyAttack.GetAttackInfo() ||
            Player.Instance.playerWorker.playerState.state.combatState.state.defenseState.dodge ||
            other.gameObject.tag != "Player Hit Collider") return;
        else if (enemyWeaponCollisionState.UpdateWaitingStatus()) enemyAI.stats.TryHit(Player.Instance);
        */
    }

    public void ResetWaitingTime() => enemyWeaponCollisionState.isWaiting = false;
}