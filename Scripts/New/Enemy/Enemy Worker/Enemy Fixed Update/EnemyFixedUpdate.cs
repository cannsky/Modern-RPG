using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedUpdate
{
    public class FixedUpdateState
    {
        public EnemyWorker enemyWorker;

        public FixedUpdateState(EnemyWorker enemyWorker) => this.enemyWorker = enemyWorker;
    }

    public FixedUpdateState fixedUpdateState;

    public EnemyFixedUpdate(EnemyWorker enemyWorker) => fixedUpdateState = new FixedUpdateState(enemyWorker);

    public void FixedUpdate()
    {
        fixedUpdateState.enemyWorker.enemyPhysics.FixedUpdate();
    }
}
