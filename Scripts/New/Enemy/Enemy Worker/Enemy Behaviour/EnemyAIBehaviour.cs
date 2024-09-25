using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAIBehaviour
{
    public abstract EnemyAIBehaviour Tick();

    public abstract void HandleBehaviourUpdates();

    public abstract EnemyAIBehaviour HandleUpgradeBehaviour();

    public abstract EnemyAIBehaviour HandleBehaviour();

    public abstract EnemyAIBehaviour HandleDowngradeBehaviour();
}
