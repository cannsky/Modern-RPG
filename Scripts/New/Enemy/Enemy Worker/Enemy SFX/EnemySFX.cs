using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX
{
    public class SFXState
    {
        public EnemyWorker enemyWorker;

        public EnemySFXSettings sfxSettings;

        public EnemySpeechSFX enemySpeechSFX;

        public SFXState(EnemyWorker enemyWorker, EnemySFXSettings sfxSettings)
        {
            this.enemyWorker = enemyWorker;
            this.sfxSettings = sfxSettings;
            enemySpeechSFX = new EnemySpeechSFX(enemyWorker);
        }
    }

    public SFXState sfxState;

    public EnemySFX(EnemyWorker enemyWorker) => sfxState = new SFXState(enemyWorker, enemyWorker.enemyAI.enemySettings.sfxSettings);
}
