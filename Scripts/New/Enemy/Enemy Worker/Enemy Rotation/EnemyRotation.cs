using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation
{
    public class RotationState
    {
        public EnemyWorker enemyWorker;

        public EnemyRotationSettings rotationSettings;

        public EnemyAttackRotation enemyAttackRotation;
        public EnemyChaseRotation enemyChaseRotation;
        public EnemyDodgeRotation enemyDodgeRotation;

        public bool isRotationEnded;
        public bool isTurnLeft;

        public RotationState(EnemyWorker enemyWorker, EnemyRotationSettings rotationSettings)
        {
            this.enemyWorker = enemyWorker;
            this.rotationSettings = rotationSettings;
            enemyAttackRotation = new EnemyAttackRotation(enemyWorker);
            enemyChaseRotation = new EnemyChaseRotation(enemyWorker);
            enemyDodgeRotation = new EnemyDodgeRotation(enemyWorker);
        }
    }

    public RotationState rotationState;

    public EnemyRotation(EnemyWorker enemyWorker) => rotationState = new RotationState(enemyWorker, enemyWorker.enemyAI.enemySettings.rotationSettings);
}