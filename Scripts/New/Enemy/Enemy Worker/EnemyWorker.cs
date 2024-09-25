using UnityEngine;

public class EnemyWorker
{
    public EnemyAI enemyAI;
    public Transform player;
    public EnemyAgent enemyAgent;
    public EnemyAnimation enemyAnimation;
    public EnemyAttack enemyAttack;
    public EnemyBar enemyBar;
    public EnemyBehaviour enemyBehaviour;
    public EnemyCamera enemyCamera;
    public EnemyDamage enemyDamage;
    public EnemyDeath enemyDeath;
    public EnemyDetection enemyDetection;
    public EnemyDodge enemyDodge;
    public EnemyLoot enemyLoot;
    public EnemyFixedUpdate enemyFixedUpdate;
    public EnemyLateUpdate enemyLateUpdate;
    public EnemyMaterial enemyMaterial;
    public EnemyMovement enemyMovement;
    public EnemyParry enemyParry;
    public EnemyPhysics enemyPhysics;
    public EnemyRotation enemyRotation;
    public EnemySFX enemySFX;
    public EnemySpeech enemySpeech;
    public EnemyStart enemyStart;
    public EnemyStats enemyStats;
    public EnemyTrigger enemyTrigger;
    public EnemyType enemyType;
    public EnemyUpdate enemyUpdate;
    public EnemyVFX enemyVFX;
    public EnemyVision enemyVision;
    public EnemyWeapon enemyWeapon;

    public EnemyWorker(EnemyAI enemyAI, Transform player)
    {
        this.enemyAI = enemyAI;
        this.player = player;
        enemyAgent = new EnemyAgent(this);
        enemyAnimation = new EnemyAnimation(this);
        enemyAttack = new EnemyAttack(this);
        enemyBar = new EnemyBar(this);
        enemyBehaviour = new EnemyBehaviour(this);
        enemyCamera = new EnemyCamera(this);
        enemyDamage = new EnemyDamage(this);
        enemyDeath = new EnemyDeath(this);
        enemyDetection = new EnemyDetection(this);
        enemyDodge = new EnemyDodge(this);
        enemyLoot = new EnemyLoot(this);
        enemyFixedUpdate = new EnemyFixedUpdate(this);
        enemyLateUpdate = new EnemyLateUpdate(this);
        enemyMaterial = new EnemyMaterial(this);
        enemyMovement = new EnemyMovement(this);
        enemyParry = new EnemyParry(this);
        enemyPhysics = new EnemyPhysics(this);
        enemyRotation = new EnemyRotation(this);
        enemySFX = new EnemySFX(this);
        enemySpeech = new EnemySpeech(this);
        enemyStart = new EnemyStart(this);
        enemyStats = new EnemyStats(this);
        enemyTrigger = new EnemyTrigger(this);
        enemyType = new EnemyType(this);
        enemyUpdate = new EnemyUpdate(this);
        enemyVFX = new EnemyVFX(this);
        enemyVision = new EnemyVision(this);
        enemyWeapon = new EnemyWeapon(this);
    }

    public void StartCall() => enemyStart.Start();

    public void UpdateCall() => enemyUpdate.Update();

    public void FixedUpdateCall() => enemyFixedUpdate.FixedUpdate();

    public void LateUpdateCall() => enemyLateUpdate.LateUpdate();
}
