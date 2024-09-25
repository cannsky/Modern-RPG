using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStanceSettings
{
    [SerializeField] public float changeToAggressiveStanceWaitTime = 25f;
    [SerializeField] public float idleWaitTime = 8f;
}
