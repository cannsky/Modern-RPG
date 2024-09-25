using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent
{
    public class AgentState
    {
        public EnemyWorker enemyWorker;

        public EnemyAgentSettings agentSettings;

        public NavMeshAgent navMeshAgent;

        public AgentState(EnemyWorker enemyWorker, EnemyAgentSettings agentSettings)
        {
            this.enemyWorker = enemyWorker;
            this.agentSettings = agentSettings;
            navMeshAgent = agentSettings.navMeshAgent;
        }
    }

    public AgentState agentState;

    public EnemyAgent(EnemyWorker enemyWorker) => agentState = new AgentState(enemyWorker, enemyWorker.enemyAI.enemySettings.agentSettings);

    public void ResetAgentTransform()
    {
        agentState.navMeshAgent.transform.localPosition = Vector3.zero;
        agentState.navMeshAgent.transform.localRotation = Quaternion.identity;
    }
}
