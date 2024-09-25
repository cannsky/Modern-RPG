using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParry
{
    public class ParryState
    {
        public EnemyWorker enemyWorker;

        public EnemyParrySettings parrySettings;

        public float parryHitCount, parryHitCounter;

        public ParryState(EnemyWorker enemyWorker, EnemyParrySettings parrySettings)
        {
            this.enemyWorker = enemyWorker;
            this.parrySettings = parrySettings;
            parryHitCount = parrySettings.parryHitCount;
        }
    }

    public ParryState parryState;

    public EnemyParry(EnemyWorker enemyWorker) => parryState = new ParryState(enemyWorker, enemyWorker.enemyAI.enemySettings.parrySettings);

    public bool CheckParryAvailable()
    {
        if(++parryState.parryHitCounter > parryState.parryHitCount)
        {
            parryState.parryHitCounter = 0;
            return true;
        }
        else return false;
    }

}
