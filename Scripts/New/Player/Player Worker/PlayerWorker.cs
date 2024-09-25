using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorker
{
    public Player player;
    public PlayerAnimation playerAnimation;
    public PlayerAttack playerAttack;
    public PlayerAwake playerAwake;
    public PlayerCamera playerCamera;
    public PlayerCombatTechnique playerCombatTechnique;
    public PlayerControl playerControl;
    public PlayerDamage playerDamage;
    public PlayerFixedUpdate playerFixedUpdate;
    public PlayerFixer playerFixer;
    public PlayerInventory playerInventory;
    public PlayerLateUpdate playerLateUpdate;
    public PlayerMovement playerMovement;
    public PlayerPhysics playerPhysics;
    public PlayerRotation playerRotation;
    public PlayerSFX playerSFX;
    public PlayerSphere playerSphere;
    public PlayerStance playerStance;
    public PlayerStart playerStart;
    public PlayerStats playerStats;
    public PlayerUI playerUI;
    public PlayerUpdate playerUpdate;
    public PlayerVFX playerVFX;
    public PlayerWeapon playerWeapon;

    public PlayerWorker()
    {
        player = Player.Instance;
        playerAnimation = new PlayerAnimation(this);
        playerAttack = new PlayerAttack(this);
        playerAwake = new PlayerAwake(this);
        playerCamera = new PlayerCamera(this);
        playerCombatTechnique = new PlayerCombatTechnique(this);
        playerControl = new PlayerControl(this);
        playerDamage = new PlayerDamage(this);
        playerFixedUpdate = new PlayerFixedUpdate(this);
        playerFixer = new PlayerFixer(this);
        playerInventory = new PlayerInventory(this);
        playerLateUpdate = new PlayerLateUpdate(this);
        playerMovement = new PlayerMovement(this);
        playerPhysics = new PlayerPhysics(this);
        playerRotation = new PlayerRotation(this);
        playerSFX = new PlayerSFX(this);
        playerSphere = new PlayerSphere(this);
        playerStance = new PlayerStance(this);
        playerStart = new PlayerStart(this);
        playerStats = new PlayerStats(this);
        playerUI = new PlayerUI(this);
        playerUpdate = new PlayerUpdate(this);
        playerVFX = new PlayerVFX(this);
        playerWeapon = new PlayerWeapon(this);
    }

    public void AwakeCall() => playerAwake.Awake();

    public void StartCall() => playerStart.Start();

    public void UpdateCall() => playerUpdate.Update();

    public void LateUpdateCall() => playerLateUpdate.LateUpdate();

    public void FixedUpdateCall() => playerFixedUpdate.FixedUpdate();
}
