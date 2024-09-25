using System.Collections;
using UnityEngine;

public class EnemySpeech
{
    public class SpeechState
    {
        public EnemyWorker enemyWorker;

        public bool isCooldownEnded = true;

        public EnemySpeechSettings speechSettings;

        public SpeechState(EnemyWorker enemyWorker, EnemySpeechSettings speechSettings)
        {
            this.enemyWorker = enemyWorker;
            this.speechSettings = speechSettings;
        }
    }

    public SpeechState speechState;

    public EnemySpeech(EnemyWorker enemyWorker) => speechState = new SpeechState(enemyWorker, enemyWorker.enemyAI.enemySettings.speechSettings);

    public IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(speechState.speechSettings.cooldownTime);
        speechState.isCooldownEnded = true;
    }

    public bool PlaySpeech(int behaviourType)
    {
        return behaviourType switch
        {
            0 => speechState.enemyWorker.enemySFX.sfxState.enemySpeechSFX.PlayAudio(isBattleCry: true, isCustomLine: true, isLaugh: true),
            1 => speechState.enemyWorker.enemySFX.sfxState.enemySpeechSFX.PlayAudio(isCustomLine: true, isLaugh: true),
            2 => speechState.enemyWorker.enemySFX.sfxState.enemySpeechSFX.PlayAudio(isCustomLine: true, isLaugh: true),
            3 => speechState.enemyWorker.enemySFX.sfxState.enemySpeechSFX.PlayAudio(isDeath: true),
            _ => false
        };
    }

    public void TalkWithPlayer(int behaviourType)
    {
        if (!speechState.isCooldownEnded) return;
        speechState.isCooldownEnded = false;
        PlaySpeech(behaviourType);
        speechState.enemyWorker.enemyAI.StartCoroutine(ResetCooldown());
    }
}
