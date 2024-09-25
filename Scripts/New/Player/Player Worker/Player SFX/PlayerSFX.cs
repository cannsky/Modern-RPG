using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX
{
    public class SFXState
    {
        public PlayerWorker playerWorker;

        public PlayerSFXSettings sfxSettings;

        public PlayerFootstepSFX playerFootstepSFX;
        public PlayerSlashSFX playerSlashSFX;
        public PlayerTrailSFX playerTrailSFX;

        public SFXState(PlayerWorker playerWorker, PlayerSFXSettings sfxSettings)
        {
            this.playerWorker = playerWorker;
            this.sfxSettings = sfxSettings;
            playerFootstepSFX = new PlayerFootstepSFX(playerWorker);
            playerSlashSFX = new PlayerSlashSFX(playerWorker);
            playerTrailSFX = new PlayerTrailSFX(playerWorker);
        }
    }

    public SFXState sfxState;

    public PlayerSFX(PlayerWorker playerWorker) => sfxState = new SFXState(playerWorker, playerWorker.player.playerSettings.sfxSettings);
}
