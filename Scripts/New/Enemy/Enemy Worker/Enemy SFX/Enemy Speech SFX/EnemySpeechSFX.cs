using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeechSFX
{
    public class SpeechSFXState
    {
        public EnemyWorker enemyWorker;

        public EnemySFXSettings sfxSettings;

        public AudioSource speechAudioSource;

        public List<AudioClip> customLine;
        public AudioClip battleCry, laugh, death;
        public float resetTime, battleCryChance, customLineChance, laughChance, deathChance;

        public bool isBattleCrying, isCustomLine, isLaughing, isDying;
        public bool isBattleCried, isCustomLined, isLaughed, isDied;

        public SpeechSFXState(EnemyWorker enemyWorker, EnemySFXSettings sfxSettings)
        {
            this.enemyWorker = enemyWorker;
            this.sfxSettings = sfxSettings;
            customLine = sfxSettings.speechSFXSettings.customLine;
            battleCry = sfxSettings.speechSFXSettings.battleCry;
            laugh = sfxSettings.speechSFXSettings.laugh;
            death = sfxSettings.speechSFXSettings.death;
            resetTime = sfxSettings.speechSFXSettings.resetTime;
            battleCryChance = sfxSettings.speechSFXSettings.battleCryChance;
            customLineChance = sfxSettings.speechSFXSettings.customLineChance;
            laughChance = sfxSettings.speechSFXSettings.laughChance;
            deathChance = sfxSettings.speechSFXSettings.deathChance;
            speechAudioSource = sfxSettings.speechSFXSettings.speechAudioSource;
        }

        public void SetEnemyAudioState(bool isBattleCrying = false, bool isCustomLine = false, bool isLaughing = false, bool isDying = false)
        {
            this.isBattleCrying = isBattleCrying;
            this.isCustomLine = isCustomLine;
            this.isLaughing = isLaughing;
            this.isDying = isDying;
        }

        public void SetPastAudioState(bool isBattleCried = false, bool isCustomLined = false, bool isLaughed = false, bool isDied = false)
        {
            this.isBattleCried = isBattleCried;
            this.isCustomLined = isCustomLined;
            this.isLaughed = isLaughed;
            this.isDied = isDied;
        }

        public bool IsStateFull() => isBattleCrying || isCustomLine || isLaughing || isDying;
    }

    public SpeechSFXState speechSFXState;

    public EnemySpeechSFX(EnemyWorker enemyWorker) => speechSFXState = new SpeechSFXState(enemyWorker, enemyWorker.enemyAI.enemySettings.sfxSettings);

    public IEnumerator ResetSpeechSFXState()
    {
        yield return new WaitForSeconds(speechSFXState.resetTime);
        speechSFXState.SetEnemyAudioState();
    }

    public bool PlayAudio(bool isBattleCry = false, bool isCustomLine = false, bool isLaugh = false, bool isDeath = false)
    {
        if (isBattleCry && !speechSFXState.isBattleCried && speechSFXState.battleCryChance > Random.Range(0, 100)) BattleCry();
        else if (isCustomLine && !speechSFXState.isCustomLined && speechSFXState.customLineChance > Random.Range(0, 100)) CustomLine();
        else if (isLaugh && !speechSFXState.isLaughed && speechSFXState.laughChance > Random.Range(0, 100)) Laugh();
        else if (isDeath && !speechSFXState.isDied && speechSFXState.deathChance > Random.Range(0, 100)) Death();
        return true;
    }

    public void BattleCry()
    {
        if (speechSFXState.IsStateFull()) return;
        speechSFXState.SetEnemyAudioState(isBattleCrying: true);
        speechSFXState.SetPastAudioState(isBattleCried: true);
        speechSFXState.speechAudioSource.clip = speechSFXState.battleCry;
        speechSFXState.speechAudioSource.Play();
        speechSFXState.enemyWorker.enemyAI.StartCoroutine(ResetSpeechSFXState());
    }

    public void CustomLine()
    {
        if (speechSFXState.IsStateFull()) return;
        speechSFXState.SetEnemyAudioState(isCustomLine: true);
        speechSFXState.SetPastAudioState(isCustomLined: true);
        speechSFXState.speechAudioSource.clip = speechSFXState.customLine[Random.Range(0, speechSFXState.customLine.Count - 1)];
        speechSFXState.speechAudioSource.Play();
        speechSFXState.enemyWorker.enemyAI.StartCoroutine(ResetSpeechSFXState());
    }

    public void Laugh()
    {
        if (speechSFXState.IsStateFull()) return;
        speechSFXState.SetEnemyAudioState(isLaughing: true);
        speechSFXState.SetPastAudioState(isLaughed: true);
        speechSFXState.speechAudioSource.clip = speechSFXState.laugh;
        speechSFXState.speechAudioSource.Play();
        speechSFXState.enemyWorker.enemyAI.StartCoroutine(ResetSpeechSFXState());
    }

    void Death()
    {
        speechSFXState.SetEnemyAudioState(isDying: true);
        speechSFXState.SetPastAudioState(isDied: true);
        speechSFXState.speechAudioSource.clip = speechSFXState.death;
        speechSFXState.speechAudioSource.Play();
    }
}
