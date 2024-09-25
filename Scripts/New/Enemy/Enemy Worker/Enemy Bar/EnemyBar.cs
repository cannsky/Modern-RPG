using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBar
{
    public class BarState
    {
        public EnemyWorker enemyWorker;

        public EnemyBarSettings barSettings;

        public EnemyHealthBar enemyHealthBar;

        public BarState(EnemyWorker enemyWorker, EnemyBarSettings barSettings)
        {
            this.enemyWorker = enemyWorker;
            this.barSettings = barSettings;
            enemyHealthBar = new EnemyHealthBar(enemyWorker);
        }
    }

    public BarState barState;

    public EnemyBar(EnemyWorker enemyWorker) => barState = new BarState(enemyWorker, enemyWorker.enemyAI.enemySettings.barSettings);

    public void LateUpdate() => barState.enemyHealthBar.LateUpdate();
}
