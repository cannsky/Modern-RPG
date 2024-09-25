public class EnemyVFX
{
    public class VFXState
    {
        public EnemyWorker enemyWorker;

        public EnemyVFXSettings vfxSettings;

        public EnemyDissolveVFX enemyDissolveVFX;
        public EnemySkillVFX enemySkillVFX;
        public EnemyTrailVFX enemyTrailVFX;
        public EnemyWeaponHitVFX enemyWeaponHitVFX;

        public VFXState(EnemyWorker enemyWorker, EnemyVFXSettings vfxSettings)
        {
            this.enemyWorker = enemyWorker;
            this.vfxSettings = vfxSettings;
            enemyDissolveVFX = new EnemyDissolveVFX(enemyWorker);
            enemySkillVFX = new EnemySkillVFX(enemyWorker);
            enemyTrailVFX = new EnemyTrailVFX(enemyWorker);
            enemyWeaponHitVFX = new EnemyWeaponHitVFX(enemyWorker);
        }
    }

    public VFXState vfxState;

    public EnemyVFX(EnemyWorker enemyWorker) => vfxState = new VFXState(enemyWorker, enemyWorker.enemyAI.enemySettings.vfxSettings);
}