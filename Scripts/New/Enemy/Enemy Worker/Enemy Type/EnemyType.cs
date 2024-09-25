using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType
{
    public class TypeState
    {
        public EnemyWorker enemyWorker;

        public EnemyTypeSettings typeSettings;

        public EnemyMovementType enemyMovementType;

        public EnemyTypeSettings.Type type;

        public static int enemyCount;

        public int enemyID;

        public TypeState(EnemyWorker enemyWorker, EnemyTypeSettings typeSettings)
        {
            this.enemyWorker = enemyWorker;
            this.typeSettings = typeSettings;
            enemyMovementType = new EnemyMovementType(enemyWorker);
            type = typeSettings.type;
            enemyID = enemyCount++;
        }
    }

    public TypeState typeState;

    public EnemyType(EnemyWorker enemyWorker) => typeState = new TypeState(enemyWorker, enemyWorker.enemyAI.enemySettings.typeSettings);
}
