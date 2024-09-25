using UnityEngine;

public class EnemyAnimationEventController
{
    public EnemyAI enemyAI;

    public EnemyAnimationEventController(EnemyAI enemyAI) => this.enemyAI = enemyAI;

    public void PlaySkillVFX(int vfxValue) => enemyAI.enemyWorker.enemyVFX.vfxState.enemySkillVFX.PlayVFX(vfxValue);

    public void StartAttack()
    {
        enemyAI.enemyWorker.enemyVFX.vfxState.enemyTrailVFX.EnableTrails();
    }

    public void EndAttack()
    {
        enemyAI.enemyWorker.enemyVFX.vfxState.enemyTrailVFX.DisableTrails();
    }
}