public class PlayerVFX
{
    public class VFXState
    {
        public PlayerWorker playerWorker;

        public PlayerVFXSettings vfxSettings;

        public PlayerAttackVFX playerAttackVFX;
        public PlayerTrailVFX playerTrailVFX;
        public PlayerWeaponHitVFX playerWeaponHitVFX;

        public VFXState(PlayerWorker playerWorker, PlayerVFXSettings vfxSettings)
        {
            this.playerWorker = playerWorker;
            this.vfxSettings = vfxSettings;
            playerAttackVFX = new PlayerAttackVFX(playerWorker);
            playerTrailVFX = new PlayerTrailVFX(playerWorker);
            playerWeaponHitVFX = new PlayerWeaponHitVFX(playerWorker);
        }
    }

    public VFXState vfxState;

    public PlayerVFX(PlayerWorker playerWorker) => vfxState = new VFXState(playerWorker, playerWorker.player.playerSettings.vfxSettings);
}
