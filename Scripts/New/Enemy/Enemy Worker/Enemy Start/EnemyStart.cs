using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStart
{
    public class StartState
    {
        public EnemyWorker enemyWorker;

        public StartState(EnemyWorker enemyWorker) => this.enemyWorker = enemyWorker;
    }

    public StartState startState;

    public EnemyStart(EnemyWorker enemyWorker) => startState = new StartState(enemyWorker);

    public void Start()
    {
        startState.enemyWorker.player = Player.Instance.transform;
        startState.enemyWorker.enemyPhysics.Start();
        startState.enemyWorker.enemyWeapon.Start();
    }
}
