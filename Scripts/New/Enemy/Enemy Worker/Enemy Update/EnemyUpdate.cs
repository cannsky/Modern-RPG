using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpdate
{

    public class UpdateState
    {
        public EnemyWorker enemyWorker;

        public UpdateState(EnemyWorker enemyWorker) => this.enemyWorker = enemyWorker;
    }

    public UpdateState updateState;

    public EnemyUpdate(EnemyWorker enemyWorker) => updateState = new UpdateState(enemyWorker);

    public void Update()
    {
        if (updateState.enemyWorker.enemyStats.statsState.enemyActionStats.CheckUpdateAvaiable()) WorkerUpdate();
    }

    public void WorkerUpdate()
    {
        updateState.enemyWorker.enemyAttack.Update();
        updateState.enemyWorker.enemyBehaviour.Update();
        updateState.enemyWorker.enemyStats.Update();
    }

}
