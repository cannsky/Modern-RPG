using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public PlayerWorker playerWorker;

    public Mandeshire.PlayerSettings playerSettings;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        playerWorker = new PlayerWorker();
        playerWorker.AwakeCall();
    }

    private void Start() => playerWorker.StartCall();

    private void Update() => playerWorker.UpdateCall();

    public void LateUpdate() => playerWorker.LateUpdateCall();

    public void FixedUpdate() => playerWorker.FixedUpdateCall();

    public Transform InstantiatePlayerVFXGameObject(Transform instantiatedTransform, Vector3 position, Quaternion rotation) => Instantiate(instantiatedTransform, position, rotation);

    public GameObject InstantiatePlayerUIGameObject(GameObject instantiatedGameObject, Vector3 position, Quaternion rotation, Transform parent) => Instantiate(instantiatedGameObject, position, rotation, parent);
}