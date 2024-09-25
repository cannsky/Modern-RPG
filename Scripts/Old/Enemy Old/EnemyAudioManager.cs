using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour
{
    public class EnemyAudioState
    {
        public bool isBattleCrying;
        public bool isCustomLine;
        public bool isLaughing;
        public bool isDying;

        public void SetEnemyAudioState(bool isBattleCrying = false,
            bool isCustomLine = false,
            bool isLaughing = false,
            bool isDying = false)
        {
            this.isBattleCrying = isBattleCrying;
            this.isCustomLine = isCustomLine;
            this.isLaughing = isLaughing;
            this.isDying = isDying;
        }

        public bool IsStateFull() => isBattleCrying || isCustomLine || isLaughing || isDying;

    }

    [System.Serializable]
    public class EnemyAudioConfig
    {
        public float resetTime = 10f;
        public AudioClip battleCry;
        [Range(1, 100)]
        public float battleCryChance;
        public List<AudioClip> customLine;
        [Range(1, 100)]
        public float customLineChance;
        public AudioClip laugh;
        [Range(1, 100)]
        public float laughChance;
        public AudioClip death;
        [Range(1, 100)]
        public float deathChance;
    }

    public AudioSource enemySpeechAudioSource;
    public AudioSource enemySFXAudioSource;
    public EnemyAudioState enemyAudioState;
    public EnemyAudioConfig enemyAudioConfig;

    private void Start() => enemyAudioState = new EnemyAudioState();

    public void ResetEnemyAudioState() => enemyAudioState.SetEnemyAudioState();

    public bool PlayAudio(bool isBattleCry = false,
        bool isCustomLine = false,
        bool isLaugh = false,
        bool isDeath = false)
    {
        if (isBattleCry && enemyAudioConfig.battleCryChance > Random.Range(0, 100)) BattleCry();
        else if (isCustomLine && enemyAudioConfig.customLineChance > Random.Range(0, 100)) CustomLine();
        else if (isLaugh && enemyAudioConfig.laughChance > Random.Range(0, 100)) Laugh();
        else if (isDeath && enemyAudioConfig.deathChance > Random.Range(0, 100)) Death();
        return true;
    }

    void BattleCry()
    {
        if (enemyAudioState.IsStateFull()) return;
        enemyAudioState.SetEnemyAudioState(isBattleCrying: true);
        enemySpeechAudioSource.clip = enemyAudioConfig.battleCry;
        enemySpeechAudioSource.Play();
        Invoke("ResetEnemyAudioState", enemyAudioConfig.resetTime);
    }

    void CustomLine()
    {
        if (enemyAudioState.IsStateFull()) return;
        enemyAudioState.SetEnemyAudioState(isCustomLine: true);
        enemySpeechAudioSource.clip = enemyAudioConfig.customLine[Random.Range(0, enemyAudioConfig.customLine.Count - 1)];
        enemySpeechAudioSource.Play();
        Invoke("ResetEnemyAudioState", enemyAudioConfig.resetTime);
    }

    void Laugh()
    {
        if (enemyAudioState.IsStateFull()) return;
        enemyAudioState.SetEnemyAudioState(isLaughing: true);
        enemySpeechAudioSource.clip = enemyAudioConfig.laugh;
        enemySpeechAudioSource.Play();
        Invoke("ResetEnemyAudioState", enemyAudioConfig.resetTime);
    }

    void Death()
    {
        enemyAudioState.SetEnemyAudioState(isDying: true);
        enemySpeechAudioSource.clip = enemyAudioConfig.death;
        enemySpeechAudioSource.Play();
        Invoke("ResetEnemyAudioState", enemyAudioConfig.resetTime);
    }

}
