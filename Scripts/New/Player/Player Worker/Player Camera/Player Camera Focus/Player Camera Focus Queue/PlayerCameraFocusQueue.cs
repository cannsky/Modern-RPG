using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFocusQueue
{
    public class EnemyNear
    {
        public EnemyAI enemyAI;
        public EnemyNear next;
        public EnemyNear previous;

        public EnemyNear(EnemyAI enemyAI)
        {
            this.enemyAI = enemyAI;
        }
    }

    public class CameraFocusQueueState
    {
        public PlayerWorker playerWorker;

        public PlayerCameraSettings cameraSettings;

        public EnemyNear enemyNearRoot, getQueueCurrentEnemyNear;

        public List<EnemyAI> enemyList;

        public bool isRootDeleted;

        public CameraFocusQueueState(PlayerWorker playerWorker, PlayerCameraSettings cameraSettings)
        {
            this.playerWorker = playerWorker;
            this.cameraSettings = cameraSettings;
            enemyList = new List<EnemyAI>();
        }
    }

    public CameraFocusQueueState cameraFocusQueueState;

    public PlayerCameraFocusQueue(PlayerWorker playerWorker) => cameraFocusQueueState = new CameraFocusQueueState(playerWorker, playerWorker.player.playerSettings.cameraSettings);

    public void GenerateList()
    {
        cameraFocusQueueState.enemyList.Clear();
        EnemyNear currentEnemyNear = cameraFocusQueueState.enemyNearRoot;
        while (true)
        {
            if (currentEnemyNear == null) break;
            cameraFocusQueueState.enemyList.Add(currentEnemyNear.enemyAI);
            currentEnemyNear = currentEnemyNear.next;
        }
    }

    public void AddEnemy(EnemyAI enemyAI)
    {
        if (cameraFocusQueueState.enemyNearRoot != null)
        {
            EnemyNear currentEnemyNear = cameraFocusQueueState.enemyNearRoot;
            EnemyNear previousEnemyNear = null;
            while (currentEnemyNear != null)
            {
                if ((int)enemyAI.enemyWorker.enemyType.typeState.type > (int)currentEnemyNear.enemyAI.enemyWorker.enemyType.typeState.type)
                {
                    EnemyNear newEnemyNear = new EnemyNear(enemyAI);
                    if (currentEnemyNear.previous != null) currentEnemyNear.previous.next = newEnemyNear;
                    else
                    {
                        cameraFocusQueueState.enemyNearRoot = newEnemyNear;
                        cameraFocusQueueState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform = cameraFocusQueueState.enemyNearRoot.enemyAI.enemyWorker.enemyCamera.cameraState.lookTransform;
                        //UpdateCameraTargetGroup();
                    }
                    newEnemyNear.previous = currentEnemyNear.previous;
                    currentEnemyNear.previous = newEnemyNear;
                    newEnemyNear.next = currentEnemyNear;
                    break;
                }
                previousEnemyNear = currentEnemyNear;
                currentEnemyNear = currentEnemyNear.next;
            }
            if (currentEnemyNear == null)
            {
                EnemyNear newEnemyNear = new EnemyNear(enemyAI);
                if (previousEnemyNear != null) previousEnemyNear.next = newEnemyNear;
            }
        }
        else
        {
            cameraFocusQueueState.enemyNearRoot = new EnemyNear(enemyAI);
            cameraFocusQueueState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform = cameraFocusQueueState.enemyNearRoot.enemyAI.enemyWorker.enemyCamera.cameraState.lookTransform;
            GameManager.Instance.gameManagerWorker.musicManager.StartMusic(MusicManager.Type.BattleMusic);
            //UpdateCameraTargetGroup();
        }

        cameraFocusQueueState.playerWorker.playerCamera.cameraState.playerCameraHeight.SetCameraHeight();
    }

    public void RemoveEnemy(EnemyAI enemyAI)
    {
        if (cameraFocusQueueState.enemyNearRoot != null)
        {
            EnemyNear currentEnemyNear = cameraFocusQueueState.enemyNearRoot;
            while (currentEnemyNear != null)
            {
                if (enemyAI.enemyWorker.enemyType.typeState.enemyID == currentEnemyNear.enemyAI.enemyWorker.enemyType.typeState.enemyID)
                {
                    if (currentEnemyNear.previous != null) currentEnemyNear.previous.next = currentEnemyNear.next;
                    else
                    {
                        //NULL!!! & Root is being deleted!
                        cameraFocusQueueState.isRootDeleted = true;
                        cameraFocusQueueState.enemyNearRoot = currentEnemyNear.next;
                        if (cameraFocusQueueState.enemyNearRoot != null) cameraFocusQueueState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform = cameraFocusQueueState.enemyNearRoot.enemyAI.enemyWorker.enemyCamera.cameraState.lookTransform;
                        else cameraFocusQueueState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform = null;
                        //UpdateCameraTargetGroup();
                    }
                    if (currentEnemyNear.next != null) currentEnemyNear.next.previous = currentEnemyNear.previous;
                    currentEnemyNear = null;
                    break;
                }
                currentEnemyNear = cameraFocusQueueState.enemyNearRoot.next;
            }
        }
        if(cameraFocusQueueState.enemyNearRoot == null) GameManager.Instance.gameManagerWorker.musicManager.StartMusic(MusicManager.Type.TravelMusic);
    }
}
