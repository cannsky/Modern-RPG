using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLateUpdate
{
    public class LateUpdateState
    {
        public EnemyWorker enemyWorker;

        public EnemyBarSettings barSettings;

        public EnemyHealthBar enemyHealthBar;

        public LateUpdateState(EnemyWorker enemyWorker, EnemyBarSettings barSettings)
        {
            this.enemyWorker = enemyWorker;
            this.barSettings = barSettings;
            enemyHealthBar = new EnemyHealthBar(enemyWorker);
        }
    }

    public LateUpdateState lateUpdateState;

    public EnemyLateUpdate(EnemyWorker enemyWorker) => lateUpdateState = new LateUpdateState(enemyWorker, enemyWorker.enemyAI.enemySettings.barSettings);

    public void LateUpdate()
    {
        lateUpdateState.enemyWorker.enemyBar.LateUpdate();
    }
}
