using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementType
{
    public class MovementTypeState
    {
        public EnemyWorker enemyWorker;

        public EnemyMovementTypeSettings movementTypeSettings;

        public EnemyMovementTypeSettings.MovementType movementType;

        public MovementTypeState(EnemyWorker enemyWorker, EnemyMovementTypeSettings movementTypeSettings)
        {
            this.enemyWorker = enemyWorker;
            this.movementTypeSettings = movementTypeSettings;
            movementType = movementTypeSettings.movementType;
        }
    }

    public MovementTypeState movementTypeState;

    public EnemyMovementType(EnemyWorker enemyWorker) => movementTypeState = new MovementTypeState(enemyWorker, enemyWorker.enemyAI.enemySettings.typeSettings.movementTypeSettings);
}
